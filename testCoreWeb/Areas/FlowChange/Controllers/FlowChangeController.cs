using ESL.Core.Models.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.Extensions.Logging;
using Microsoft.Graph;

namespace testCoreWeb.Areas.FlowChange.Controllers
{
    public class FlowChangeController : Controller
    {
        int _facilNo = 0;

        string _eventID = string.Empty;

        int _eventID_RevNo = 0;

        string _act = string.Empty;

        string _alert = string.Empty;



        [Area("FlowChange")]
        [HttpGet]
        [OutputCacheAttribute(Duration = 0, NoStore = true)]
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return RedirectToAction("Revise", "FlowChange", new { facilNo = _facilNo, eventID = _eventID, eventID_RevNo = _eventID_RevNo, act = _act, alert = _alert });
        }

        public IActionResult _Details(int facilNo, int logTypeNo, string eventID, int eventID_RevNo)
        {

            return View();
        }

        public IActionResult Details(int facilNo, int logTypeNo, string eventID, int eventID_RevNo, string startDate, string endDate)
        {
            return View();
        }

        public IActionResult Revise(int facilNo, string eventID, int eventID_RevNo, string act, string alert)
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        [Route("Revise")]
        public IActionResult Revise() // FlowChange myFlowChange
        {
            return View();
        }

        [Authorize]
        [HttpGet]
        public ActionResult Accept(int facilNo, string eventID, int eventID_RevNo, string alert)
        {
            return View();
        }

        [HttpPost]
        public ActionResult AcceptConfirm() // FlowChange myFlowChange
        {
            return View();
        }

        //
        // GET: /FlowChange/Reject/5
        [Authorize]
        [HttpGet]
        public ActionResult Reject(int facilNo, string eventID, int eventID_RevNo, string alert)
        {
            return View();
        }

        [HttpPost]
        public ActionResult RejectConfirm() //FlowChange myFlowChange
        {
            return View();
        }

        public ActionResult Close(int facilNo, string eventID, int eventID_RevNo, string alert)
        {
            return View();
        }

        [Authorize]
        [HttpGet]
        public ActionResult Delete(int facilNo, string eventID, int eventID_RevNo) //, string alert
        {
            return View();
        }

        [HttpPost]
        public ActionResult DeleteConfirm() //FlowChange myFlowChange
        {
            return View();
        }

        public ActionResult LogSearch(int facilNo, int logTypeNo, DateTime startDate, DateTime endDate, bool operatorType)
        {
            return View();
        }

        //public JsonResult GetEmployeeList()
        //{
        //    var employeeList = from e in EmployeeManager.GetList().OrderByDescending(e => e.LastName).AsEnumerable() //.Skip(4).Take(100)
        //                       select e;
        //    return Json(employeeList, JsonRequestBehavior.AllowGet);
        //}

        //public ActionResult MeterIDSelectList()
        //{
        //    int _facilNo = FacilNo;
        //    var mList = MeterManager.GetList(_facilNo).AsEnumerable().Select(m => new { MeterID = m.MeterID.ToString(), Meter = m.MeterID.ToString() }).ToList();
        //    // var mList = MeterManager.GetList(_facilNo).AsEnumerable().Select(m => new  { Value = m.MeterID.ToString(), Text = m.MeterID.ToString() }).ToList(); 

        //    return Json(mList, JsonRequestBehavior.AllowGet);

        //    // return [{"EmpID":6337,"Name":"Lihan Chen"},{"EmpID":7519,"Name":"Evan Ho"},{"EmpID":7822,"Name":"Alex Pop"}];
        //}

        //public JsonResult GetSelectedMeterResult(int facilNo, string meterID, string dateOn, string timeOn)  //JsonResult
        //{
        //    InitMeterReading initMeterReading = FlowChangeManager.GetInitMeterReading(facilNo, meterID, dateOn, timeOn);

        //    return Json(initMeterReading, JsonRequestBehavior.AllowGet);

        //}

        //public JsonResult GetRealTimeList(int facilNo, string startDate, string endDate)  //JsonResult
        //{
        //    _facilNo = facilNo != 0 ? facilNo : FacilNo;

        //    RealTimeList realTimeList = PreScheduled_FlowChangeManager.GetRealTimeList(facilNo, startDate, endDate);


        //    return Json(realTimeList, JsonRequestBehavior.AllowGet);

