using ESL.Core.Models.BusinessEntities;
using ESL.Core.Models.Enums;
using ESL.Infrastructure.DataAccess;
using ESL.Application.Interfaces.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Diagnostics;
using ESL.Mvc.Models;
using ESL.Mvc.ViewModels;
using Microsoft.AspNetCore.Http;

namespace ESL.Mvc.Controllers
{
    // https://www.youtube.com/watch?v=s4ysc9DneP8&t=103s
    public class BaseController<T>(EslDbContext context, IHttpContextAccessor httpContextAccessor, ILogger<T> logger, ICoreService coreService) : Controller where T : BaseController<T>
    {
        private readonly EslDbContext _context = context ?? throw new ArgumentNullException(nameof(context));
        private readonly ILogger<T>? _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        private readonly ICoreService _coreService = coreService ?? throw new ArgumentNullException(nameof(coreService));

        // Non DI version
        //protected ILogger<T> Logger
        //    => _logger ??= HttpContext.RequestServices.GetRequiredService<ILogger<T>>();  // GetService(typeof(ILogger<T>)) as ILogger<T>
        //protected IActionContextAccessor ActionContextAccessor
        //    => _actionContextAccessor ??= HttpContext.RequestServices.GetRequiredService<IActionContextAccessor>(); 
        
        #region Constants

        //Session Key Names
        protected const string SessionKeyUserSessionID = "_SessionID";
        protected const string SessionKeyIsUserAnOperator = "_IsUserAnOperator";
        protected const string SessionKeyUserSessionState = "_SessionState"; // eg. [New, InProgress, Valid, Expired, Invalid] - to track the session state
        protected const string SessionKeyUserName = "_UserName";
        protected const string SessionKeyUserID = "_UserID";
        protected const string SessionKeyUserEmployeeNo = "_UserEmployeeNo";
        protected const string SessionKeyUserRole = "_UserRole"; // eg. [Operator, Admin, SuperAdmin]
        protected const string SessionKeyUserSelectedPlant = "_UserSelectedPlant"; // eg. [1 = OCC, 2 = Diemer, 3 = Jensen, 4 = Mills, 5 = Weymouth, 6 = Skinner, 7 = DOCC, 8 = Intake, 9 = Gene, 10 = Iron, 11 = Eagle, 12 = Hinds, 13 = DVL]
        protected const string SessionKeyUserShiftNo = "_UserSelectedShiftNo"; // eg. [1 = Day, 2 = Night]
        protected const string SessionKeyUserOperatorType = "_UserSelectedOperatorType"; // eg. [1 = Primary, 2 = Secondary]
        protected const string SessionKeyUserShift = "_UserSelectedShift"; // eg. [Day or Night]
        protected const string SessionKeyUserSessionStart = "_SessionStart"; // eg. [DateTime.Now] - when the user session is created
        protected const string SessionKeyUserSessionEnd = "_SessionEnd"; // eg. [DateTime.Now.AddMinutes(30)] - when the user session is expired
        protected const string SessionKeyUserLastSessionID = "_LastSessionID";

        protected const string LogOutUrl = $"/MicrosoftIdentity/Account/SignedOut";
        protected const string LoginUrl = $"https://login.microsoftonline.com/";

        protected const string Role_Admin = "ESL_ADMIN";
        protected const string Role_SuperAdmin = "ESL_SUPERADMIN";
        protected const string Role_Operator = "ESL_OPERATOR";

        protected const String ShiftStartTimeString = "06:00:00";  // for Day shift
        protected const String ShiftEndTimeString = "17:59:00";

        #endregion constants

        #region properties

        
        // Session related properties
        protected bool IsAuthenticated => User.Identity!.IsAuthenticated;

        protected bool IsAuthenticatedOnly => SessionUser is null;

        // Session.IsNew when there are no keys in the session
        protected bool IsNewSession
        {
            get
            {
                return !HttpContext.Session.Keys.Any();
            }
        }

        protected string SessionID => HttpContext.Session.Id;

        protected DateTime SessionStartDate
        {
            get
            {
                if (DateTime.TryParse(HttpContext.Session.GetString(SessionKeyUserSessionStart), out DateTime result))
                {
                    return result;
                }

                return DateTime.Now;
            }
        }

        protected string? UserName => User.Identity!.IsAuthenticated ? User.FindFirst(c => c.Type == "name")?.Value : string.Empty;

