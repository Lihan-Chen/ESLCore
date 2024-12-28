using ESL.Mvc.Models;
using ESL.Mvc.Infrastructure;
using ESL.Mvc.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using Microsoft.Graph;
using Microsoft.Identity.Web;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

using Microsoft.Identity.Abstractions;
using Microsoft.Identity.Client;
using Microsoft.Extensions.Configuration;

namespace ESL.Mvc.Controllers
{
    
    // https://github.com/Azure-Samples/active-directory-aspnetcore-webapp-openidconnect-v2/blob/master/5-WebApp-AuthZ/5-1-Roles/Controllers/HomeController.cs
    [Authorize]
    public class HomeController : BaseController
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IDownstreamApi _downstreamApi;
        private readonly GraphHelper _graphHelper;

        private readonly GraphServiceClient _graphServiceClient;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, GraphServiceClient graphServiceClient, IHttpContextAccessor httpContextAccessor, IConfiguration configuration) //, IDownstreamApi downstreamApi
        {
            _logger = logger;

            _graphServiceClient = graphServiceClient;
            _httpContextAccessor = httpContextAccessor;
            string[] graphScopes = configuration.GetValue<string>("DownstreamApi:Scopes")?.Split(' ');
            // _downstreamApi = downstreamApi;

            if (this._httpContextAccessor.HttpContext != null)
            {
                this._graphHelper = new GraphHelper(this._httpContextAccessor.HttpContext, graphScopes);
            }
        }

        [AuthorizeForScopes(ScopeKeySection = "MicrosoftGraph:Scopes")]
        // [AuthorizeForScopes(ScopeKeySection = "DownstreamApi:Scopes")]
        public async Task<IActionResult> Index()
        {
            //using var response = await _downstreamApi.CallApiForUserAsync("DownstreamApi").ConfigureAwait(false);
            //if (response.StatusCode == System.Net.HttpStatusCode.OK)
            //            {
            //                var apiResult = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            //                ViewData["ApiResult"] = apiResult;
            //            }
            //            else
            //            {
            //                var error = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            //                throw new HttpRequestException($"Invalid status code in the HttpResponseMessage: {response.StatusCode}: {error}");
            //            };

            // From ClaimsPrincipal in base controller
            string userName = User.Identity!.Name;

            bool isAuthenticated = User.Identity!.IsAuthenticated;

            ViewData["User"] = _httpContextAccessor.HttpContext.User;

            // For future use
            // https://learn.microsoft.com/en-us/answers/questions/1226274/azure-ad-b2c-net-web-app-calling-web-api-no-accoun
            //AuthenticationResult result = null;
            //try
            //{
            //    result = await app.AcquireTokenSilent(scopes, accounts.FirstOrDefault())
            //                      .ExecuteAsync();
            //}
            //catch (MsalUiRequiredException ex)
            //{
            //    // A MsalUiRequiredException happened on AcquireTokenSilent.
            //    // This indicates you need to call AcquireTokenInteractive to acquire a token
            //    Debug.WriteLine($"MsalUiRequiredException: {ex.Message}");

            //    try
            //    {
            //        result = await app.AcquireTokenInteractive(scopes)
            //                          .ExecuteAsync();
            //    }
            //    catch (MsalException msalex)
            //    {
            //        ResultText.Text = $"Error Acquiring Token:{System.Environment.NewLine}{msalex}";
            //    }
            //}
            //catch (Exception ex)
            //{
            //    ResultText.Text = $"Error Acquiring Token Silently:{System.Environment.NewLine}{ex}";
            //    return;
            //}

            //if (result != null)
            //{
            //    string accessToken = result.AccessToken;
            //    // Use the token
            //}

            // user is from Microsoft Graph which contains GivenName, Surname, Id (Guid), DisplayName, OfficeLocation, BusinessPhones, MobilePhone, JobTitle, ODataType (Mocrosoft.Graphu.User), Mail, UserPrincipalName (=email)
            var user = await _graphServiceClient.Me.Request().GetAsync();

            // ViewData["GraphApiResult"] = user.DisplayName;

            ViewData["GraphApiResult"] = $"From Microsoft Graph: User Given Name: {user.GivenName}, Surname: {user.Surname}{Environment.NewLine}DisplayName: {user.DisplayName}, UserPrincipalName: {user.UserPrincipalName}"; // {userInfo.EmployeeNo}

            // ToDo: Update Session with Username, Isauthenticated, DisplayName, UserID, and roles 
            HttpContext.Session.SetString("_userName", $"{user.DisplayName}");

            // Session
            //public const string SessionKeyUserName = "_UserName";
            //public const string SessionKeyUserID = "_UserID";
            //public const string SessionKeyFacilNo = "_FacilNo";

            //if (string.IsNullOrEmpty(HttpContext.Session.GetString(SessionKeyUserName)))
            //{
            //    HttpContext.Session.SetString(SessionKeyUserName, "Lihan Chen");
            //    HttpContext.Session.SetString(SessionKeyUserID, "U06337");
            //    HttpContext.Session.SetInt32(SessionKeyFacilNo, 1);
            //}

            //var userName = HttpContext.Session.GetString(SessionKeyUserName);
            //var facilNo = HttpContext.Session.GetInt32(SessionKeyFacilNo).ToString();


            return View();
        }

        [AuthorizeForScopes(ScopeKeySection = "DownstreamApi:Scopes")]
        public async Task<IActionResult> Profile()
        {
            ViewData["Me"] = await _graphHelper.GetMeAsync();

            if (ViewData["Me"] == null)
            {
                return new EmptyResult();
            }

            var photoStream = await this._graphHelper.GetMyPhotoAsync();
            ViewData["Photo"] = photoStream != null ? Convert.ToBase64String(((MemoryStream)photoStream).ToArray()) : null;

            return View();
        }

        /// <summary>
        /// Fetches and displays all the users in this directory. This method requires the signed-in user to be assigned to the 'UserReaders' approle.
        /// </summary>
        /// <returns></returns>
        [AuthorizeForScopes(Scopes = new[] { GraphScopes.UserReadBasicAll })]
        [Authorize(Policy = AuthorizationPolicies.AssignmentToUserReaderRoleRequired)]
        public async Task<IActionResult> Users()
        {
            ViewData["Users"] = await this._graphHelper.GetUsersAsync();

            if (ViewData["Users"] == null)
            {
                return new EmptyResult();
            }

            return View();
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Privacy()
        {
            //return View();
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
