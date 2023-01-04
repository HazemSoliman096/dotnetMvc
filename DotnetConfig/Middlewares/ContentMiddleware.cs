using System.Threading.Tasks;
using Dotnetconfig.Services;
using Microsoft.AspNetCore.Http;

namespace Dotnetconfig.Middllewares
{
    public class ContentMiddleware
    {

        private RequestDelegate nextDelegate;
        private TotalUsers totalUsers;

        public ContentMiddleware(RequestDelegate next, TotalUsers tu)
        {
            nextDelegate = next;
            totalUsers = tu;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Path.ToString() == "/middleware")
            {
                await context.Response.WriteAsync("This is from the content Middleware, TotalUsers is " + totalUsers.TUsers());
            }
            else
            {
                await nextDelegate.Invoke(context);
            }
        }
    }
}
