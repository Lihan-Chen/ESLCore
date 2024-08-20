using ESL.Core.Models;
using ESL.Core.Models.ComplexTypes;
using ESL.Core.Models.Enums;
using System.Data;
using System.Net;
// using System.Text.RegularExpressions;

namespace ESL.Web.Controllers
{
    public class BaseController : Controller
    {
        // From LogIn 
        public string UserID; //U0XXXX
        public string UserName; // Firstname LastName
        public string Shift;  // Day or Night
        public int ShiftNo; // 1 or 2
        public string OperatorType; // Primary or Secondary
        private int _sessionTimeOut = 30; // extends additional time for session

        // From SelectPlant
        public string FacilName;  // OCC
        public int FacilNo; // 1
        
        public bool SessionValid;
        public bool UserLoggedIn;
        public bool IsAdmin;
        public bool IsSuperAdmin;
        public bool IsOperator;
        public bool IsCheckingFacility;

        public Shift _shift;
        // public string Shift = System.Web.HttpContext.Current.Session["ShiftNo"].ToString();
        public const String shiftStartText = "06:00:00";  // for Day shift
        public const String shiftEndText = "17:59:00";
        public DateTime now => DateTime.Now;
        public DateTime tomorrow => DateTime.Now.AddDays(+1);

        public int _pageSize = 40;
        
        public string yesterdayDate = System.DateTime.Now.AddDays(-1).ToString("MM/dd/yyyy");
        public string todayDate = System.DateTime.Now.Date.ToString("yyyyMMdd");
        public string tomorrowDate = System.DateTime.Now.AddDays(+1).ToString("yyyyMMdd");
        public int _daysOffSet = -2;
        // TimeSpan for two and half hours
        public System.TimeSpan timeSpan = new System.TimeSpan(2, 30, 0);
        public bool okToProceed = false;

        public UserSession? userSession;

        // To be replaced by UserInfo

        public record Emp: UserInfo { }

        public List<Emp> EmpList = new();

        public record ESLUser (string UserID, string Name);

        public List<ESLUser> EList = new();

        //ToDo: ?
        public PrincipalContext context = new(ContextType.Domain, "mwd.h2o");
        public HttpContext _current = System.Web.HttpContext.Current;
        // public UserPrincipal = UserPrincipal.FindByIdentity(context, System.Web.HttpContext.Current.User.Identity.Name);

        // public string defaultUserAcct = System.Web.HttpContext.Current.User.Identity.Name; // GetDefaultUserName(); // UserPrincipal.Current.SamAccountName;
        //String.IsNullOrEmpty(UserPrincipal.Current.SamAccountName) ? UserPrincipal.Current.SamAccountName : User.Identity.Name;

        //public class UserInSession
        //{
        //    public string userID;
        //    public string userName;
        //    public int shiftNo;
        //    public string shiftName;
        //    public string operatorType;
        //    public bool isAdmin;
        //    public bool isSuperAdmin;
        //    public int facilNo;
        //    public string facilName;
        //    public bool userLoggedIn;
        //}

        [AppAuthorize]
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpContextBase ctx = filterContext.HttpContext;