        // From asp.net core identity (https://www.youtube.com/watch?v=S0RSsHKiD6Y)
        //protected string? UserID => Claims.ClaimsPrincipal.FindFirstValue(ClaimTypes.NameIdentifier); // or User.FindFirstValue(ClaimTypes.NameIdentifier);

        // SessionUser is the authenticated user that should have been recorded in the ESL_Employee table from Oracle ESL schema
        protected Task<Employee?> SessionUser => _coreService.GetEmployeeByEmployeeName(UserName); // to be set by HomeController 

        protected int? UserEmployeeNo => SessionUser?.Result?.EmployeeNo;
        
        protected string? UserID => SessionUser?.Result?.EmployeeID;

        protected bool UserLoggedIn => IsAuthenticated;
        protected bool IsOperator => UserID is not null && _coreService.IsInRole(UserID, Role_Operator, FacilNo).Result; // true if user is an operator
        protected bool IsAdmin => UserID is not null && _coreService.IsInRole(UserID, Role_Admin, FacilNo).Result;
        protected bool IsSuperAdmin => UserID is not null && _coreService.IsInRole(UserID, Role_SuperAdmin, FacilNo).Result;

        // Current User Shift Information

        protected static string Shift = null!;  // Day or Night
        protected static int SelectedShiftNo; // 1 or 2
        protected static string SelectedOperatorType = null!; // Primary or Secondary
        protected static int SessionTimeOut = 30; // extends additional time for session

        protected static DateTime Now = DateTime.Now;
        protected static DateOnly Today = DateOnly.FromDateTime(Now);
        protected static DateOnly Tomorrow = Today.AddDays(+1);
        // ToDo: check if this format is correct
        protected string YesterdayDate = Today.AddDays(-1).ToString("MM/dd/yyyy");
        protected string TodayDate = Today.ToString("yyyyMMdd");
        protected string TomorrowDate = Tomorrow.ToString("yyyyMMdd");
        protected int DaysOffSet = -2;

        // TimeSpan for two and half hours
        protected TimeSpan TimeSpan = new(2, 30, 0); // = new TimeSpan(2, 30, 0); 

        protected bool OkToProceed = false;

        protected int _pageSize = 40;

        // from cookies or query string
        protected  int? FacilNo
        {
            get
            {
                if (int.TryParse(HttpContext.Request.Cookies["facilNo"], out int result))
                {
                    return result;
                }

                return null;
            }
        }

        protected string? FacilName { get; set; }
        protected int? LogTypeNo { get; set; }
        //{
        //    get
        //    {
        //        if (int.TryParse(HttpContext.Request.Cookies["logTypeNo"], out int result))
        //        {
        //            return result;
        //        }
        //        return null;
        //    }
        //}

        protected string? EventID => HttpContext.Request.Cookies["eventID"];
        protected int? EventID_RevNo { get; set; }
        //{
        //    get
        //    {
        //        if (int.TryParse(HttpContext.Request.cookies["eventID_RevNo"], out int result))
        //        {
        //            return result;
        //        }
        //        return null;
        //    }
        //}
        #endregion properties

