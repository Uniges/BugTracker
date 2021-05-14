using BugTracker.Applicaton.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Threading.Tasks;

namespace BugTracker.WebApp
{
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
            catch (UserAuthException)
            {
                httpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            }
            catch (UserNotFoundException)
            {
                httpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
            }
            catch (BugNotFoundException)
            {
                httpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
            }
            catch (BugInputPropertyException)
            {
                httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            catch (BugUpdateException)
            {
                httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
        }
    }

    public static class ExceptionHandlerMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionHandlerMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlerMiddleware>();
        }
    }
}
