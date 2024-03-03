using Libreria.Application.Models.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Libreria.Web.Result
{
    public class BadRequestResultFactory :BadRequestObjectResult
    {

        public BadRequestResultFactory(ActionContext context) : base(new BadResponse()) { 
            var retErrors = new List<String>();
            foreach (var key in context.ModelState)
            {
                var errors = key.Value.Errors;
                for(var i = 0;i<errors.Count;i++)
                {
                    retErrors.Add(errors[0].ErrorMessage);
                }
            }

            var response= (BadResponse) Value;
            response.Errors = retErrors;
            response.Result = false;
        }
    }
}
