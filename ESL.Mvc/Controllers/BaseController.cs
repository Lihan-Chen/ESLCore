using ESL.Core.Models;
using ESL.Core.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;
using Microsoft.Identity.Web;
using Microsoft.Identity.Abstractions;
using Microsoft.AspNetCore.Mvc.Filters;
using ESL.Core.Models.BusinessEntities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Graph;
using static System.Net.WebRequestMethods;
using Microsoft.Graph.CallRecords;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Http;
using ESL.Mvc.Services;

namespace ESL.Mvc.Controllers
{
    public class BaseController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public BaseController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        // Variables using Cap are globally accessible

        // User Authenticated by WIP (Windows Identity Protection)
        // https://learn.microsoft.com/en-us/answers/questions/804629/how-to-access-user-identity-in-basecontroller       
        public  bool IsAuthenticated => User.Identity!.IsAuthenticated;

        public static string UserSessionID; // => _httpContextAccessor.HttpContext.Session.Id;
        
        // Find username (LastName,FirstName) to get the User object from Oracle DbContext
        public string? UserName => User.Identity!.IsAuthenticated ? User.FindFirst(c => c.Type == "name")?.Value : string.Empty;      
        
        // SessionUser is the authenticated user that should have been recorded in the ESL_Employee table from Oracle ESL schema
        public static Employee? SessionUser { get; set; } // set by HomeController
        public static int? UserEmployeeNo => SessionUser?.EmployeeNo;
        public static string? UserID => SessionUser?.UID;

        // Shift Info
        public static string Shift = null!;  // Day or Night
        public static int ShiftNo; // 1 or 2
        public static string OperatorType = null!; // Primary or Secondary
        private static int SessionTimeOut = 30; // extends additional time for session

        // From SelectPlant
        public static string? FacilName;  // OCC
        public static int FacilNo = 0; // 0 for when a plant has not been selected

        //public bool SessionStates;
        public static SessionState UserSessionState;

        // SessionStates:
        //public bool SessionNew; // Referer = LoginUrl;
        //public bool SessionInProgress; // Set after Plant has been selected, and commited in basecontroller's OnActionExecuted
        //public bool SessionValid;
        //public bool SessionExpired;  // Timed out
        //public bool SessionLocked;
        

        // public bool UserStates       
        public bool UserLoggedIn => IsAuthenticated;
        public static bool IsOperator = false;
        public static bool IsAdmin = false;
        public static bool IsSuperAdmin = false;

        // a flag for redirect
        public static bool IsCheckingFacility;

        // Corresponds to Identity IsInRole(role) method
        //public bool IsInRole(string role);

        public const string Role_Admin = "ESL_ADMIN";
        public const string Role_SuperAdmin = "ESL_SUPERADMIN";
        public const string Role_Operator = "ESL_ADMIN";

        //public Shift _shift;
        //public string Shift = System.Web.HttpContext.Current.Session["ShiftNo"].ToString();
        public const String ShiftStartText = "06:00:00";  // for Day shift
        public const String ShiftEndText = "17:59:00";
        public DateTime Now = DateTime.Now;
        public DateTime Tomorrow = DateTime.Now.AddDays(+1);

        public int _pageSize = 40;

        public string YesterdayDate = System.DateTime.Now.AddDays(-1).ToString("MM/dd/yyyy");
        public string TodayDate = System.DateTime.Now.Date.ToString("yyyyMMdd");
        public string TomorrowDate = System.DateTime.Now.AddDays(+1).ToString("yyyyMMdd");
        public int _DaysOffSet = -2;
        // TimeSpan for two and half hours
        public System.TimeSpan TimeSpan = new System.TimeSpan(2, 30, 0);
        public bool OkToProceed = false;

        // note for coding
        public string LogOutUrl = $"/MicrosoftIdentity/Account/SignedOut";
        public string LoginUrl = $"https://login.microsoftonline.com/";

        public bool IsNewSession = true;

        // To be called from SetFacil in Home/SetFacil post
        //public UserSession? userSession = new UserSession()
        //{
        //    SessionID = UserSessionID,
        //    UserName = UserName,
        //    UserID = UserID,
        //    IsAuthenticated = true,
        //    // UserRole function not implemented yet
        //    UserRole = GetUserRole(UserID),
        //    ShiftNo = ShiftNo,
        //    OperatorType = OperatorType,
        //};

