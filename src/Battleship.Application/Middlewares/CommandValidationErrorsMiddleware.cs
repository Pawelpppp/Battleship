using Battleship.Application.Common.Exceptions;
using Microsoft.AspNetCore.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Battleship.Application.Middlewares
{
    public class CommandValidationErrorsMiddleware
    {
        private readonly RequestDelegate _next;

        public CommandValidationErrorsMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ValidationException error)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                response.StatusCode = 200;

                var result = JsonSerializer.Serialize(ResponseResult.Failure(error.Errors));
                await response.WriteAsync(result);
            }
        }
    }
}
