using Libreria.Application.Models.Responses;

namespace Libreria.Application.Factories
{
    public class ResponseFactory
    {
        public static BaseResponse<T> WithSuccess<T>(T result)
        {
            var response = new BaseResponse<T>();
            response.Success = true;
            response.Result = result;
            return response;
        }

        public static BaseResponse<string> WithSuccess()
        {
            var response = new BaseResponse<string>();
            response.Success = true;
            return response;
        }
        public static BaseResponse<T> WithErrors<T>(T result)
        {
            var response = new BaseResponse<T>();
            response.Success = true;
            response.Result = result;
            return response;
        }
        public static BaseResponse<string?> WithErrors(Exception exception)
        {
            var response = new BaseResponse<string>();
            response.Success = false;
            response.Errors = new List<string>()
            {
                exception.Message
            };
            return response;
        }
    }
}
