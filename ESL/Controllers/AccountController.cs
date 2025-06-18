using ESL.Core.Models.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.OutputCaching;
using System.Data;
using System.Net;
using System.Reflection.PortableExecutable;

namespace ESL.Web.Controllers
{
    public class AccountController : Controller
    {
        public const string myADPath = "LDAP://mwd.h2o/OU=Group-Water System Operations,OU=Computers and Users,DC=mwd,DC=h2o";

        //
        // GET: /Account/Login

        [OutputCache(NoStore = true, Duration = 0, VaryByQueryKeys = new string[] { "None" })]  //http://stackoverflow.com/questions/14970102/anti-forgery-token-is-meant-for-user-but-the-current-user-is-username
        [AllowAnonymous]
        {
            AntiForgeryConfig.SuppressIdentityHeuristicChecks = true;

            if (User.Identity.IsAuthenticated == false)
            {
                switch (returnUrl)
                {
                    case "/":
                        // ViewBag.Message = "Please log in first.";
                        break;
                    case "/Account/Login":
                        break;
                    case "/Account/Logoff":
                        ViewBag.Message = "You have logged off from the current ESL session.  Please log in again.";
                        returnUrl = null;
                        break;
                    case null:
                        break;
                    default:
                        ViewBag.Message = "Your current session requires a login or has timed out due to inactivity.  Please log in again.";
                        break;
                }

                // reset returnUrl to root
                returnUrl = "/";
            }

            // string defaultUserAcct = UserPrincipal.Current.SamAccountName; HttpContext.User.Identity.Name;
            // On web server this shows the service account
            // string _defaultWindowsUserName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            // defaultUserAcct = _defaultWindowsUserName.Substring(_defaultWindowsUserName.Length - 6);

            string defaultUserAcct = User.Identity.Name;

            var myOpTypeList = Enum.GetValues(typeof(OperatorType))
                .Cast<OperatorType>()
                .Select(s => new { ID = s, Name = s.ToString() });
            var myShiftList = Enum.GetValues(typeof(Shift))
                .Cast<Shift>()
                .Select(s => new { ID = s, Name = s.ToString() });

            Shift _shift;
            String shiftStartText = "06:00:00";
            String shiftEndText = "18:30:00";
            DateTime shiftStartTime = Convert.ToDateTime(shiftStartText); // Converts only the time
            DateTime shiftEndTime = Convert.ToDateTime(shiftEndText);
            DateTime now = DateTime.Now;

            if (now >= shiftStartTime && now < shiftEndTime)
            {
                _shift = mvc4ESL.Models.Enums.Shift.Day;
            }
            else
            {
                _shift = mvc4ESL.Models.Enums.Shift.Night;
            }

            ViewBag.Shift = _shift;

            var model = new LoginModel
            {
                UserID = defaultUserAcct,
                Shft = _shift,
                optionOpType = new SelectList(myOpTypeList, "ID", "Name"),
                optionShift = new SelectList(myShiftList, "ID", "Name", _shift)
            };

            ViewBag.ReturnUrl = returnUrl;

            return View(model);
        }

        //
        // POST: /Account/Login

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            // AntiForgeryConfig.SuppressIdentityHeuristicChecks = true;

            if (User.Identity.IsAuthenticated)
            {
                System.Web.HttpContext.Current.Session.Abandon();
                HttpContext.User = null;
            }

            try
            {
                // check if server is operational and catch the exception

                // if (ModelState.IsValid && WebSecurity.Login(model.UserID, model.Password, persistCookie: model.RememberMe)) // for SQL
                if (ModelState.IsValid && Membership.ValidateUser(model.UserID, model.Password)) // For AD
                {
                    FormsAuthentication.SetAuthCookie(model.UserID, model.RememberMe); // model.RememberMe defaults to false

                    // additional useful reference http://stackoverflow.com/questions/5767768/troubleshooting-anti-forgery-token-problems

                    // set UserSession from LoginModel
                    InitUserSession(model);

                    if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                        && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                    {
                        if (returnUrl != "/Account/Logoff")
                        {
                            return RedirectToLocal(returnUrl); // RedirectToAction(returnUrl); 
                        }
                        else
                        // redirect to Home/Index
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }

                // If we got this far, something failed, redisplay form
                ModelState.AddModelError("", "The user name or password provided is incorrect.");
                var myOpTypeList = Enum.GetValues(typeof(OperatorType))
                    .Cast<OperatorType>()
                    .Select(s => new { ID = s, Name = s.ToString() });
                var myShiftList = Enum.GetValues(typeof(Shift))
                    .Cast<Shift>()
                    .Select(s => new { ID = s, Name = s.ToString() });

                OperatorType _opType = model.OpType;
                Shift _shift = model.Shft;

                var postModel = new LoginModel
                {
                    UserID = model.UserID,
                    OpType = _opType,
                    Shft = _shift,
                    optionOpType = new SelectList(myOpTypeList, "ID", "Name", _opType),
                    optionShift = new SelectList(myShiftList, "ID", "Name", _shift)
                };

                return View(postModel);
            }

            catch (WebException ex)
            {
                using (var stream = ex.Response.GetResponseStream())
                using (var reader = new StreamReader(stream))
                {
                    string text = reader.ReadToEnd();
                    // text will contain the response from the server
                    //return RedirectToAction(Request.UrlReferrer.ToString());
                    return RedirectToAction("Index", "Home");
                }
            }
        }

