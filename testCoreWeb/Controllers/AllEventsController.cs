using ESL.Core.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

namespace testCoreWeb.Controllers
{
    public class AllEventsController : BaseController
    {
        // Identifier
        int _facilNo;
        int _logTypeNo;
        string _eventID; // = string.Empty;
        int _eventID_RevNo;

        // Lookup
        string _facilName;
        string _logTypeName;

        // Search
        string _startDate;
        string _endDate;
        DateTime? initialStartDate;
        string _operatorType = String.Empty;
        bool _opType = true;

        // Access HttpContext
        HttpRequest request;
        HttpResponse response;

        public AllEventsController()
        {
            request = HttpContext.Request;
            response = HttpContext.Response;
        }

        // GET: AllEventsController
        [HttpGet("AllEvents")]
        public ActionResult Index(_LogFilterPartialViewModel logFilterPartial, int? facilNo, DateTime? startDate, DateTime? endDate, string searchString, int? page, bool? operatorType) // , string active, string sortOrder, string currentFilter, string searchString, int? page)
        {
            return View();
        }

        // GET: AllEventsController/Details/5
        //[HttpGet("Details")]
        //private static AllEventDetails GetLogDetails(int _facilNo, int logTypeNo, string eventID, int eventID_RevNo)
        //{
        //    return View();
        //}

        //public ActionResult LogSearch(int facilNo, DateTime StartDate, DateTime EndDate, bool operatorType)
        //{
        //    return View();
        //}

        //public ActionResult Rev(int facilNo, int logTypeNo, string eventID, int eventID_RevNo, string act)
        //{
        //    return View();
        //}

        //public ActionResult Del(int facilNo, int logTypeNo, string eventID, int eventID_RevNo)
        //{
        //    string _act = "Deleted";
        //    return RedirectToAction("Rev", "AllEvents", new { facilNo = facilNo, logTypeNo = logTypeNo, eventID = eventID, eventID_RevNo = eventID_RevNo, act = _act });
        //}

        public ActionResult Report(int facilNo, DateTime? startDate, DateTime? endDate, string rptOption, string searchString)
        {
            return View();
        }

        #region Helpers

        public ActionResult ESLUserAutoCompleteList(string term)
        {
            throw new NotImplementedException();
        }

        public ActionResult ESLUserSelectList(string q)
        {
            throw new NotImplementedException();
        }

        public ActionResult DetailsSelectList(int subjNo)
        {
            throw new NotImplementedException();
        }

        [OutputCache(PolicyName = "Cache12Hours")] //, Location = OutputCacheLocation.Client // , VaryByParam = "none"
        public ActionResult LocationSelectList()
        {
            throw new NotImplementedException();
        }

        [OutputCache(PolicyName = "Cache12Hours")] //, VaryByParam = "none"
        public ActionResult ClearanceZoneSelectList()
        {
            throw new NotImplementedException();
        }

        [OutputCache(PolicyName = "Cache12Hours")]
        public ActionResult SubjectSelectList()
        {
            throw new NotImplementedException();
        }

        [OutputCache(PolicyName = "Cache12Hours")]
        public ActionResult WorkToBePerformedSelectList()
        {
            throw new NotImplementedException();
        }

        [OutputCache(PolicyName = "Cache12Hours")] //, Location = OutputCacheLocation.Client
        //[ResponseCache(CacheProfileName = "Default30")]
        public ActionResult EquipmentInvolvedSelectList()
        {
            throw new NotImplementedException();
        }

        //[ChildActionOnly]
        [Route("RelatedTo")]
        [OutputCache(NoStore = true)] // NoCache
        public JsonResult SearchRelatedToList(int facilNo, int logTypeNo, string startDate, string endDate, string keyWords, string andOr)  //JsonResult
        {
            throw new NotImplementedException();
        }

        public JsonResult SearchRealTimeList(int facilNo, string startDate, string endDate)  //JsonResult
        {
            throw new NotImplementedException();
        }

        //[ChildActionOnly]
        [Route("AddName")]
        [OutputCache(NoStore = true)] // NoCache
        public JsonResult AddName(string firstname, string lastname, string company)  //JsonResult
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
