using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Configuation.Middlewares
{
    public class ShortCircuitMiddleware
    {
        private RequestDelegate nextDelegate;

        public ShortCircuitMiddleware(RequestDelegate next) => nextDelegate = next;

        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Items["Firefox"] as bool? == true)
            {
                httpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
            }
            else
            {
                await nextDelegate.Invoke(httpContext);
            }
        }
    }
}