        //    // the following is the json representation of realTimeList, pay attention to how list is presented and how datatime field is escaped. "\/Date(1398876044784)\/"
        //    // return [{"FacilNo":1,"LogTypeNo":5,"EventID":"14-04134","EventID_RevNo":0,"EventDateTime":"\/Date(1398876044784)\/","Subject":"test 1"},{"FacilNo":1,"LogTypeNo":5,"EventID":"14-04135","EventID_RevNo":0,"EventDateTime":"\/Date(1398876104784)\/","Subject":"test 2"}];
        //}

        //public JsonResult GetRealTime(int facilNo, string startDate, string endDate)  //JsonResult
        //{
        //    //startDate and endDate are in the MMDDYYYY format, ex. 06012014

        //    _facilNo = facilNo != 0 ? facilNo : FacilNo;


        //    RealTimeList realTimeList = new RealTimeList();
        //    realTimeList = PreScheduled_FlowChangeManager.GetRealTimeList(facilNo, startDate, endDate);

        //    RealTime realTime = new RealTime();

        //    if (realTimeList != null)
        //    {
        //        realTime = realTimeList.First();
        //    }
        //    else
        //    {
        //        realTime = null;
        //    }

        //    // test case
        //    //RealTime realTime = new RealTime()
        //    //{
        //    //    FacilNo = 1,
        //    //    LogTypeNo = 5,
        //    //    EventID = "14-04134",
        //    //    EventID_RevNo = 0,
        //    //    EventDateTime = System.DateTime.Now.AddMinutes(5),
        //    //    Subject = "test subject" // realTimeList.AsQueryable().Where(r => r.LogTypeNo == 5 && r.EventID == "14-04134" && r.EventID_RevNo == 0).Select(x => x.Subject).ToString()
        //    //};

        //    //realTimeList.Add(realtime1);           

        //    return Json(realTime, JsonRequestBehavior.AllowGet);

        //    // the following is the json representation of realTimeList, pay attention to how list is presented and how datatime field is escaped. "\/Date(1398876044784)\/"
        //    // return [{"FacilNo":1,"LogTypeNo":5,"EventID":"14-04134","EventID_RevNo":0,"EventDateTime":"\/Date(1398876044784)\/","Subject":"test 1"},{"FacilNo":1,"LogTypeNo":5,"EventID":"14-04135","EventID_RevNo":0,"EventDateTime":"\/Date(1398876104784)\/","Subject":"test 2"}];
        //}

        # region Helpers

        // Modify Flag passed as status of Action (but turned to Revised, Accepted, Rejected at HttpPost)
        public enum ManageModifyFlagID
        {
            New,
            Revise,
            Accept,
            Reject,
            Delete,
        }

        //private void PopulateEmployeeDropDownList(object selectedEmployee = null)
        //{
        //    var employeeQuery = EmployeeManager.GetList().AsEnumerable().ToList(); //.Where(e => e.FacilNo = _facilNo)
        //    var empByFisrtNameList = EmployeeManager.GetList().AsEnumerable().Select(s => new { EmployeeNo = s.EmployeeNo, Name = s.FirstName + " " + s.LastName + " - " + s.Company });
        //    var empByLastNameList = EmployeeManager.GetList().AsEnumerable().Select(s => new { EmployeeNo = s.EmployeeNo, Name = s.LastName + ", " + s.FirstName + " - " + s.Company });

        //    var myUnitList = Enum.GetValues(typeof(UnitType))
        //        .Cast<UnitType>()
        //        .Select(s => new { ID = s, Name = s.ToString() });

        //    // Select(e => new SelectListItem { Value = e.EmployeeNo.ToString(), Text = e.LastName + ", " + e.FirstName + " - " + e.Company }).
        //    ViewBag.RequestedBy = new SelectList(employeeQuery, "EmployeeNo", "LastName" + ", " + "FirstName", selectedEmployee);
        //    ViewBag.RequestedTo = new SelectList(employeeQuery, "EmployeeNo", "LastName" + ", " + "FirstName", selectedEmployee);
        //    ViewBag.CreatedBy = new SelectList(employeeQuery, "EmployeeNo", "LastName" + ", " + "FirstName", selectedEmployee);
        //    ViewBag.ModifiedBy = new SelectList(employeeQuery, "EmployeeNo", "LastName" + ", " + "FirstName", selectedEmployee);
        //    ViewBag.NotifiedBy = new SelectList(employeeQuery, "EmployeeNo", "LastName" + ", " + "FirstName", selectedEmployee);
        //    ViewBag.empByFirstNameList = new SelectList(empByFisrtNameList, "EmployeeNo", "Name", selectedEmployee);
        //}
        #endregion
    }
}


