using ESL.Mvc.Infrastructure;
using ESL.Mvc.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web;

namespace ESL.Mvc.Controllers
{
    public class AccountController : Controller
    {
        private readonly GraphHelper _graphHelper;

        public AccountController(IHttpContextAccessor httpContextAccessor)
        {
            this._graphHelper = new GraphHelper(httpContextAccessor.HttpContext, new[] { GraphScopes.DirectoryReadAll });
        }

        /// <summary>
        /// AspNet core's default AuthorizeAttribute redirects to '/Account/AccessDenied' when it processes the Http code 403 (Unauthorized)
        /// Instead of implementing an Attribute class of our own to construct a redirect Url, we'd just implement our own to show an error message of
        /// our choice to the user.
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }

        /// <summary>
        /// Fetches all the groups a user is assigned to.  This method requires the signed-in user to be assigned to the 'DirectoryViewers' approle.
        /// </summary>
        /// <returns></returns>
        [AuthorizeForScopes(Scopes = new[] { GraphScopes.DirectoryReadAll })]
        [Authorize(Policy = AuthorizationPolicies.AssignmentToDirectoryViewerRoleRequired)]
        public async Task<IActionResult> Groups()
        {
            ViewData["Groups"] = await _graphHelper.GetMemberOfAsync();

            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