        //
        // POST: /Account/LogOff

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            string urlString = "/Account/Logoff";
            //Roles.DeleteCookie();
            //Session.Clear();
            //Response.Cache.SetExpires(DateTime.Now);

            AntiForgeryConfig.SuppressIdentityHeuristicChecks = true;
            // System.Web.Helpers.AntiForgery.GetTokens(null, newCookieToken: new, formToken: this); (only for 4.5)

            FormsAuthentication.SignOut();

            // http://stackoverflow.com/questions/22407774/mvc-4-logout-not-working-correctly
            Roles.DeleteCookie();
            Response.Cache.SetExpires(DateTime.Now);
            System.Web.HttpContext.Current.Session.Abandon();
            Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
            HttpContext.User = null;

            return RedirectToAction("Login", "Account", new { returnUrl = urlString });

        }

        #region Helpers

        // for LDAP http://social.msdn.microsoft.com/Forums/vstudio/en-US/fff557cc-0a7c-4b2f-8d2c-87aca91295ce/how-to-check-if-ldap-server-is-up-and-answers-openldap?forum=csharpgeneral

        // for DirectoryEntry
        private bool ADOK(string myADPath)
        {
            bool _ADOK = false;
            string _myADPath = myADPath; //  "LDAP://mwd.h2o/OU=Group-Water System Operations,OU=Computers and Users,DC=mwd,DC=h2o";

            if (DirectoryEntry.Exists(_myADPath))
            {
                _ADOK = true;
            }
            return _ADOK;
        }

        private ActionResult RedirectToLocal(string returnUrl)
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

        public enum ManageMessageId
        {
            ChangePasswordSuccess,
            SetPasswordSuccess,
            RemoveLoginSuccess,
        }

        internal class ExternalLoginResult : ActionResult
        {
            public ExternalLoginResult(string provider, string returnUrl)
            {
                Provider = provider;
                ReturnUrl = returnUrl;
            }

            public string Provider { get; private set; }
            public string ReturnUrl { get; private set; }

            public override void ExecuteResult(ControllerContext context)
            {
                OAuthWebSecurity.RequestAuthentication(Provider, ReturnUrl);
            }
        }

        private static string ErrorCodeToString(MembershipCreateStatus createStatus)
        {
            // See http://go.microsoft.com/fwlink/?LinkID=177550 for
            // a full list of status codes.
            switch (createStatus)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return "User name already exists. Please enter a different user name.";

                case MembershipCreateStatus.DuplicateEmail:
                    return "A user name for that e-mail address already exists. Please enter a different e-mail address.";

                case MembershipCreateStatus.InvalidPassword:
                    return "The password provided is invalid. Please enter a valid password value.";

                case MembershipCreateStatus.InvalidEmail:
                    return "The e-mail address provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidAnswer:
                    return "The password retrieval answer provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidQuestion:
                    return "The password retrieval question provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidUserName:
                    return "The user name provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.ProviderError:
                    return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                case MembershipCreateStatus.UserRejected:
                    return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                default:
                    return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
            }
        }

        private void InitUserSession(LoginModel model)
        {
            int _sessionTimeOut = 800;
            System.Web.HttpContext.Current.Session["UserID"] = model.UserID; // u0xxxx
            System.Web.HttpContext.Current.Session["Shift"] = model.Shft.ToString(); // Day or Night
            System.Web.HttpContext.Current.Session["OperatorType"] = model.OpType.ToString();
            // extends session for another 30 minutes
            System.Web.HttpContext.Current.Session.Timeout = _sessionTimeOut;
        }
        #endregion

    }
        // GET: AccountController
        //public ActionResult Index()
        //{
        //    return View();
        //}

        //// GET: AccountController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: AccountController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: AccountController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: AccountController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: AccountController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: AccountController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: AccountController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
}
