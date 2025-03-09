using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Builder;
using System.Diagnostics;
using WebAPI.Services;

namespace WebAPI.Midlewares{
    public class CustomExceptionMiddlewares{
        private readonly RequestDelegate _next;
        private readonly ILoggerService _loggerService;

        public CustomExceptionMiddlewares(RequestDelegate next, ILoggerService loggerService)
        {
            _next = next;
            _loggerService = loggerService;
        }
        public async Task Invoke (HttpContext context){
            var watch = Stopwatch.StartNew();
            string message = "[Request] HTTP "+context.Request.Method+"-"+context.Request.Path;
            _loggerService.Write(message);

            await _next(context);
            watch.Stop();

            message = "[Response] HTTP "+context.Request.Method+"-"+context.Request.Path +"responded"+context.Response.StatusCode+" in"+watch.Elapsed.TotalMilliseconds+"ms";
            _loggerService.Write(message);
        }
    }
    public static class CustomExceptionMiddlewareExtension{
        public static IApplicationBuilder UseCustomExceptionMiddleware(this IApplicationBuilder builder){
            return builder.UseMiddleware<CustomExceptionMiddlewares>();
        }
    }
}