        private static string[] GetUserRole(string? userID)
        {
            throw new NotImplementedException();
        }

        // public const string SessionKeyUserSessioID = "_SessionID"; not needed because Session.Id always comes with Session
        public const string SessionKeyUserSessionState = "_SessionState";
        public const string SessionKeyUserName = "_UserName";
        public const string SessionKeyUserID = "_UserID";
        public const string SessionKeyUserEmployeeNo = "_UserEmployeeNo";
        // SelectedPlant can be persistent with expiry set for _sessionTimeOut (code in HomeController)
        public const string SessionKeyUserSelectedPlant = "_UserPlant";
        public const string SessionKeyUserShiftNo = "_UserShiftNo";
        public const string SessionKeyUserOpType = "_UserOpType";

        public class Emp
        {
            public string EmpID;
            public string Name;
        }

        public class EmpList : List<Emp>
        {
            public EmpList()
            { }
        }

        public class ESLUser
        {
            public string UserID;
            public string Name;
        }

        public class ESLUserList : List<ESLUser>
        {
            public ESLUserList()
            { }
        }

        public ESLUserList EList = new ESLUserList();

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // Current http request
            HttpContext ctx = context.HttpContext;

            if (!IsAuthenticated)
            {
                // HttpContext.SignOutAsync();
                RedirectToAction(LoginUrl);
            }
            else // IsAuthenticated
            {
                // https://stackoverflow.com/questions/32488523/what-does-it-mean-if-my-asp-net-session-has-isnewsession-true-and-should-i-c?rq=3

                // sample code for check session value, set value, and then redirect
                // https://learn.microsoft.com/en-us/answers/questions/665540/net-6-using-session-in-a-custom-class
                UserSessionID = HttpContext.Session.Id;

                // Default to not check Facility unless set true
                IsCheckingFacility = false;

                try
                {
                    // There should not be any keys for a new session (IsNewSession) on the server
                    if (!ctx.Session.Keys.Any()) 
                    {
                        // Flag SessionState as New
                        UserSessionState = SessionState.New;

                        // Check for cookie on the request from the browser
                        string sessionCookie = ctx.Request.Headers["Cookie"];

                        // if Request's Referer value is Microsoft login page, the it is definitely a new session (not used yet)
                        string returnUrl = ctx.Request.Headers["Referer"];

                        // ?????? flag the session new to continue to set up user session
                        //if (string.IsNullOrEmpty(HttpContext.Session.GetString(SessionKeyNew)))
                        //{
                        //    ctx.Session.SetString(SessionKeyNew, "true");

                        //    // need to clean up cookies 
                        //    //foreach (var cookie in Request.Cookies.Keys)
                        //    //{
                        //    //    Response.Cookies.Delete(cookie);
                        //    //}

                        //    if (string.IsNullOrEmpty(HttpContext.Session.GetString(SessionKeyUserSelectedPlant)))
                        //    {
                        //        // to set up plant and user info for userSession
                        //        RedirectToAction("Index", "Home");
                        //    }
                        //    else
                        //    {
                        //        // AllEvents
                        //        RedirectToAction("Index", "AllEvents");
                        //    }
                        //}

                        // If it is a new session, but an existing cookie exists, then it must have timed-out stale cookie
                        if ((!string.IsNullOrEmpty(sessionCookie) && sessionCookie.IndexOf(".ESL.Session") >= 0))
                        {
                            // If persistent cookie for _UserPlant exists, then capture it into FacilNo global variable;                       
                            ctx.Request.Cookies.TryGetValue(SessionKeyUserSelectedPlant, out string? _facilNoStr);
                            FacilNo = string.IsNullOrEmpty(_facilNoStr) ? Convert.ToInt32(_facilNoStr) : 0;

                            // And, set a session key for FacilNo
                            HttpContext.Session.SetInt32(SessionKeyUserSelectedPlant, FacilNo);
                            
                            // Reset ShiftNo and OperatorType before redirect to home/index to set up user session 
                            ShiftNo = 0;
                            OperatorType = String.Empty;

                            // Reset Shift and OperatorType Reset other cookies 
                            //foreach (var cookie in Request.Cookies.Keys)
                            //{
                            //    Response.Cookies.Delete(cookie);
                            //}

                            // Append SessionID to the new cookie (Option - user ASP.NET_SessionId?)
                            //Response.Cookies.Append("SessionID", UserSessionID);

                            
                        } // end of stale cookies that only facil is kept as persistent cookie for the new session

                        // Flag IsCheckingFacility to true and redirect to set facilNo, shiftNo, operatorType with a form adopted from login and plantmenu in Home/Index
                        // User is captured through authentication
                        IsCheckingFacility = FacilNo == 0;

                        RedirectToAction("Index", "Home");

                            // Additional reference codes -
                            //string redirectOnSuccess = ctx.Request.GetEncodedPathAndQuery();
                            //string redirectUrl = string.Format("?ReturnUrl={0}", redirectOnSuccess);
                            //string loginUrl = $"https://login.microsoftonline.com/" + redirectUrl; // corresponds to FormsAuthentication.LoginUrlMicrosoftIdentity/Account/SignOut

                            //Response.Redirect("/MicrosoftIdentity/Account/Signout");

                            // sample code for check session value, set value, and then redirect
                            // https://learn.microsoft.com/en-us/answers/questions/665540/net-6-using-session-in-a-custom-class
                            //string SessionKeyName = "logged";
                            //if (string.IsNullOrEmpty(HttpContext.Session.GetString(SessionKeyName)))
                            //{
                            //    HttpContext.Session.SetString(SessionKeyName, "notlogged");
                            //    //ViewData["mt"] = "notlogged";
                            //    Response.Redirect("./login");
                            //}

                            // HttpContext.SignOutAsync();                    
                    }
                    else // not new session, so read session keys into corresponding variables
                    {
                        //HttpContext.Session.SetString(SessionKeyUserName, UserName);
                        //HttpContext.Session.SetString(SessionKeyUserID, UserID);
                        //HttpContext.Session.SetInt32(SessionKeyUserEmployeeNo, (int)UserEmployeeNo);
                        if (IsSessionValid())
                        {
                            UserSessionState = SessionState.Valid;

                            // All the following must have been set for valid ESL user session
                            FacilNo = Convert.ToInt32(HttpContext.Session.GetInt32(SessionKeyUserSelectedPlant));
                            ShiftNo = Convert.ToInt32(HttpContext.Session.GetInt32(SessionKeyUserShiftNo));
                            OperatorType = HttpContext.Session.GetString(SessionKeyUserOpType);
                            //HttpContext.Session.SetString(SessionKeyUserName, UserName);
                            //HttpContext.Session.SetString(SessionKeyUserID, UserID);
                            //HttpContext.Session.SetInt32(SessionKeyUserEmployeeNo, (int)UserEmployeeNo);
                            //HttpContext.Session.SetInt32(SessionKeyUserSelectedPlant, FacilNo);
                            //HttpContext.Session.SetInt32(SessionKeyUserShiftNo, ShiftNo);
                            //HttpContext.Session.SetString(SessionKeyUserOpType, OperatorType);
                        }                   
                    }
                }              
                catch (Exception ex)
                {
                    // throw ex; //  new Exception
                    throw new ArgumentNullException();
                }
                finally
                {
                }    
            }

