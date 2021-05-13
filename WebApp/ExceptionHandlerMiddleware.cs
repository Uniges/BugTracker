using BugTracker.Applicaton;
using BugTracker.Applicaton.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Threading.Tasks;

namespace BugTracker.WebApp
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (UserNotFoundException e)
            {
                httpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
            }
            catch (BugNotFoundException e)
            {
                httpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
            }
            catch (BugUpdateException e)
            {
                httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ExceptionHandlerMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionHandlerMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlerMiddleware>();
        }
    }
}