        #region Methods

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        // The following can be refactored to HttpContextExtensions
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // 1.if user is not authenticated or authorized, redirect to login
            // 2.else determine if the session is new
            if (!IsAuthenticated)
            {
                // return Results.Unauthorized HttpStatusCode=401;
                // or, context.Result = new UnauthorizedResult();
                context.Result = new UnauthorizedObjectResult("ESL does not recognize you.  Please Sign In.");
                
                // reference https://stackoverflow.com/questions/40217623/redirect-to-login-when-unauthorized-in-asp-net-core
                // RedirectToAction(LoginUrl);
            }
            else
            {
                // user SessionState as an indicator for where no keys found in the session.
                if (!HttpContext.Session.Keys.Any())  
                {
                    // set SessionState as New
                    if (string.IsNullOrEmpty(HttpContext.Session.GetString(SessionKeyUserSessionState)))
                    {
                        HttpContext.Session.SetString(SessionKeyUserSessionState, SessionState.New.ToString());                       
                    }

                    // set UserName to session
                    if (!string.IsNullOrEmpty(UserName))
                    {
                        // write to cookies user keys
                        HttpContext.Session.SetString(SessionKeyUserName, UserName);
                        HttpContext.Session.SetInt32(SessionKeyUserEmployeeNo, (int)UserEmployeeNo!);
                        HttpContext.Session.SetString(SessionKeyUserID, UserID!);

                        // set cookies to user browser
                        Response.Cookies.Append("UserId", UserID!);
                        Response.Cookies.Append("UserName", UserName);
                        Response.Cookies.Append("UserEmployeeNo", UserEmployeeNo!.ToString()!);
                    }

                    // check and migrate FacilNo as default if there are old cookies from previous session, 
                    if (!string.IsNullOrEmpty(Request.Cookies["FacilNo"]))
                    {
                        // read from cookies
                        // set FacilNo to session                       
                        HttpContext.Session.SetInt32(SessionKeyUserSelectedPlant, (int)FacilNo);
                    }

                    // flag the session as InProgress (authenticated, but need to check in == checkinflag: true)
                    HttpContext.Session.SetString(SessionKeyUserSessionState, SessionState.InProgress.ToString());
                    // direct to home/checkin action to check in with model loaded with user object, facilNo, and preset (default) ShiftNo, and OperatorType
                    RedirectToAction("CheckIn", "Home", new { ReturnUrl = this.Url });
                }
                else
                {
                    if (string.IsNullOrEmpty(HttpContext.Session.GetString(SessionKeyUserShiftNo)) || 
                        string.IsNullOrEmpty(HttpContext.Session.GetString(SessionKeyUserOperatorType)) ||
                        string.IsNullOrEmpty(HttpContext.Session.GetString(SessionKeyUserSelectedPlant)))
                    {
                        // flag the session as InProgress (authenticated, but need to check in == checkinflag: true)
                        HttpContext.Session.SetString(SessionKeyUserSessionState, SessionState.InProgress.ToString());
                        // direct to home/checkin action to check in with model loaded with user object, facilNo, and preset (default) ShiftNo, and OperatorType
                        RedirectToAction("CheckIn", "Home", new { ReturnUrl = this.Url });
                    }

                    HttpContext.Session.SetString(SessionKeyUserSessionState, SessionState.Valid.ToString());// read from cookiers
                }
            }

            base.OnActionExecuting(context);
        }

        #endregion Methods

        #region Helper

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

        protected static Enum GetDefaultShift() => Now.TimeOfDay >= TimeSpan.Parse(ShiftStartTimeString) && Now.TimeOfDay <= TimeSpan.Parse(ShiftEndTimeString) ? 
                                                    Core.Models.Enums.Shift.Day : Core.Models.Enums.Shift.Night;

        protected void SaveToSession(UserSessionViewModel model)
        {
            var session = _httpContextAccessor.HttpContext?.Session;
            if (session == null) return;

            session.SetString(SessionKeyUserSessionID, SessionID ?? string.Empty); // Fix for CS8604
            session.SetString(SessionKeyUserName, UserName ?? string.Empty); // Fix for CS8604  
            
            if (int.TryParse(model.UserID?[1..], out int _employeeNo))
            {
                // Save primary session data  
                session.SetString(SessionKeyUserID, model.UserID ?? string.Empty);
                session.SetInt32(SessionKeyUserEmployeeNo, model.EmployeeNo ?? 0);
                
                session.SetString(SessionKeyUserRole, model.UserRole ?? "Visitor");

                session.SetString(SessionKeyUserSessionState, SessionState.Valid.ToString());
                session.SetInt32(SessionKeyUserSelectedPlant, model.SelectedPlantId ?? 0);

                // Fix for CS8604  
                var shiftValue = (int)(model.SelectedShift ?? (Shift)GetDefaultShift());
                session.SetInt32(SessionKeyUserShiftNo, shiftValue);

                var operatorTypeValue = (int)(model.SelectedOperatorType ?? Core.Models.Enums.OperatorType.Primary);
                session.SetInt32(SessionKeyUserOperatorType, operatorTypeValue);

                session.SetString("Shift", model.SelectedShift?.ToString() ?? string.Empty); // Fix for CS8604  
                session.SetString("OperatorType", model.SelectedOperatorType?.ToString() ?? string.Empty); // Fix for CS8604  

                // Save plant related data  
                if (model.SelectedPlantId != 0)
                {
                    session.SetInt32("PlantId", model.SelectedPlantId ?? 0);
                    session.SetString("PlantName", PlantHelper.GetPlantName(model.SelectedPlantId ?? 0));
                }

                // Save timestamp for session tracking  
                session.SetString("SessionStartTime", DateTime.Now.ToString("o"));
            }
            else
            {
                // Handle the case where parsing fails, if necessary  
                throw new InvalidOperationException("Failed to parse UserID to an employee number.");
            }
        }

        #endregion Helper
    }
}