            base.OnActionExecuting(context);

            //try
            //{
            //    //if (ctx.Session.Keys.Count() > 6)
            //    //{

            //    //    SessionValid = IsSessionValid();
            //    //}
            //        // get data from session;

            //    //}
            //    //else // redirect to login if the used is logged in
            //    //{
            //    //    IsSessionValid = false;
            //    //    //TimeSpan _timeSpan = now - Convert.ToDateTime(ctx.Session.Keys["sessionStart"]);
            //    //    //ViewBag.Message = "Current session lasts for " + _timeSpan.ToString();
            //    //    //RedirectToAction("Login", "Account", new { returnUrl = this.Url });
            //    //}
            //}
            //catch (Exception ex)
            //{
            //    // throw ex; //  new Exception
            //    throw new ArgumentNullException();
            //}
            //finally
            //{
            //}
        
        }

        //int _facilNo;
        //    if (context.ActionArguments.TryGetValue("FacilNo", out _facilNo))
        //    {
        //        // _facilNo value was found => redirect to Home Index to set Facility and 
        //    }
        //    else
        //    {
        //        // _facilNo value was found

        

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // Code to run after the action method is executed
        }



        // https://medium.com/@M-B-A-R-K/how-to-read-action-method-parameters-using-iactionfilter-in-asp-net-core-mvc-16cc9ef6df9f#id_token=eyJhbGciOiJSUzI1NiIsImtpZCI6ImFiODYxNGZmNjI4OTNiYWRjZTVhYTc5YTc3MDNiNTk2NjY1ZDI0NzgiLCJ0eXAiOiJKV1QifQ.eyJpc3MiOiJodHRwczovL2FjY291bnRzLmdvb2dsZS5jb20iLCJhenAiOiIyMTYyOTYwMzU4MzQtazFrNnFlMDYwczJ0cDJhMmphbTRsamRjbXMwMHN0dGcuYXBwcy5nb29nbGV1c2VyY29udGVudC5jb20iLCJhdWQiOiIyMTYyOTYwMzU4MzQtazFrNnFlMDYwczJ0cDJhMmphbTRsamRjbXMwMHN0dGcuYXBwcy5nb29nbGV1c2VyY29udGVudC5jb20iLCJzdWIiOiIxMDk0OTg3MTI2MzAwODU3Nzk3NDMiLCJlbWFpbCI6ImFsdHAubmV0QGdtYWlsLmNvbSIsImVtYWlsX3ZlcmlmaWVkIjp0cnVlLCJuYmYiOjE3MzYwOTk5NzksIm5hbWUiOiJMaWhhbiBDaGVuIiwicGljdHVyZSI6Imh0dHBzOi8vbGgzLmdvb2dsZXVzZXJjb250ZW50LmNvbS9hL0FDZzhvY0tKa1JPVHBMSklqXzIzODJiMC1ZeGk2Y3RJU3pvTWI1ZTlTek53WUdXWHBIVG1nVi1KPXM5Ni1jIiwiZ2l2ZW5fbmFtZSI6IkxpaGFuIiwiZmFtaWx5X25hbWUiOiJDaGVuIiwiaWF0IjoxNzM2MTAwMjc5LCJleHAiOjE3MzYxMDM4NzksImp0aSI6ImU3MjdjZTAzZWE5YTRhZGMzNTJjM2QzZDRlOTZhODExMTI5MzY5NTMifQ.es-4dwesUrYD9GR8QZAX43-Ni2X9tLExacZ0hD_eK-NIp96WFu06wa-I69EXrAUjCCHtbtlfLVKu31TQX5f1ousWEAFUtXC18pcIxs0O8SdQve1jdSUPlhgQR1FRFMVy5GP9l--JeCZI1c4Uim6yaBwBBM2XasV1xoGVa6wpUlCXKU8_gX0w224InV13VZwN7iNDkZWZDVjxK3DTkZTVp6jj33WsaC0uWpZKZ4dJRHeKOPk-UlvuRVNlFlimGW5xnHeq29GdU_DU1J86U60Tb990GX80JVVLaN_mFQyWhO58omqp2o6j7IY4k6y81hfJ6gPMNDjbm_y0Z9Iyu-0LzQ
        //public class EslActionFilter : IActionFilter
        //{
        //    public void OnActionExecuting(ActionExecutingContext context)
        //    {
        //        string parameter1;
        //        if (context.ActionArguments.TryGetValue("parameter1", out parameter1))
        //        {
        //            // parameter1 value was found
        //        }
        //        else
        //        {
        //            // parameter1 value was not found
        //        }
        //    }
        //    public void OnActionExecuted(ActionExecutedContext context)
        //    {
        //        // Code to run after the action method is executed
        //    }
        //}

        public class LogActionFilter : IActionFilter
        {
            private readonly ILogger _logger;
            public LogActionFilter(ILogger<LogActionFilter> logger)
            {
                _logger = logger;
            }
            public void OnActionExecuting(ActionExecutingContext context)
            {
                // Log the action method name and parameters
                _logger.LogInformation("Executing action method {ActionName} with parameters:", context.ActionDescriptor.DisplayName);
                foreach (var parameter in context.ActionArguments)
                {
                    _logger.LogInformation("{ParameterName}: {ParameterValue}", parameter.Key, parameter.Value);
                }
            }
            public void OnActionExecuted(ActionExecutedContext context)
            {
                // Code to run after the action method is executed
            }
        }

        // to user filter
        //[Filter(typeof(LogActionFilter))]
        //public IActionResult MyAction(string parameter1, int parameter2)
        //{
        //    // Action method code
        //    return View();
        //}

        //public class ValidateActionFilter : IActionFilter
        //{
        //    public void OnActionExecuting(ActionExecutingContext context)
        //    {
        //        string parameter1;
        //        if (context.ActionArguments.TryGetValue("parameter1", out parameter1))
        //        {
        //            if (string.IsNullOrEmpty(parameter1))
        //            {
        //                context.Result = new BadRequestObjectResult("Parameter1 cannot be empty.");
        //            }
        //        }
        //    }
        //    public void OnActionExecuted(ActionExecutedContext context)
        //    {
        //        // Code to run after the action method is executed
        //    }
        //}

        // To use Validate
        //[Filter(typeof(ValidateActionFilter))]
        //public IActionResult MyAction(string parameter1, int parameter2)
        //{
        //    // Action method code
        //    return View();
        //}

        //public PrincipalContext context = new PrincipalContext(ContextType.Domain, "mwd.h2o");
        //public HttpContext _current = System.Web.HttpContext.Current;

        //[AppAuthorize]
        //protected void OnActionExecutingAsync(ActionExecutingContext filterContext)
        //{
        //    HttpContextBase ctx = filterContext.HttpContext;

        //    var httpContext = _httpContextAccessor.HttpContext;


        //    if (ctx.Session != null)
        //    {
        //        if (ctx.Session.IsNewSession)
        //        {
        //            // If it says it is a new session, but an existing cookie exists, then it must
        //            // have timed out
        //            string sessionCookie = ctx.Request.Headers["Cookie"];
        //            if ((null != sessionCookie) && (sessionCookie.IndexOf("ASP.NET_SessionId") >= 0))
        //            {
        //                string redirectOnSuccess = filterContext.HttpContext.Request.Url.PathAndQuery;
        //                string redirectUrl = string.Format("?ReturnUrl={0}", redirectOnSuccess);
        //                string loginUrl = FormsAuthentication.LoginUrl + redirectUrl;
        //                if (ctx.Request.IsAuthenticated)
        //                {
        //                    FormsAuthentication.SignOut();
        //                }
        //                RedirectResult rr = new RedirectResult(loginUrl);
        //                filterContext.Result = rr;
        //                //ctx.Response.Redirect("~/Home/Logon");
        //            }
        //        }

        //        base.OnActionExecuting(filterContext);

        //        try
        //        {
        //            UserLoggedIn = User.Identity.IsAuthenticated;

        //            if (IsSessionValid()) //(UserLoggedIn && HttpContext.Session["UserID"] == null)
        //            {
        //                // load session global variables from session variable
        //                GetUserFromSession();

        //                // CheckFacil = (Session["FacilName"] != null && CheckingFacility() !=  true ) ? false : true;
        //                // check if a facility is being selected (home/index)
        //                if (IsCheckingFacility == false)
        //                {
        //                    CheckSelectedFacility();
        //                }
        //            }
        //            else // redirect to login if the used is logged in
        //            {
        //                TimeSpan _timeSpan = now - Convert.ToDateTime(Session["sessionStart"]);
        //                ViewBag.Message = "Current session lasts for " + _timeSpan.ToString();
        //                RedirectToAction("Login", "Account", new { returnUrl = this.Url });
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            // throw ex; //  new Exception
        //            throw new ArgumentNullException();
        //        }
        //        finally
        //        {
        //        }
        //    }
        //}

        //protected override void OnActionExecuted(ActionExecutedContext filterContext)
        //{
        //    // Extend Session by resetting if FacilNo has been set
        //    if (FacilNo != 0)
        //    {
        //        if (SetUserSession().userLoggedIn == false) // userLoggedIn
        //        {
        //            SetUserSession();
        //        };
        //    }

        //    base.OnActionExecuted(filterContext);
        //}

        //protected override void OnException(ExceptionContext exceptionContext)
        //{
        //    if (exceptionContext.Exception is mySecurityException)
        //    {
        //        exceptionContext.ExceptionHandled = true;


        //        mySecurityExceptionex =
        //            exceptionContext.Exception as mySecurityException;


        //        this.View("~/Areas/Admin/Views/Errors/SecurityError.aspx", ex).
        //            ExecuteResult(this.ControllerContext);
        //    }
        //    else
        //    {
        //        exceptionContext.ExceptionHandled = true;


        //        this.View("~/Areas/Admin/Views/Errors/Error.aspx", exceptionContext.Exception).
        //            ExecuteResult(this.ControllerContext);
        //    }
        //}

        /// <summary>
        /// Load session global variables from session variables
        /// </summary>
        //protected virtual void GetUserFromSession()
        //{

        //    if (SessionValid) // UserLoggedIn and Session["UserID"] != null
        //    {
        //        UserName = GetUserNameFromOracle(UserID);

        //        UserID = System.Web.HttpContext.Current.Session["UserID"].ToString();

        //        Shift = System.Web.HttpContext.Current.Session["Shift"].ToString();

        //        ShiftNo = Shift == "Day" ? 1 : 2;
        //        OperatorType = System.Web.HttpContext.Current.Session["OperatorType"].ToString();
        //        UserLoggedIn = true;
        //    }
        //    else // from cookie
        //    {
        //        UserID = User.Identity.Name; // System.Web.HttpContext.Current.Request.Cookies["ESL"].Values["UserID"].ToString(); 
        //        UserName = GetUserNameFromOracle(UserID);
        //        Shift = "Day"; // System.Web.HttpContext.Current.Request.Cookies["ESL"].Values["Shift"].ToString();
        //        ShiftNo = Shift == "Day" ? 1 : 2;
        //        OperatorType = "Primary"; // System.Web.HttpContext.Current.Request.Cookies["ESL"].Values["OperatorType"].ToString();
        //        UserLoggedIn = true;
        //    }

        //    return;
        //}

        /// <summary>
        /// Initialize an instance of UserSession from session global variables
        /// </summary>
        /// <returns></returns>
        //protected virtual UserSession GetUserSession()
        //{
        //    UserSession _userSession = new UserSession
        //    {
        //        userID = UserID,
        //        userName = UserName,
        //        shiftNo = Shift == "Day" ? 1 : 2,
        //        shiftName = Shift,
        //        operatorType = OperatorType,
        //        isAdmin = IsAdmin,
        //        isSuperAdmin = IsSuperAdmin,
        //        userLoggedIn = UserLoggedIn
        //    };
        //    return _userSession;
        //}

        /// <summary>
        /// Initialize an instance of UserSession from LoginModel
        /// and reset session variables
        /// Used by AccountController (deprecated)
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        //protected virtual UserSession SetUserSession()
        //{
        //    UserSession _userSession = new UserSession
        //    {
        //        userID = UserID,
        //        userName = UserName,
        //        shiftNo = ShiftNo,
        //        shiftName = Shift,
        //        operatorType = OperatorType,
        //        isAdmin = IsAdmin,
        //        isSuperAdmin = IsSuperAdmin,
        //        userLoggedIn = UserLoggedIn
        //    };
        //}






        public virtual ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public virtual ActionResult RedirectWithMessage(string url, string msg)
        {
            ViewBag.Message = msg;
            ViewBag.RedirectUrl = url;

            if (Url.IsLocalUrl(url))
            {
                return Redirect(url);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // Taking all message from source log to pop up a message and then redirect to source log index page
        public virtual ActionResult MessageAlert(string redirectUrl, string msg)
        {
            string url = Url.Content(redirectUrl);
            // ? in asp.net core
            //HttpResponse.RemoveOutputCacheItem(url);
            ViewBag.Message = msg;
            ViewBag.RedirectUrl = redirectUrl;

            return View("MessageAlert");
        }

        //public virtual ActionResult RedirectToReferrer()
        //{
        //    return RedirectToAction(Request.UrlReferrer.ToString());
        //}

        public bool ShiftCheckPassed(int shiftNo)
        {
            bool _shiftCheckPassed = false;
            // for Day Shift
            DateTime _shiftStart = System.DateTime.Now.Date.AddHours(6);
            DateTime _shiftEnd = _shiftStart.AddHours(12).AddMinutes(30); // _shiftEnd is 12 hours and 30 minutes later than _shiftStart

            if (shiftNo == 2)
            {
                if (Now.Hour > _shiftEnd.Hour)  // example 10:00 p.m.
                {
                    _shiftStart = _shiftStart.AddHours(12); // Convert.ToDateTime(todayDate + " " + shiftEndText);
                }
                else // if (now.Hour <= _shiftStart.Hour)  // example 02:00 p.m.
                {
                    _shiftStart = _shiftStart.AddHours(-12);
                }
                _shiftEnd = _shiftStart.AddHours(12).AddMinutes(30);
            }

            if (Now > _shiftStart && Now <= _shiftEnd.Add(TimeSpan)) // two hours past the shift end time
            {
                _shiftCheckPassed = true;
            }

            return _shiftCheckPassed;
        }

        //public virtual void CheckSelectedFacility()
        //{
        //    if (Session["FacilName"] != null)
        //    {
        //        FacilName = Session["FacilName"].ToString();
        //        FacilNo = Convert.ToInt32(Session["FacilNo"]); // Similarly, GetFacilNo(FacilName) or FacilityManager.GetList().Where(f => f.FacilName.Split(' ').ElementAt(0) == FacilName).Select(f => f.FacilNo).FirstOrDefault();
        //        IsSuperAdmin = isSuperAdminfromOracle(UserID);
        //        IsAdmin = isAdminfromOracle(UserID);
        //        IsOperator = isOperatorfromOracle(UserID);
        //        // set flag so it does not have run again
        //        IsCheckingFacility = true;
        //    }
        //    else
        //    {
        //        FacilName = String.Empty;
        //        FacilNo = 0;
        //        IsCheckingFacility = false;

        //        RedirectToAction("Index", "Home", new { returnUrl = this.Url });
        //    }
        //}

        public virtual ISession GetSession()
        {
            return HttpContext.Session;
        }

        public virtual bool IsSessionValid()
        {
            bool _IsSessionValid = false;

            if (!string.IsNullOrEmpty(HttpContext.Session.GetString(SessionKeyUserSelectedPlant)))
            {
                int? _sessionSelectedPlant = Convert.ToInt32(HttpContext.Session.GetString(SessionKeyUserSelectedPlant));

                //HttpContext.Session.TryGetValue(SessionKeyUserName, out byte[]? _sessionUserName); // known
                HttpContext.Session.TryGetValue(SessionKeyUserID, out byte[]? _sessionUserID);
                //HttpContext.Session.TryGetValue(SessionKeyUserEmployeeNo, out byte[]? _sessionUserEmployeeNo); // not needed (duplicate)
                HttpContext.Session.TryGetValue(SessionKeyUserShiftNo, out byte[]? _sessionUserShiftNo);
                HttpContext.Session.TryGetValue(SessionKeyUserOpType, out byte[]? _sessionUserOpType);
                
                //string? _sessionUserName = HttpContext.Session.GetString(SessionKeyUserName);
                //string? _sessionUserID = HttpContext.Session.GetString(SessionKeyUserID);
                //int? _sessionUserEmployeeNo = HttpContext.Session.GetInt32(SessionKeyUserEmployeeNo);
                //int? _sessionSelectedPlant = Convert.ToInt32(HttpContext.Session.GetString(SessionKeyUserSelectedPlant));
                //int? _sessionShiftNo = Convert.ToInt32(HttpContext.Session.GetInt32(SessionKeyUserShiftNo));
                //int? _sessionOpType = Convert.ToInt32(HttpContext.Session.GetInt32(SessionKeyUserOpType));

                if (!IsAuthenticated && _sessionUserID is not null && _sessionSelectedPlant is not null && _sessionUserShiftNo is not null && _sessionUserOpType is not null)
                {
                    _IsSessionValid = true;
                }
            }
            
            return _IsSessionValid;
        }

    }
}
