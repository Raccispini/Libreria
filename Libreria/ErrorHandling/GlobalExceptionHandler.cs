using Libreria.Application.Factories;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace Libreria.Web.ErrorHandling
{
    internal sealed class GlobalExceptionHandler : IExceptionHandler
    {
        
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, 
            Exception exception, 
            CancellationToken cancellationToken)
        {
            httpContext.Response.ContentType = "application/json";
            
            var response = ResponseFactory.WithErrors(exception);
            await httpContext.Response.WriteAsync(JsonSerializer.Serialize(response), cancellationToken);
            return true;
        }
    }
}
