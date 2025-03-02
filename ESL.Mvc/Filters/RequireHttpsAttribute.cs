using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ESL.Mvc.Filters
{
    public class RequireHttpsAttribute : AuthorizeAttribute
    {
        public void OnAuthorization(AuthorizationFilterContext actionContext)
        {
            if (!actionContext.HttpContext.Request.IsHttps)
            {
                actionContext.Result = new StatusCodeResult(StatusCodes.Status403Forbidden);
            }
        }
    }
}
