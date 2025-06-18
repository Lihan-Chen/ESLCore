using ESL.Core.Models.BusinessEntities;
using ESL.Application.Interfaces.IServices;
using ESL.Infrastructure.DataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
//using Microsoft.Graph;
using Microsoft.Identity.Web;
using ESL.Core.Models.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using Shift = ESL.Core.Models.Enums.Shift;
using OperatorType = ESL.Core.Models.Enums.OperatorType;
using Plant = ESL.Core.Models.Enums.Plant;
using ESL.Mvc.ViewModels;
//using GraphHelper = ESL.Mvc.Services.GraphHelper;
using Microsoft.AspNetCore.Http;
using ESL.Mvc.Models;

namespace ESL.Mvc.Controllers
{
    // https://github.com/Azure-Samples/active-directory-aspnetcore-webapp-openidconnect-v2/blob/master/5-WebApp-AuthZ/5-1-Roles/Controllers/HomeController.cs
    [Authorize]
    public class HomeOldController(EslDbContext context, 
                                IHttpContextAccessor httpContextAccessor,
                                ILogger<HomeOldController> logger,
                                ICoreService coreService) : BaseController<HomeOldController>(context, httpContextAccessor, logger, coreService)
    {
        private readonly EslDbContext _context = context ?? throw new ArgumentNullException(nameof(context));
        private ILogger<HomeOldController>? _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        private IHttpContextAccessor _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        private ICoreService _coreService = coreService ?? throw new ArgumentNullException(nameof(coreService));

        private int? _facilNo; // => FacilNo;
        private string? _facilName;
        private bool _showAlert = false;
        private Shift? _shift;
        private bool _isUserAuthenticatedOnly = true; // IsAuthenticatedOnly;

        [AuthorizeForScopes(ScopeKeySection = "MicrosoftGraph:Scopes")]
        // [AuthorizeForScopes(ScopeKeySection = "DownstreamApi:Scopes")]
        public async Task<IActionResult> Index(string returnUrl, bool showAlert = false)
        {
            _showAlert = _showAlert is true;

            //DateTime _shiftStartTime = Convert.ToDateTime(ShiftStartTimeString); // Converts only the time
            //DateTime _shiftEndTime = Convert.ToDateTime(ShiftEndTimeString);

            // Login logic
            // if UserSession.UserLoggedIn is true, redirect to AllEventsController Index with user, shift, operatype, and role info;
            // otherwise, redirect for login

            // if user successfully logged in,
            if (User.Identity is not null && User.Identity.IsAuthenticated)
            {
                // Set persistent cookie for user name
                SetPersistentCookie(HttpContext, SessionKeyUserName, User.Identity.Name!, 30);
            }
            else
            {
                // If user is not authenticated, redirect to login page
                return RedirectToAction("Login", "Account", new { returnUrl });
            }

            var userName = UserName; // isAuthenticated ? User.FindFirst(c => c.Type == "name")?.Value : UserName;

            // Get employee object using EmployeeService from DbContext and set it to BaseController's SessionUser          
            Employee? sessionUser = await _coreService.GetEmployeeByEmployeeName(userName!);

            if (sessionUser == null)
            {
                ViewData["isUserAuthenticatedOnly"] = true;
                _logger?.LogWarning("SessionUser is null for user: {UserName}", userName);
                return RedirectToAction("SelectAPlant", "Home", new { returnUrl });
            }

            string? userRole = await _coreService.GetRole(UserID!, (int)_facilNo!);

            //IsSuperAdmin = userRole == Role_SuperAdmin;

            //IsAdmin = userRole == Role_Admin || userRole == Role_SuperAdmin;

            //IsOperator = userRole == Role_Operator || userRole == Role_Admin || userRole == Role_SuperAdmin;

            var plants = Enum.GetValues(typeof(Plant))  // _employeeService.GetFacilSelectList(_facilNo);
                .Cast<Plant>()
                .Select(s => new { ID = s, Name = s.ToString() });


            var myOpTypeList = Enum.GetValues(typeof(OperatorType))
                .Cast<OperatorType>()
                .Select(s => new { ID = s, Name = s.ToString() });

            var myShiftList = Enum.GetValues(typeof(Core.Models.Enums.Shift))
                .Cast<Core.Models.Enums.Shift>()
                .Select(s => new { ID = s, Name = s.ToString() });

            // Set Shift based on current time
            Enum _shift = GetDefaultShift();

            ViewBag.Shift = _shift;

            var model = new UserSessionViewModel()
            {
                SessionID = Guid.Parse(HttpContext.Session.Id),
                UserID = UserID,
                SelectedShift = (Shift?)_shift,
                SelectedOperatorType = OperatorType.Primary,
                FacilSelectList = new SelectList(plants, "ID", "Name", _facilNo),
                OpTypeSelectList = new SelectList(myOpTypeList, "ID", "Name"),
                ShiftSelectList = new SelectList(myShiftList, "ID", "Name", _shift)
            };

            ViewBag.ReturnUrl = returnUrl;

            return View(model);
        }






            //// Reference code for accessing MS Graph

            //// Extract values from HttppContext.User.Claims
            //var claim = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "name");

            //// user is from Microsoft Graph which contains GivenName, Surname, Id (Guid), DisplayName, OfficeLocation, BusinessPhones, MobilePhone, JobTitle, ODataType (Mocrosoft.Graphu.User), Mail, UserPrincipalName (=email)
            //// need to check if the token is in the cache. https://github.com/AzureAD/microsoft-identity-web/issues/13
            //var user = await _graphServiceClient.Me.Request().GetAsync();

            //ViewData["GraphApiResult"] = $"{userName} is authenticated from Microsoft Graph: User Given Name: {user.GivenName}, Surname: {user.Surname}{Environment.NewLine}DisplayName: {user.DisplayName}, UserPrincipalName: {user.UserPrincipalName}"; // {userInfo.EmployeeNo}

            //// ToDo: Update Session with Username, Isauthenticated, DisplayName, UserID, and roles 
            //HttpContext.Session.SetString(SessionKeyUserName, $"{userName}");

            //string _loginUserName = HttpContext.Session.GetString("_UserName");

            //// user may not have the facilNo assigned
            ////int? facilNo = SessionUser?.FacilNo;


            //if (FacilNo == 0)
            //{
            //    showAlert = FacilNo == 0;
            //    if (UserSessionState == SessionState.New)
            //    {
            //        HttpContext.Session.SetString(SessionKeyUserSessionState, UserSessionState.ToString());
            //    }
                
            //    // redirect to plant selection to set FacilNo
            //    if (showAlert)
            //    {
            //        ViewBag.ShowAlert = true;
            //        ViewBag.Alert = "You must select a facility first!";
            //    }

            //    ViewBag.ShowPlantMenu = IsCheckingFacility; // true;
            //    ViewBag.Message = "Please select one facility from the list - ";
            //    ViewBag.ReturnUrl = this.Url;

            //    return View();
            //}
            //else
            //{
            //    IsNewSession = false;
            //    HttpContext.Session.SetString(SessionKeyUserSessionState, SessionState.Valid.ToString());
            //    HttpContext.Session.SetString(SessionKeyUserName, $"{userName}");
            //    HttpContext.Session.SetString(SessionKeyUserID, $"{UserID}");
            //    HttpContext.Session.SetInt32(SessionKeyUserEmployeeNo, (int)UserEmployeeNo);
            //    HttpContext.Session.SetInt32(SessionKeyUserSelectedPlant, (int)FacilNo);
            //    HttpContext.Session.SetInt32(SessionKeyUserShiftNo, ShiftNo);
            //    HttpContext.Session.SetString(SessionKeyUserOpType, OperatorType);

            //    return RedirectToAction("Index", "AllEvents");
            //}

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
        //}


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
