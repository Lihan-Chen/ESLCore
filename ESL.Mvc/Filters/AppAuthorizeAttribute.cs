using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ESL.Mvc.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public sealed class AppAuthorizeAttribute : AuthorizeAttribute  // added sealed
    {
        public void OnAuthorization(AuthorizationFilterContext filterContext)
        {
            var user = filterContext.HttpContext.User?.Identity;

            if (user == null || !user.IsAuthenticated) // Fixed CS8602 by adding null check
            {
                filterContext.Result = new UnauthorizedObjectResult("ESL does not recognize you.  Please Sign In.");
                return;
            }

            // to be enhanced for authorization
            //if (!user.IsAuthorized())
            //{
            //    var result = new ViewResult { ViewName = "UnAuthorized" };
            //    result.ViewBag.Message = "Sorry! You are not authorized to do this!";
            //    filterContext.Result = result;
            //}
        }

        private static void HandleUnauthorizedRequest(AuthorizationFilterContext filterContext)
        {
            if (IsAjaxRequest(filterContext.HttpContext.Request))
            {
                filterContext.Result = new JsonResult(new { message = "sorry, but you were logged out" });
            }
            else
            {
                filterContext.Result = new UnauthorizedResult();
            }
        }

        private static bool IsAjaxRequest(HttpRequest request)
        {
            return request.Headers.XRequestedWith == "XMLHttpRequest";
        }
    }
}