            if (ctx.Session != null)
            {
                if (ctx.Session.IsNewSession)
                {
                    // If it says it is a new session, but an existing cookie exists, then it must
                    // have timed out
                    string sessionCookie = ctx.Request.Headers["Cookie"];
                    if ((null != sessionCookie) && (sessionCookie.IndexOf("ASP.NET_SessionId") >= 0))
                    {
                        string redirectOnSuccess = filterContext.HttpContext.Request.Url.PathAndQuery;
                        string redirectUrl = string.Format("?ReturnUrl={0}", redirectOnSuccess);
                        string loginUrl = FormsAuthentication.LoginUrl + redirectUrl;
                        if (ctx.Request.IsAuthenticated)
                        {
                            FormsAuthentication.SignOut();
                        }
                        RedirectResult rr = new RedirectResult(loginUrl);
                        filterContext.Result = rr;
                        //ctx.Response.Redirect("~/Home/Logon");
                    }
                }

                base.OnActionExecuting(filterContext);

                try
                {
                    UserLoggedIn = User.Identity.IsAuthenticated;

                    if (IsSessionValid()) //(UserLoggedIn && HttpContext.Session["UserID"] == null)
                    {
                        // load session global variables from session variable
                        GetUserFromSession();

                        // CheckFacil = (Session["FacilName"] != null && CheckingFacility() !=  true ) ? false : true;
                        // check if a facility is being selected (home/index)
                        if (IsCheckingFacility == false)
                        {
                            CheckSelectedFacility();
                        }
                    }
                    else // redirect to login if the used is logged in
                    {
                        TimeSpan _timeSpan = now - Convert.ToDateTime(Session["sessionStart"]);
                        ViewBag.Message = "Current session lasts for " + _timeSpan.ToString();
                        RedirectToAction("Login", "Account", new { returnUrl = this.Url });
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
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            // Extend Session by resetting if FacilNo has been set
            if (FacilNo != 0)
            {
                if (SetUserSession().userLoggedIn == false) // userLoggedIn
                {
                    SetUserSession();
                };
            }
            
            base.OnActionExecuted(filterContext);
        }

        protected override void OnException(ExceptionContext exceptionContext)
        {
            //if (exceptionContext.Exception is mySecurityException)
            //{
            //    exceptionContext.ExceptionHandled = true;


            //    mySecurityExceptionex =
            //        exceptionContext.Exception as mySecurityException;


            //    this.View("~/Areas/Admin/Views/Errors/SecurityError.aspx", ex).
            //        ExecuteResult(this.ControllerContext);
            //}
            //else
            //{
            //    exceptionContext.ExceptionHandled = true;


            //    this.View("~/Areas/Admin/Views/Errors/Error.aspx", exceptionContext.Exception).
            //        ExecuteResult(this.ControllerContext);
            //}
        }

        public bool ShiftCheckPassed(int shiftNo)
        {
            bool _shiftCheckPassed = false;
            // for Day Shift
            DateTime _shiftStart = System.DateTime.Now.Date.AddHours(6);
            DateTime _shiftEnd = _shiftStart.AddHours(12).AddMinutes(30); // _shiftEnd is 12 hours and 30 minutes later than _shiftStart

            if (shiftNo == 2)
            {
                if (now.Hour > _shiftEnd.Hour)  // example 10:00 p.m.
                {
                    _shiftStart = _shiftStart.AddHours(12); // Convert.ToDateTime(todayDate + " " + shiftEndText);
                }
                else // if (now.Hour <= _shiftStart.Hour)  // example 02:00 p.m.
                {
                    _shiftStart = _shiftStart.AddHours(-12);
                }
                _shiftEnd = _shiftStart.AddHours(12).AddMinutes(30);
            }
                        
            if (now > _shiftStart && now <= _shiftEnd.Add(timeSpan)) // two hours past the shift end time
            {
                _shiftCheckPassed = true;
            }

            return _shiftCheckPassed;
        }

        //public virtual ActionResult OnSessionExpiryRedirectResult(ActionExecutingContext filterContext)
        //{
        //    return new RedirectToRouteResult(FormsAuthentication.LoginUrl.GetRouteValueDictionary());  //  // MVC.Account.LogOn()
        //}

        #region Helpers

        public virtual void CheckIfLoggedIn()
        {                                     
                // Read from session variables to set global variable values
                GetUserFromSession();
                // Session.Timeout = 2880;
        }
        
        public virtual void CheckSelectedFacility()
        {                       
            if (Session["FacilName"] != null)
            {
                FacilName = Session["FacilName"].ToString();
                FacilNo = Convert.ToInt32(Session["FacilNo"]); // Similarly, GetFacilNo(FacilName) or FacilityManager.GetList().Where(f => f.FacilName.Split(' ').ElementAt(0) == FacilName).Select(f => f.FacilNo).FirstOrDefault();
                IsSuperAdmin = isSuperAdminfromOracle(UserID);
                IsAdmin = isAdminfromOracle(UserID);
                IsOperator = isOperatorfromOracle(UserID);
                // set flag so it does not have run again
                IsCheckingFacility = true;
            }
            else
            {
                FacilName = String.Empty;
                FacilNo = 0;
                IsCheckingFacility = false;

                RedirectToAction("Index", "Home", new { returnUrl = this.Url });
            }
        }

        public virtual bool IsSessionValid()
        {
            bool _SessionValid = false;

            if (!User.Identity.IsAuthenticated || Session["UserID"] == null || Session["OperatorType"] == null || Session["Shift"] == null)
            {
                _SessionValid = false;
            }
            else
            {
                _SessionValid = true;
            }

            SessionValid = _SessionValid;

            return _SessionValid;
        }

        public virtual bool CheckingFacility()
        {
            bool _checkingFacilSelect;

            //if (Session["FacilName"] == null || Session["FacilNo"] == null) //  || IsCheckingFacility == true
            if (FacilNo == 0) //  || IsCheckingFacility == true
            {
                _checkingFacilSelect = true;
            }
            else
            {
                _checkingFacilSelect = false;
            }

            return _checkingFacilSelect;
        }

        public virtual string GetFacilName(int facilNo)
        {
            string _facilName = String.Empty;
            if (facilNo != 0)
            {
                _facilName = FacilityManager.GetItem(facilNo).FacilName.Split(' ').ElementAt(0);
            }

            FacilName = _facilName;

            return _facilName;
        }

        public virtual int GetFacilNo(string facilName)
        {
            int _facilNo = 0;
            if (!String.IsNullOrEmpty(facilName))
            {
                _facilNo = FacilityManager.GetList().AsEnumerable().Where(f => f.FacilName.Contains(facilName)).Select(x => x.FacilNo).FirstOrDefault(); //.Split(' ').ElementAt(0);
            }
            return _facilNo;
        }

        public virtual List<SelectListItem> GetFacilAbbrList()
        {
            var _selectItems = FacilityManager.GetList().AsEnumerable().Where(f => f.FacilNo <= 13).Select(f => new SelectListItem { Value = f.FacilNo.ToString(), Text = f.FacilAbbr }).ToList();
            return _selectItems;
        }

        public virtual List<SelectListItem> GetFacilTypes() // SelectListItem
        {
            var _facilTypes = FacilityManager.GetList().AsEnumerable().Select(f => f.FacilType).Distinct().Where(item => item != null);
            var _selectFacilTypes = _facilTypes.Select(x => new SelectListItem { Value = x.ToString(), Text = x.ToString() }).ToList();
            SelectListItem _emptyString = new SelectListItem() { Value = String.Empty, Text = String.Empty };
            _selectFacilTypes.Insert(0, _emptyString);
            // _selectMeterTypes.Add( _emptyString );

            return _selectFacilTypes;
        }
        
        public virtual List<SelectListItem> GetLogTypeNames()
        {
            var _selectItems = LogTypeManager.GetList().AsEnumerable().Where(l => l.LogTypeNo < 7).Select(l => new SelectListItem { Value = l.LogTypeNo.ToString(), Text = l.LogTypeName }).ToList(); 
            return _selectItems;
        }

        public virtual string GetLogTypeName(int logTypeNo)
        {
            LogType _logType  = LogTypeManager.GetItem(logTypeNo);

            return _logType.LogTypeName.Replace(" ", "");
        }

        public virtual List<SelectListItem> GetSubjectNames(int facilNo)
        {
            var _selectItems = SubjectManager.GetList(facilNo).AsEnumerable().OrderBy(l => l.SubjectName).Select(s => new SelectListItem { Value = s.SubjectNo.ToString(), Text = s.SubjectName }).ToList();
            return _selectItems;
        }

        public virtual List<SelectListItem> GetMeterTypes(int facilNo) // SelectListItem
        {
            var  _meterTypes = MeterManager.GetList(facilNo).AsEnumerable().Select(m => m.MeterType).Distinct().Where(item => item != null);
            var _selectMeterTypes = _meterTypes.Select(x => new SelectListItem { Value = x.ToString(), Text = x.ToString() }).ToList();
            SelectListItem _emptyString = new SelectListItem () { Value = String.Empty, Text = String.Empty };
            _selectMeterTypes.Insert(0, _emptyString);
            // _selectMeterTypes.Add( _emptyString );

            return _selectMeterTypes;
        }
               
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
            HttpResponse.RemoveOutputCacheItem(url);
            ViewBag.Message = msg;
            ViewBag.RedirectUrl = redirectUrl;

            return View("MessageAlert");
        }

        public virtual ActionResult RedirectToReferrer()
        {
            return RedirectToAction(Request.UrlReferrer.ToString());
        }

        // not used until 2008
        public UserPrincipal GetActiveDirectoryUser(string userName)
        {
            using (var ctx = new PrincipalContext(ContextType.Domain))
            using (var user = new UserPrincipal(ctx) { SamAccountName = userName })
            using (var searcher = new PrincipalSearcher(user))
            {
                return searcher.FindOne() as UserPrincipal;
            }
        }
        
        public virtual string GetUserName(String UserID)
        {
            string _userName = string.Empty;

            using (HostingEnvironment.Impersonate())
            {
                using (DirectoryEntry de = new DirectoryEntry("LDAP://mwd.h2o/DC=mwd,DC=h2o"))
                {
                    using (DirectorySearcher adSearch = new DirectorySearcher(de))
                    {
                        adSearch.Filter = "(sAMAccountName=" + UserID + ")";
                        SearchResult adSearchResult = adSearch.FindOne();
                        if (adSearchResult != null)
                        {
                            _userName = adSearchResult.Properties["cn"][0].ToString();

                            string[] _usrName = _userName.Split(',');
                            _userName = _usrName[1] + " " + _usrName[0];
                        }
                        else
                        {
                            _userName = GetUserNameFromOracle(UserID);
                        }
                    }
                }
                return _userName;
            }
        }

        public virtual string GetUserNameFromOracle(String UserID)
        {
            string _userName = string.Empty;
            int _userID = GetUserIDNumber(UserID); // Convert.ToInt32(UserID.Substring(UserID.Length-4));

            Employee _empOracle = EmployeeManager.GetItem(_userID);

            if (_empOracle != null)
            {
                _userName = _empOracle.FirstName + " " + _empOracle.LastName;
            }

            return _userName; 
        }

        //public static string GetDefaultUserName()
        //{
        //    string _userName = new HttpContext.User.Identity.Name;
        //    string _domain = "mwd.h2o";
        //    string _admin = "G_MWDESL_Mgrs";
        //    PrincipalContext context = new PrincipalContext(ContextType.Domain, _domain);
        //    UserPrincipal user = UserPrincipal.FindByIdentity(context, HttpContext.User.Identity.Name); // UserPrincipal.FindByIdentity(context, IdentityType.SamAccountName, UserID);

        //    _userName = user.Name;

        //    return _userName;
        //}

        
        public virtual Int32 GetUserIDNumber(String UserID)
        {
            int digits = 4;
            digits = UserID.ToUpper().Contains("U0") ? digits : digits + 1;

            return Convert.ToInt32(UserID.Substring(UserID.Length - digits));
        }

        public virtual string GetUserIDString(String ID)
        {
            int digits = 4;
            digits = ID.ToUpper().Contains("U0") ? digits : digits + 1;
            return ID.Substring(UserID.Length - digits);
        }

        public virtual bool isAdmin(String UserID)
        {
            Boolean _isAdmin = false;
            string _domain = "mwd.h2o";
            string _admin = "G_MWDESL_Mgrs";
            PrincipalContext context = new PrincipalContext(ContextType.Domain, _domain);
            UserPrincipal user = UserPrincipal.FindByIdentity(context, HttpContext.User.Identity.Name); // UserPrincipal.FindByIdentity(context, IdentityType.SamAccountName, UserID);

            if (user != null)
            {
                //var groups = user.GetAuthorizationGroups();

                // enumerate over groups
                //foreach (GroupPrincipal gp in groups)
                //{
                using (HostingEnvironment.Impersonate())
                {
                    using (DirectoryEntry de = new DirectoryEntry("LDAP://mwd.h2o/DC=mwd,DC=h2o"))
                    {
                        try
                        {
                            if (user.IsMemberOf(context, IdentityType.Name, _admin) || UserID == "7829" || UserID == "7822" )  // 7829: George; 7822: Alex for testing
                            {
                                Session["isAdmin"] = true;
                                return true;
                            }
                        }
                        catch
                        {
                            Session["isAdmin"] = false;
                        }

                        return _isAdmin;
                    }
                }
                //}
            }

            return _isAdmin;
        }

        public virtual bool isAdminfromOracle(string UserID)
        {
            int _facilNo = FacilNo;
            bool _admin = false;
            string _roleName = "ESL_ADMIN";

            //if (_facilNo != 0)
            //{
            _admin = _roleName == EmployeeManager.GetRole(UserID, _facilNo) || isSuperAdminfromOracle(UserID);
            // _admin = (UserID == "u06337" || UserID == "u07519" || UserID == "u07829") ? true : false;
            //}

            //if (_admin && !Roles.IsUserInRole(_roleName))
            //{
            //        Roles.AddUserToRole(UserID, _roleName);
            //}

            IsAdmin = _admin;
            Session["isAdmin"] = _admin;
            
            return _admin;
        }

        public virtual bool isSuperAdminfromOracle(string UserID)
        {
            int _facilNo = FacilNo;
            bool _admin = false;
            string _roleName = "ESL_SUPERADMIN";

            //if (_facilNo != 0)
            //{
                _admin = _roleName == EmployeeManager.GetRole(UserID, _facilNo);
                // _admin = (UserID == "u06337" || UserID == "u07519") ? true : false;
            //}

            //if (_admin && !Roles.IsUserInRole(_roleName))  
            //{
            //        Roles.AddUserToRole(UserID, _roleName);
            //}

            IsSuperAdmin = _admin;
            Session["isSuperAdmin"] = _admin;
            
            return _admin;
        }

        public virtual bool isOperatorfromOracle(string UserID)
        {
            int _facilNo = FacilNo;
            bool _operator = false;
            var _roleList = new List<string>();
	        _roleList.Add("ESL_OPERATOR");
	        _roleList.Add("ESL_ADMIN");
	        _roleList.Add("ESL_SUPERADMIN");
            // string _roleName = "ESL_OPERATOR, ESL_ADMIN, ESL_SUPERADMIN";

            _operator = _roleList.Contains(EmployeeManager.GetRole(UserID, _facilNo)); //isAdminfromOracle(UserID)||  IsAdmin; 

            //if (_operator && !Roles.IsUserInRole(_roleName))
            //{
            //        Roles.AddUserToRole(UserID, _roleName);
            //}
            
            IsOperator = _operator;
            Session["isOperator"] = _operator;

            return _operator;
            //return _roleName == EmployeeManager.GetRole(UserID, _facilNo) || isAdminfromOracle(UserID) || UserID == "7822";
        }

        public virtual EmpList GetUsers()
        {
            EmpList _empList = new EmpList();
            List<UserPrincipal> result = new List<UserPrincipal>();

            using (HostingEnvironment.Impersonate())
            {
                try
                {
                    using (DirectoryEntry de = new DirectoryEntry("LDAP://mwd.h2o/OU=Group-Water System Operations,OU=Computers and Users,DC=mwd,DC=h2o"))  // OU=Group-Water System Operations,OU=Computers and Users,DC=mwd,DC=h2o
                    {
                        string filter = "(&(objectCategory=person)(objectClass=user)(sAMAccountName=u0*)(!userAccountControl:1.2.840.113556.1.4.803:=2))"; // (memberOf:1.2.840.113556.1.4.1941:=OU=Group-Water System Operations) //(OU=Group-Water System Operations);(!objectClass=*SVC*)(memberOf=CN=Group-Water System Operations,OU=Computers and Users,DC=mwd,DC=h2o)(CN=Water System Operations)
                        string[] propertiesToLoad = new string[3] { "SamAccountName", "name", "UserPrincipalName" }; // for {EmpID, Name, EmailAddress} UserPrincipalName
                        using (DirectorySearcher adSearch = new DirectorySearcher(de, filter, propertiesToLoad))
                        {
                            adSearch.PageSize = 1000;
                            // adSearch.SizeLimit = 0;
                            adSearch.Sort.PropertyName = propertiesToLoad[0];
                            adSearch.Sort.Direction = SortDirection.Ascending;
                            SearchResultCollection adSearchResults = adSearch.FindAll();

                            if (adSearchResults != null)
                            {
                                int i = 0;
                                //int n = 0;
                                foreach (SearchResult adSearchResult in adSearchResults)
                                {
                                    Emp e = new Emp();
                                    e.Name = adSearchResult.Properties["name"][i].ToString();
                                    e.EmpID = adSearchResult.Properties["SamAccountName"][i].ToString();
                                    //if (n != 555)  // for some weird reason this user u06115 causes indexing out of bound error
                                    //{
                                    //if (!String.IsNullOrEmpty(adSearchResult.Properties["UserPrincipalName"][i].ToString()))
                                    if (adSearchResult.Properties["UserPrincipalName"][i] != null)
                                    {
                                        e.EmailAddress = adSearchResult.Properties["UserPrincipalName"][i].ToString();
                                    }
                                    _empList.Add(e);
                                    //}
                                    //n += 1;                               
                                }
                            }
                        }
                        Dispose();
                    }
                }
                catch (WebException ex)
                {
                    using (var stream = ex.Response.GetResponseStream())
                    using (var reader = new StreamReader(stream))
                    {
                        string text = reader.ReadToEnd();
                        // text will contain the response from the server
                        // return RedirectToAction("Index", "Home");
                    }
                }

                return _empList;
            }
        }

        public virtual ESLUserList GetESLUsers()
        {
            ESLUserList _eslUserList = new ESLUserList();
            List<UserPrincipal> result = new List<UserPrincipal>();

            using (HostingEnvironment.Impersonate())
            {
                try
                {
                    using (DirectoryEntry de = new DirectoryEntry("LDAP://mwd.h2o/OU=Group-Water System Operations,OU=Computers and Users,DC=mwd,DC=h2o"))  // OU=Group-Water System Operations,OU=Computers and Users,DC=mwd,DC=h2o
                    {
                        string filter = "(&(objectCategory=person)(objectClass=user)(sAMAccountName=u0*)(!userAccountControl:1.2.840.113556.1.4.803:=2))"; // (memberOf:1.2.840.113556.1.4.1941:=OU=Group-Water System Operations) //(OU=Group-Water System Operations);(!objectClass=*SVC*)(memberOf=CN=Group-Water System Operations,OU=Computers and Users,DC=mwd,DC=h2o)(CN=Water System Operations)
                        string[] propertiesToLoad = new string[3] { "SamAccountName", "name", "UserPrincipalName" }; // for {EmpID, Name, EmailAddress} UserPrincipalName
                        using (DirectorySearcher adSearch = new DirectorySearcher(de, filter, propertiesToLoad))
                        {
                            adSearch.PageSize = 1000;
                            // adSearch.SizeLimit = 0;
                            adSearch.Sort.PropertyName = propertiesToLoad[0];
                            adSearch.Sort.Direction = SortDirection.Ascending;
                            SearchResultCollection adSearchResults = adSearch.FindAll();

                            if (adSearchResults != null)
                            {
                                int i = 0;
                                foreach (SearchResult adSearchResult in adSearchResults)
                                {
                                    ESLUser e = new ESLUser();
                                    e.Name = adSearchResult.Properties["name"][i].ToString();
                                    e.UserID = adSearchResult.Properties["SamAccountName"][i].ToString().Substring(2);
                                    
                                    _eslUserList.Add(e);                               
                                }
                            }
                        }
                        Dispose();
                    }
                }
                catch (WebException ex)
                {
                    _eslUserList.Clear();
                    using (var stream = ex.Response.GetResponseStream())
                    using (var reader = new StreamReader(stream))
                    {
                        string text = reader.ReadToEnd();
                    }
                }

                return _eslUserList;
            }
        }

        // Oracle
        // keep the result cached on web server and client for 12 hours
        // [OutputCache(Duration = 43200, VaryByParam = "none", Location = OutputCacheLocation.Client, NoStore = true)]
        // or CacheProfile in web.config
        // [OutputCache(CacheProfile = "Cache12Hours", Location = OutputCacheLocation.Server, NoStore = false)]
        // [OutputCache(CacheProfile = "Cache1Hour", Location = OutputCacheLocation.Server, NoStore = false)]
        public virtual ESLUserList GetESLUsersOracle(int facilNo)
        {
            string _company;
            ESLUserList _eslUserList = new ESLUserList();

            var _empListOracle = EmployeeManager.GetListByFacilNo(facilNo).OrderBy( f => f.LastName).AsEnumerable();

            if (_empListOracle != null)
            {
                foreach (Employee emp in _empListOracle)
                {
                    _company = emp.Company;
                    ESLUser e = new ESLUser();
                    e.Name = emp.LastName + ", " + emp.FirstName;
                    if (emp.Company != "MWD")
                    {
                        e.Name = e.Name + " - " + emp.Company;
                    }
                    e.UserID = emp.EmployeeNo.ToString();
                    
                    _eslUserList.Add(e);                          
                }
            }

            return _eslUserList;
        }

        

        // Oracle
        // keep the result cached on web server and client for 12 hours
        // [OutputCache(Duration = 43200, VaryByParam = "none", Location = OutputCacheLocation.Client, NoStore = true)]
        // or CacheProfile in web.config
        [OutputCache(CacheProfile = "Cache12Hours", Location = OutputCacheLocation.Server, NoStore = false)]
        public virtual ESLUserList GetESLUsersExternalOracle()
        {
            ESLUserList _eslUserList = new ESLUserList();

            var _empListOracle = EmployeeManager.GetListExternal().OrderBy(f => f.LastName).AsEnumerable();

            if (_empListOracle != null)
            {
                foreach (Employee emp in _empListOracle)
                {
                    ESLUser e = new ESLUser();
                    e.Name = emp.LastName + ", " + emp.FirstName;
                    e.UserID = emp.EmployeeNo.ToString();

                    _eslUserList.Add(e);
                }
            }

            return _eslUserList;
        }

        // [OutputCache(Duration = int.MaxValue, VaryByParam = "UserID")]
        [OutputCache(Duration = 43200, VaryByParam = "UserID")]
        public virtual List<GroupPrincipal> GetGroups(String UserID)
        {
            string _domain = "mwd.h2o";
            var context = new PrincipalContext(ContextType.Domain, _domain);
            var userPrincipal = UserPrincipal.FindByIdentity(context, IdentityType.SamAccountName, UserID); // IdentityType.Name, "PowerUsers");// httpContext.User.Identity.Name;

            List<GroupPrincipal> result = new List<GroupPrincipal>();

            // if found - grab its groups
            if (userPrincipal != null)
            {
                PrincipalSearchResult<Principal> groups = userPrincipal.GetAuthorizationGroups();  // This allows recursive search through nested groups

                // iterate over all groups
                foreach (Principal p in groups)
                {
                    // make sure to add only group principals
                    if (p is GroupPrincipal)
                    {
                        result.Add((GroupPrincipal)p);
                    }
                }
            }

            return result;
        }

        // TODO: replace various selectLists with this generic employeeSelectList
        public virtual SelectList GetEmployeeSelectList(FlowChange myFlowChange)
        {
            string _selectedEmpNo = myFlowChange.UpdatedBy;

            SelectList _employeeSelectList;
            
            var myEmployeeList = EmployeeManager.GetList().AsEnumerable().Select(e => new SelectListItem { Value = e.EmployeeNo.ToString(), Text = e.LastName + ", " + e.FirstName + " - " + e.Company }).ToList(); //.Where(e => e.FacilNo = _facilNo)

            if (myEmployeeList != null)
            {
                _employeeSelectList = new SelectList(myEmployeeList, "Value", "Text", myFlowChange.UpdatedBy);
            }
            else
            {
                _employeeSelectList = null;
            }

            return _employeeSelectList;
        }

        protected SelectListItem[] GetEmpSelectListItem(string empID)
        {
            int _empID = Convert.ToInt32(empID);

            var _selectItems = GetUsers().Select(e =>
                                new SelectListItem
                                {
                                    Value = e.EmpID.ToString(),
                                    Text = e.Name,
                                    Selected = (e.EmpID == empID)
                                });

            return (SelectListItem[])_selectItems;
        }

        protected virtual ESLUserList InitializeESLUserListItem()
        {
            var _selectItems = GetESLUsers().AsQueryable().OrderBy(e => e.UserID);

            return (ESLUserList)_selectItems;
        }

        /// <summary>
        /// Load session global variables from session variables
        /// </summary>
        protected virtual void GetUserFromSession()
        {
            if (SessionValid) // UserLoggedIn and Session["UserID"] != null
            {
                UserID = System.Web.HttpContext.Current.Session["UserID"].ToString();
                UserName = GetUserNameFromOracle(UserID);
                Shift = System.Web.HttpContext.Current.Session["Shift"].ToString();
                ShiftNo = Shift == "Day" ? 1 : 2;
                OperatorType = System.Web.HttpContext.Current.Session["OperatorType"].ToString();
                UserLoggedIn = true;
            }
            else // from cookie
            {
                UserID = User.Identity.Name; // System.Web.HttpContext.Current.Request.Cookies["ESL"].Values["UserID"].ToString(); 
                UserName = GetUserNameFromOracle(UserID);
                Shift = "Day"; // System.Web.HttpContext.Current.Request.Cookies["ESL"].Values["Shift"].ToString();
                ShiftNo = Shift == "Day" ? 1 : 2;
                OperatorType = "Primary"; // System.Web.HttpContext.Current.Request.Cookies["ESL"].Values["OperatorType"].ToString();
                UserLoggedIn = true;
            }            
            
            return;
        }

        /// <summary>
        /// Initialize an instance of UserSession from session global variables
        /// </summary>
        /// <returns></returns>
        protected virtual UserSession GetUserSession()
        { 
            UserSession _userSession = new UserSession            
            {
                userID = UserID,
                userName = UserName,
                shiftNo = Shift == "Day" ? 1 : 2,
                shiftName = Shift,
                operatorType = OperatorType,
                isAdmin = IsAdmin,
                isSuperAdmin = IsSuperAdmin,
                userLoggedIn = UserLoggedIn
            };
            return _userSession;
        }

        /// <summary>
        /// Initialize an instance of UserSession from LoginModel
        /// and reset session variables
        /// Used by AccountController (deprecated)
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        protected virtual UserSession SetUserSession()
        {           
            UserSession _userSession = new UserSession
            {
                userID = UserID,
                userName = UserName,
                shiftNo = ShiftNo,
                shiftName = Shift,
                operatorType = OperatorType,
                isAdmin = IsAdmin,
                isSuperAdmin = IsSuperAdmin,
                userLoggedIn = UserLoggedIn
            };

            System.Web.HttpContext.Current.Session["UserID"] = UserID;
            System.Web.HttpContext.Current.Session["UserName"] = UserName;
            System.Web.HttpContext.Current.Session["ShiftNo"] = ShiftNo;
            System.Web.HttpContext.Current.Session["Shift"] = Shift;
            System.Web.HttpContext.Current.Session["OperatorType"] = OperatorType;
            System.Web.HttpContext.Current.Session["IsAdmin"] = IsAdmin;
            System.Web.HttpContext.Current.Session["IsSuperAdmin"] = IsSuperAdmin;
            System.Web.HttpContext.Current.Session["UserLoggedIn"] = UserLoggedIn;
            // extends session for another 30 minutes
            // System.Web.HttpContext.Current.Session.Timeout += _sessionTimeOut;

            return _userSession;
        }

        //protected virtual UserInSession SetUserInSession()
        //{
        //    UserInSession _userInSession = new UserInSession()
        //    {
        //        userID = Session["UserID"].ToString(),
        //        userName = Session["UserName"].ToString(),
        //        shiftName = Convert.ToInt32(Session["Shift"]) == 1 ? "Day" : "Night", // Session["Shift"].ToString(),
        //        shiftNo = Convert.ToInt32(Session["Shift"]), // Session["Shift"].ToString() == "Day" ? 1 : 2,
        //        operatorType = Session["OperatorType"].ToString(), //primary = Session["OperatorType"].ToString() == "Primary" ? true : false,
        //        //facilName = Session["FacilName"].ToString(),
        //        //facilNo = Convert.ToInt32(Session["FacilNo"]),
        //        isAdmin = isAdminfromOracle(UserID), //Convert.ToBoolean(Session["IsAdmin"])
        //        isSuperAdmin = isSuperAdminfromOracle(UserID),
        //        userLoggedIn = true

        //        //UserInSession userSession = new UserInSession()
        //        //{
        //        //    userID = Session["UserID"].ToString(),
        //        //    userName = Session["UserName"].ToString(),
        //        //    shiftName = Session["Shift"].ToString(),
        //        //    operatorType = Session["OperatorType"].ToString(),
        //        //    isAdmin = isAdminfromOracle(UserID),
        //        //    userLoggedIn = true
        //        //};
        //    };

        //    return _userInSession;
        //}

        private string GetRouteInfo(string facil, string method)
        {
            string returnedString = facil;
            returnedString += "/" + ControllerContext.RouteData.Values["Controller"].ToString();
            returnedString += "/" + method;

            return returnedString;
        }

        private string GetRouteInfo(string facil, string eventID, int eventID_RevNo, string method)
        {
            string returnedString = facil;
            returnedString += "/" + ControllerContext.RouteData.Values["Controller"].ToString();
            returnedString += "/" + method;
            returnedString += String.IsNullOrEmpty(eventID) ? null : "/" + eventID;
            returnedString += eventID_RevNo == 0 ? string.Empty : "/" + eventID_RevNo.ToString();

            return returnedString;
        }
        
        //Example: passing Json to view to generate selectList
        // [GET("SelectList")]
        //public ActionResult ESLUserSelectList()
        //{
        //    ESLUserList eList = GetESLUsers();

        //    var elist = eList.AsQueryable().OrderBy(e => e.EmpID); //;

        //    return Json(elist, JsonRequestBehavior.AllowGet);

        //    // return [{"EmpID":6337,"Name":"Lihan Chen"},{"EmpID":7519,"Name":"Evan Ho"},{"EmpID":7822,"Name":"Alex Pop"}]
        //}


        [OutputCache(CacheProfile = "1Hours", VaryByParam = "facilAbbr", Location = OutputCacheLocation.Server, NoStore = false)]
        public virtual LocList GetLocList(string facilAbbr)
        {
            LocList _locList = new LocList();

            if (FacilityManager.GetLocationList(facilAbbr) != null)
            {
                var _locationListOracle = FacilityManager.GetLocationList(facilAbbr).OrderBy(l => l.FacilAbbr).AsEnumerable();

                if (_locationListOracle != null)
                {
                    foreach (Location location in _locationListOracle)
                    {
                        Loc l = new Loc();
                        l.FacilNo = location.FacilNo;
                        l.FacilAbbr = location.FacilAbbr;
                        l.FacilName = location.FacilName;

                        _locList.Add(l);
                    }
                }
            }

            return _locList;
        }

        [OutputCache(CacheProfile = "1Hours", VaryByParam = "facilNo", Location = OutputCacheLocation.Server, NoStore = false)]
        public virtual SubjList GetSubjectList(int facilNo)
        {
            SubjList _subjList = new SubjList();

            if (AllEventManager.GetSubjectList(facilNo) != null)
            {
                var _subjectListOracle = AllEventManager.GetSubjectList(facilNo).OrderBy(s => s.SubjectName).AsEnumerable();

                if (_subjectListOracle != null)
                {
                    foreach (Subject subject in _subjectListOracle)
                    {
                        Subj s = new Subj();
                        s.FacilNo = subject.FacilNo;
                        s.SubjectNo = subject.SubjectNo;
                        s.SubjectName = subject.SubjectName;
                        s.FacilType = subject.FacilType;

                        _subjList.Add(s);
                    }
                }
            }

            return _subjList;
        }

        [OutputCache(CacheProfile = "1Hours", VaryByParam = "facilNo", Location = OutputCacheLocation.Server, NoStore = false)]
        public virtual DtlList GetDetailsList(int facilNo)
        {
            DtlList _dtlList = new DtlList();

            if (AllEventManager.GetDetailsList(facilNo) != null)
            {
                var _dtlListOracle = AllEventManager.GetDetailsList(facilNo).OrderBy(d => d.DetailsName).AsEnumerable();

                if (_dtlListOracle != null)
                {
                    foreach (Details details in _dtlListOracle)
                    {
                        Dtl d = new Dtl();
                        d.FacilNo = details.FacilNo;
                        d.DetailsNo = details.DetailsNo;
                        d.DetailsName = details.DetailsName;
                        d.FacilType = details.FacilType;
                        d.SubjectNo = details.SubjectNo;
                        //d.SubjectName = details.SubjectName;

                        _dtlList.Add(d);
                    }
                }
            }

            return _dtlList;
        }

        [OutputCache(CacheProfile = "1Hours", VaryByParam = "facilNo", Location = OutputCacheLocation.Server, NoStore = false)]
        public virtual ClearanceZoneList GetClearanceZoneList(int facilNo)
        {
            ClearanceZoneList _clearanceZoneList = new ClearanceZoneList();

            if (ClearanceZoneManager.GetClearanceZoneList(facilNo) != null)
            {
                var _clearanceZoneListOracle = ClearanceZoneManager.GetClearanceZoneList(facilNo).OrderBy(l => l.ZoneDescription).AsEnumerable();

                if (_clearanceZoneListOracle != null)
                {
                    foreach (ClearanceZone clearanceZone in _clearanceZoneListOracle)
                    {
                        ClearanceZone z = new ClearanceZone();
                        z.FacilType = clearanceZone.FacilType;
                        z.ZoneNo = clearanceZone.ZoneNo;
                        z.ZoneDescription = clearanceZone.ZoneDescription;

                        _clearanceZoneList.Add(z);
                    }
                }
            }

            return _clearanceZoneList;
        }

        [OutputCache(CacheProfile = "1Hours", VaryByParam = "facilNo", Location = OutputCacheLocation.Server, NoStore = false)]
        public virtual WorkToBePerformedList GetWorkToBePerformedList(int facilNo)
        {
            WorkToBePerformedList _workToBePerformedList = new WorkToBePerformedList();

            if (WorkManager.GetWorkToBePerformedList(facilNo) != null)
            {
                var _workToBePerformedListOracle = WorkManager.GetWorkToBePerformedList(facilNo).OrderBy(l => l.WorkDescription).AsEnumerable();

                if (_workToBePerformedListOracle != null)
                {
                    foreach (WorkToBePerformed workToBePerformed in _workToBePerformedListOracle)
                    {
                        WorkToBePerformed w = new WorkToBePerformed();
                        w.FacilType = workToBePerformed.FacilType;
                        w.WorkNo = workToBePerformed.WorkNo;
                        w.WorkDescription = workToBePerformed.WorkDescription;

                        _workToBePerformedList.Add(w);
                    }
                }
            }

            return _workToBePerformedList;
        }

        [OutputCache(CacheProfile = "1Hours", VaryByParam = "facilNo", Location = OutputCacheLocation.Server, NoStore = false)]
        public virtual EquipmentInvolvedList GetEquipmentInvolvedList(int facilNo)
        {
            EquipmentInvolvedList _equipmentInvolvedList = new EquipmentInvolvedList();

            if (EquipmentInvolvedManager.GetEquipmentInvolvedList(facilNo) != null)
            {
                var _equipmentInvolvedListOracle = EquipmentInvolvedManager.GetEquipmentInvolvedList(facilNo).OrderBy(l => l.EquipName).AsEnumerable();

                if (_equipmentInvolvedListOracle != null)
                {
                    foreach (EquipmentInvolved equipmentInvolved in _equipmentInvolvedListOracle)
                    {
                        EquipmentInvolved e = new EquipmentInvolved();
                        e.FacilNo = equipmentInvolved.FacilNo;
                        e.EquipNo = equipmentInvolved.EquipNo;
                        e.EquipName = equipmentInvolved.EquipName;

                        _equipmentInvolvedList.Add(e);
                    }
                }
            }

            return _equipmentInvolvedList;
        }

        public ActionResult UploadFile(int facilNo, int logTypeNo, string eventID, IEnumerable<HttpPostedFileBase> files)
        {
            foreach (var file in files)
            {
                if (file.ContentLength > 0)
                {
                    string fileName = Path.GetFileName(file.FileName);
                    string fileType = Path.GetExtension(fileName);

                    // Save to a directory
                    var path = Path.Combine(Server.MapPath("~/App_Data/uploads"), fileName);
                    file.SaveAs(path);

                    // Save to Oracle
                    Stream fs;
                    fs = file.InputStream;
                    // fill object with stream
                    byte[] buffer = new byte[fs.Length];
                    buffer = ReadFully(fs);

                    ScanLob scanLob = new ScanLob()
                    {
                        FacilNo = facilNo,
                        LogTypeNo = logTypeNo,
                        EventID = eventID,
                        // ScanNo = scanNo,

                        Blob = buffer //,
                        // Notes = scanDocViewModel.ScanDoc.Notes
                    };

                    // Call ScanLobManager which calls ScanLobDB Upload Method
                    string msg = ScanLobManager.Upload(scanLob);
                }
            }
            
            return RedirectToAction("Index", "AllEvents");
        }

        public static byte[] ReadFully(Stream input)
        {
            byte[] buffer = new byte[input.Length];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }

        public virtual int NextScanSeqNo()
        {
            int _nextScanSeqNo;

            _nextScanSeqNo = ScanDocManager.NextScanSeqNo();

            return _nextScanSeqNo;
        }
        
        public virtual int NextScanDocNo(int facilNo, int logTypeNo, string eventID)
        {
            int _nextScanDocNo;

            _nextScanDocNo = ScanDocManager.NextScanDocNo(facilNo, logTypeNo, eventID);

            return _nextScanDocNo; 
        }

        public string GetVersionNumber()
        {
            Version v = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            string About = string.Format(@"YourApp Version {0}.{1}.{2} (r{3})", v.Major, v.Minor, v.Build, v.Revision); // ultureInfo.InvariantCulture,

            return About;
        }

        public int KeepSessionAlive() //static
        {
            // System.Web.HttpContext.Current.Session.Timeout = _sessionTimeOut;
            System.Web.HttpContext.Current.Session["KeepSessionAlive"] = AllEventManager.KeepSessionAlive(); // DateTime.Now;

            return 1;
        }

        //public class KeepSessionAlive : IHttpHandler, IRequiresSessionState
        //{
        //    public void ProcessRequest(HttpContext context)
        //    {
        //        context.Session["KeepSessionAlive"] = DateTime.Now;
        //    }

        //    public bool IsReusable
        //    {
        //        get
        //        {
        //            return false;
        //        }
        //    }
        //}

        /// <summary>
        /// Wraps matched strings in HTML span elements styled with a background-color
        /// </summary>
        /// <param name="text"></param>
        /// <param name="keywords">Comma-separated list of strings to be highlighted</param>
        /// <param name="cssClass">The Css color to apply</param>
        /// <param name="fullMatch">false for returning all matches, true for whole word matches only</param>
        /// <returns>string</returns>
        //public static string HighlightKeyWords(this string text, string keywords, string cssClass, bool fullMatch)
        //{
        //    if (text == String.Empty || keywords == String.Empty || cssClass == String.Empty)
        //        return text;
        //    var words = keywords.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        //    if (!fullMatch)
        //        return words.Select(word => word.Trim()).Aggregate(text,
        //                     (current, pattern) =>
        //                     Regex.Replace(current,
        //                                     pattern,
        //                                       string.Format("<span style=\"background-color:{0}\">{1}</span>",
        //                                       cssClass,
        //                                       "$0"),
        //                                       RegexOptions.IgnoreCase));
        //    return words.Select(word => "\\b" + word.Trim() + "\\b")
        //                .Aggregate(text, (current, pattern) =>
        //                          Regex.Replace(current,
        //                          pattern,
        //                            string.Format("<span style=\"background-color:{0}\">{1}</span>",
        //                            cssClass,
        //                            "$0"),
        //                            RegexOptions.IgnoreCase));

        //}

        /// <summary>
        /// Wraps matched strings in HTML span elements styled with a background-color
        /// </summary>
        /// <param name="text"></param>
        /// <param name="keywords">Comma-separated list of strings to be highlighted</param>
        /// <param name="cssClass">The Css color to apply</param>
        /// <param name="fullMatch">false for returning all matches, true for whole word matches only</param>
        /// <returns>string</returns>
        //public static string HighlightMeterIDs(this string text, string keywords="MeterID: ", string cssClass="yellow", bool fullMatch=true)
        //{
        //    if (text == String.Empty || keywords == String.Empty || cssClass == String.Empty)
        //        return text;
        //    var words = keywords.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        //    if (!fullMatch)
        //        return words.Select(word => word.Trim()).Aggregate(text,
        //                     (current, pattern) =>
        //                     Regex.Replace(current,
        //                                     pattern,
        //                                       string.Format("<span style=\"background-color:{0}\">{1}</span>",
        //                                       cssClass,
        //                                       "$0"),
        //                                       RegexOptions.IgnoreCase));
        //    return words.Select(word => "\\b" + word.Trim() + "\\b")
        //                .Aggregate(text, (current, pattern) =>
        //                          Regex.Replace(current,
        //                          pattern,
        //                            string.Format("<span style=\"background-color:{0}\">{1}</span>",
        //                            cssClass,
        //                            "$0"),
        //                            RegexOptions.IgnoreCase));

        //}

        
        //public class MyCookie
        //{
        //    public static string CookieName {get;set;}
        //    public virtual User User { get; set; }
        //    public virtual Application App { get; set; }
        //}

        
        //public class CookieHelper
        //{

        //    public static string CookieName {get;set;}
        //    public virtual Application App { get; set; }


        //    public MyCookie(Application app)
        //    {
        //        CookieName = "MyCookie" + app;
        //    }

        //    public static void SetCookie(User user, Community community, int cookieExpireDate = 30)
        //    {
        //        HttpCookie myCookie= new HttpCookie(CookieName);
        //        myCookie["UserId"] = user.UserId.ToString();
        //        myCookie.Expires = DateTime.Now.AddDays(cookieExpireDate);
        //        HttpContext.Current.Response.Cookies.Add(myCookie);
        //     }
        // }
        #endregion
        
    }
}
