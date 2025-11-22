using BusinessLogic.DException;
using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace IDK_Api.MIddleWare
{
    public class MiddlewareErrorHandler
    {
        private readonly RequestDelegate _next;
        public MiddlewareErrorHandler(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (HttpException ex)
            {
                SendResponse(context, ex.Message, ex.StatusCode);
            }
            catch (Exception ex)
            {
                SendResponse(context, ex.Message);
            }
        }
        private async void SendResponse(HttpContext context, string msg, HttpStatusCode code = HttpStatusCode.InternalServerError)
        {
            context.Response.StatusCode = (int)code;
            await context.Response.WriteAsJsonAsync(new ProblemDetails
            {
                Title = "Error",
                Detail = msg,
                Status = (int)code
            });
        }
    }
}
