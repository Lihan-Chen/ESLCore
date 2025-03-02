using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Net.Http.Headers;

namespace ESL.Mvc.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public sealed class NoCacheAttribute : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            var response = filterContext.HttpContext.Response;

            response.Headers[HeaderNames.Expires] = DateTime.UtcNow.AddDays(-1).ToString("R");
            response.Headers[HeaderNames.CacheControl] = "no-cache, no-store, must-revalidate";
            response.Headers[HeaderNames.Pragma] = "no-cache";
            response.Headers[HeaderNames.Vary] = "*";

            base.OnResultExecuting(filterContext);
        }
    }
}
