using ESL.Core.Models.BusinessEntities;
using ESL.Core.Models.Enums;
using ESL.Mvc.DataAccess.Persistence;
using ESL.Mvc.Models;
using ESL.Mvc.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace ESL.Mvc.Controllers
{
    // https://www.youtube.com/watch?v=s4ysc9DneP8&t=103s
    public class BaseController<T> : Controller where T : BaseController<T>
    {
        private readonly EslDbContext _context;
        private ILogger<T>? _logger;
        // private IActionContextAccessor? _actionContextAccessor;
        private IEmployeeService _employeeService;

        // for future upgrade use of AutoMapper and Mediator
        // private IMapper? _mapper;
        //private IMediator? _mediator;

        public BaseController(EslDbContext context, ILogger<T> logger, IEmployeeService employeeService) // IActionContextAccessor actionContextAccessor, 
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            // _actionContextAccessor = actionContextAccessor;
            _employeeService = employeeService;
        }

        // Non DI version
        //protected ILogger<T> Logger
        //    => _logger ??= HttpContext.RequestServices.GetRequiredService<ILogger<T>>();  // GetService(typeof(ILogger<T>)) as ILogger<T>
        //protected IActionContextAccessor ActionContextAccessor
        //    => _actionContextAccessor ??= HttpContext.RequestServices.GetRequiredService<IActionContextAccessor>();

        //protected IMapper Mapper => _mapper ??= HttpContext.RequestServices.GetRequiredService<IMapper>();
        //protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<IMediator>();        
        
        #region Constants

        //Session Key Names
        protected const string SessionKeyUserSessionState = "_SessionState";
        protected const string SessionKeyUserName = "_UserName";
        protected const string SessionKeyUserID = "_UserID";
        protected const string SessionKeyUserEmployeeNo = "_UserEmployeeNo";
        protected const string SessionKeyUserSelectedPlant = "_UserPlant";
        protected const string SessionKeyUserShiftNo = "_UserShiftNo";
        protected const string SessionKeyUserOpType = "_UserOpType";
        protected const string SessionKeyUserShift = "_UserShift";
        protected const string SessionKeyUserSessionStartDate = "_StartDate";
        protected const string SessionKeyUserSessionEndDate = "_EndDate";

        protected const string LogOutUrl = $"/MicrosoftIdentity/Account/SignedOut";
        protected const string LoginUrl = $"https://login.microsoftonline.com/";

        protected const string Role_Admin = "ESL_ADMIN";
        protected const string Role_SuperAdmin = "ESL_SUPERADMIN";
        protected const string Role_Operator = "ESL_ADMIN";

        protected const String ShiftStartTimeString = "06:00:00";  // for Day shift
        protected const String ShiftEndTimeString = "17:59:00";

        #endregion constants

        #region properties

        // Session related properties
        protected bool IsAuthenticated => User.Identity!.IsAuthenticated;

        // Session.IsNew when there are no keys in the session
        protected bool IsNewSession { get; set; }

        protected string SessionID => HttpContext.Session.Id;

        protected string? UserName => User.Identity!.IsAuthenticated ? User.FindFirst(c => c.Type == "name")?.Value : string.Empty;

        // SessionUser is the authenticated user that should have been recorded in the ESL_Employee table from Oracle ESL schema
        protected Task<Employee?> SessionUser => _employeeService.GetEmployeeByEmployeeName(UserName!); // to be set by HomeController 

        protected int? UserEmployeeNo => SessionUser?.Result?.EmployeeNo;
        
        protected string? UserID => SessionUser?.Result?.UID;

        protected bool UserLoggedIn => IsAuthenticated;
        protected bool IsOperator = false;
        protected bool IsAdmin = false;
        protected bool IsSuperAdmin = false;

        // Current User Shift Information

        protected static string Shift = null!;  // Day or Night
        protected static int ShiftNo; // 1 or 2
        protected static string OperatorType = null!; // Primary or Secondary
        protected static int SessionTimeOut = 30; // extends additional time for session

        protected static DateTime Now = DateTime.Now;
        protected static DateOnly Today = DateOnly.FromDateTime(Now);
        protected static DateOnly Tomorrow = Today.AddDays(+1);
        protected string YesterdayDate = Today.AddDays(-1).ToString("MM/dd/yyyy");
        protected string TodayDate = Today.ToString("yyyyMMdd");
        protected string TomorrowDate = Tomorrow.ToString("yyyyMMdd");
        protected int DaysOffSet = -2;
        // TimeSpan for two and half hours
        protected TimeSpan TimeSpan = new TimeSpan(2, 30, 0);

        protected bool OkToProceed = false;

        protected int _pageSize = 40;

        // from cookies or query string
        protected  int? FacilNo { get; set; }
        //{
        //    get
        //    {
        //        if (int.TryParse(HttpContext.Request.Cookies["facilNo"], out int result))
        //        {
        //            return result;
        //        }
        //        return null;
        //    }
        //}

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
            // 1.if user is not authenticated, redirect to login
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
                // user SessionState as an indicator forwhere no keys found in the session.
                if (!HttpContext.Session.Keys.Any())  
                {
                    IsNewSession = true;
                    
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

                    // check and migrate old cookie values if there are old cookies from previous session, 

                    if (!string.IsNullOrEmpty(Request.Cookies["FacilNo"]))
                    {
                        // read from cookies
                        // set FacilNo to session
                        int _facilNo = int.Parse(HttpContext.Request.Cookies["FacilNo"]!);
                        
                        this.FacilNo = _facilNo;

                        HttpContext.Session.SetInt32(SessionKeyUserSelectedPlant, (int)this.FacilNo);
                    }

                    // to be directed to home/index/checkin action to check in with model loaded with user object, facilNo, and preset (default) ShiftNo, and OperatorType
                    // return RedirectToAction("Index", "Home", new { ReturnUrl = this.Url });
                }
                else
                {
                    // read from cookiers
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

        protected static Enum GetDefaultShift()
        {
            return Now.TimeOfDay >= TimeSpan.Parse(ShiftStartTimeString) && Now.TimeOfDay <= TimeSpan.Parse(ShiftEndTimeString) ? Core.Models.Enums.Shift.Day : Core.Models.Enums.Shift.Night;
        }

        #endregion Helper
    }
}
