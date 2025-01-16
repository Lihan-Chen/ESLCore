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
using ESL.Core.IRepositories;
using System.Runtime.CompilerServices;
using ESL.Core.Models.Enums;

namespace ESL.Mvc.Controllers
{   
    // https://github.com/Azure-Samples/active-directory-aspnetcore-webapp-openidconnect-v2/blob/master/5-WebApp-AuthZ/5-1-Roles/Controllers/HomeController.cs
    [Authorize]
    public class HomeController : BaseController
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly GraphHelper _graphHelper;
        private readonly IEmployeeService _employeeService;
        private readonly GraphServiceClient _graphServiceClient;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, GraphServiceClient graphServiceClient, IHttpContextAccessor httpContextAccessor, IConfiguration configuration, IEmployeeService employeeService) : base(httpContextAccessor) //, IDownstreamApi downstreamApi
        {
            _logger = logger;

            _graphServiceClient = graphServiceClient;
            this._httpContextAccessor = httpContextAccessor;
            this._employeeService = employeeService;
            string[] graphScopes = configuration.GetValue<string>("DownstreamApi:Scopes")?.Split(' ');

            if (this._httpContextAccessor.HttpContext != null)
            {
                this._graphHelper = new GraphHelper(this._httpContextAccessor.HttpContext, graphScopes);
            }
        }

        private int? _facilNo => FacilNo;
        private string _facilName;
        private bool showAlert = false;

        [AuthorizeForScopes(ScopeKeySection = "MicrosoftGraph:Scopes")]
        // [AuthorizeForScopes(ScopeKeySection = "DownstreamApi:Scopes")]
        public async Task<IActionResult> Index(string returnUrl, bool showAlert = false)
        {
            showAlert = showAlert is true ? true : false;

            // Login logic
            // if UserSession.UserLoggedIn is true, redirect to AllEventsController Index with user, shift, operatype, and role info;
            // otherwise, redirect for login

            // if user successfully logged in, 
            bool isAuthenticated = User.Identity!.IsAuthenticated;
                   
            var userName =  isAuthenticated ? User.FindFirst(c => c.Type == "name")?.Value : UserName;

            // Get employee object using EmployeeService from DbContext and set it to BaseController's SessionUser          
            SessionUser = await _employeeService.GetEmployeeByEmployeeName(userName!);
            
            string? userRole = await _employeeService.GetRole(UserID, (int)_facilNo);
            
            IsSuperAdmin = userRole == Role_SuperAdmin;

            IsAdmin = userRole == Role_Admin || userRole == Role_SuperAdmin;

            IsOperator = userRole == Role_Operator || userRole == Role_Admin || userRole == Role_SuperAdmin;














            // Reference code for accessing MS Graph

            // Extract values from HttppContext.User.Claims
            var claim = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "name");

            // user is from Microsoft Graph which contains GivenName, Surname, Id (Guid), DisplayName, OfficeLocation, BusinessPhones, MobilePhone, JobTitle, ODataType (Mocrosoft.Graphu.User), Mail, UserPrincipalName (=email)
            // need to check if the token is in the cache. https://github.com/AzureAD/microsoft-identity-web/issues/13
            var user = await _graphServiceClient.Me.Request().GetAsync();

            ViewData["GraphApiResult"] = $"{userName} is authenticated from Microsoft Graph: User Given Name: {user.GivenName}, Surname: {user.Surname}{Environment.NewLine}DisplayName: {user.DisplayName}, UserPrincipalName: {user.UserPrincipalName}"; // {userInfo.EmployeeNo}

            // ToDo: Update Session with Username, Isauthenticated, DisplayName, UserID, and roles 
            HttpContext.Session.SetString(SessionKeyUserName, $"{userName}");

            string _loginUserName = HttpContext.Session.GetString("_UserName");

            // user may not have the facilNo assigned
            //int? facilNo = SessionUser?.FacilNo;


            if (FacilNo == 0)
            {
                showAlert = FacilNo == 0;
                if (UserSessionState == SessionState.New)
                {
                    HttpContext.Session.SetString(SessionKeyUserSessionState, UserSessionState.ToString());
                }
                
                // redirect to plant selection to set FacilNo
                if (showAlert)
                {
                    ViewBag.ShowAlert = true;
                    ViewBag.Alert = "You must select a facility first!";
                }

                ViewBag.ShowPlantMenu = IsCheckingFacility; // true;
                ViewBag.Message = "Please select one facility from the list - ";
                ViewBag.ReturnUrl = this.Url;

                return View("Index");
            }
            else
            {
                IsNewSession = false;
                HttpContext.Session.SetString(SessionKeyUserSessionState, SessionState.Valid.ToString());
                HttpContext.Session.SetString(SessionKeyUserName, $"{userName}");
                HttpContext.Session.SetString(SessionKeyUserID, $"{UserID}");
                HttpContext.Session.SetInt32(SessionKeyUserEmployeeNo, (int)UserEmployeeNo);
                HttpContext.Session.SetInt32(SessionKeyUserSelectedPlant, (int)FacilNo);
                HttpContext.Session.SetInt32(SessionKeyUserShiftNo, ShiftNo);
                HttpContext.Session.SetString(SessionKeyUserOpType, OperatorType);

                return RedirectToAction("Index", "AllEvents");
            }

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

            //// user is from Microsoft Graph which contains GivenName, Surname, Id (Guid), DisplayName, OfficeLocation, BusinessPhones, MobilePhone, JobTitle, ODataType (Mocrosoft.Graphu.User), Mail, UserPrincipalName (=email)
            //var user = await _graphServiceClient.Me.Request().GetAsync();

            //// ViewData["GraphApiResult"] = user.DisplayName;

            //ViewData["GraphApiResult"] = $"{userName} is authenticated from Microsoft Graph: User Given Name: {user.GivenName}, Surname: {user.Surname}{Environment.NewLine}DisplayName: {user.DisplayName}, UserPrincipalName: {user.UserPrincipalName}"; // {userInfo.EmployeeNo}

            //// ToDo: Update Session with Username, Isauthenticated, DisplayName, UserID, and roles 
            //HttpContext.Session.SetString("_userName", $"{userName}");

            //string _loginUserName = HttpContext.Session.GetString("_userName");

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

            //return View();
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

        private void SetPersistentCookie(HttpContext httpContext, string key, string value, int daysToExpire)
        {
            CookieOptions options = new CookieOptions
            {
                Expires = DateTime.Now.AddDays(daysToExpire),
                IsEssential = true,
                HttpOnly = true,
                Secure = true
            };

            httpContext.Response.Cookies.Append(key, value, options);
        }
    }
}
