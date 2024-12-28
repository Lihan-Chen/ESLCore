using ESL.Mvc.Models.BusinessEntities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web;
using Microsoft.Identity.Abstractions;

namespace ESL.Mvc.Controllers
{
    public class BaseController : Controller
    {
        // From SSO 
        public string UserID; //U0XXXX

        // https://learn.microsoft.com/en-us/answers/questions/804629/how-to-access-user-identity-in-basecontroller
        protected string? Username => User?.Identity?.Name; //.Split("\\");
        // public string UserName = User.Identity!.Name; // Firstname LastName

        public string Shift;  // Day or Night
        public int ShiftNo; // 1 or 2
        public string OperatorType; // Primary or Secondary
        private int _sessionTimeOut = 30; // extends additional time for session

        // From SelectPlant
        public string FacilName;  // OCC
        public int FacilNo; // 1

        public bool SessionValid;
        public bool UserLoggedIn;
        public bool IsAdmin = false;
        public bool IsSuperAdmin = false;
        public bool IsOperator;
        public bool IsCheckingFacility;

        //public Shift _shift;
        // public string Shift = System.Web.HttpContext.Current.Session["ShiftNo"].ToString();
        public const String shiftStartText = "06:00:00";  // for Day shift
        public const String shiftEndText = "17:59:00";
        public DateTime now = DateTime.Now;
        public DateTime tomorrow = DateTime.Now.AddDays(+1);

        public int _pageSize = 40;

        public string yesterdayDate = System.DateTime.Now.AddDays(-1).ToString("MM/dd/yyyy");
        public string todayDate = System.DateTime.Now.Date.ToString("yyyyMMdd");
        public string tomorrowDate = System.DateTime.Now.AddDays(+1).ToString("yyyyMMdd");
        public int _daysOffSet = -2;
        // TimeSpan for two and half hours
        public System.TimeSpan timeSpan = new System.TimeSpan(2, 30, 0);
        public bool okToProceed = false;

        public UserSession userSession;
    }
}
