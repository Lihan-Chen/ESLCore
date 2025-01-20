using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;
using System.Runtime.Serialization;

namespace testCoreWeb.Areas.Admin.Controllers
{
    public class SubjectController : AdminBaseController
    {
        int _facilNo = 0;
        string _facilName;
        string _facilType;

        public IActionResult Index(string Active, string sortOrder, string currentFilter, string searchString, int? page)
        {
            return View();
        }

        //
        // GET: /Admin/Subject/

        //public ActionResult Index(string Active, string sortOrder, string currentFilter, string searchString, int? page)
        //{

        //bool _Active;
        //int _totalItemCount;
        //string _facilType;

        //_facilNo = FacilNo;

        //if (_facilNo == 0)
        //{
        //    ViewBag.ShowAlert = true;
        //    ViewBag.Alert = "You must select a facility first!";
        //    return RedirectToAction("Index", "Home", new { Area = "", returnUrl = "", showAlert = true });
        //}

        //_facilName = mvc4ESL.Controllers.Helpers.FacilNameSelected();
        //_facilType = mvc4ESL.Controllers.Helpers.FacilTypeSelected(_facilNo);

        //// setup PagedList Parameters
        //ViewBag.CurrentSort = sortOrder;
        //ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "SubjectName desc" : "";

        //if (Request.HttpMethod == "GET")
        //{
        //    searchString = currentFilter;
        //}
        //else
        //{
        //    page = 1;
        //}

        //ViewBag.CurrentFilter = searchString;

        //// Set Default to Active,
        //_Active = Active != "false" ? true : false;
        ////Active = Active ?? "true";
        ////_Active = Boolean.Parse(Active); // active is null when new

        //ViewBag.ActiveSelector = _Active;

        //ViewBag.FacilNo = _facilNo;
        //ViewBag.FacilName = _facilName; // FacilityManager.GetItem(_facilNo).FacilName.Split(' ').FirstOrDefault();
        //ViewBag.FacilType = _facilType;

        //var subjectList = from s in SubjectManager.GetList(_facilNo).AsEnumerable().Where(s => s.FacilType == _facilType)
        //                  select s;

        //if (_Active == true)
        //{
        //    subjectList = subjectList.Where(s => s.Disable == null);
        //}

        //if (!String.IsNullOrEmpty(searchString))
        //{
        //    subjectList = from s in subjectList
        //                  where (s.SubjectName + " " + s.FacilType + " " + s.Notes).ToUpper().Contains(searchString.ToUpper())
        //                  select s;
        //}

        //_totalItemCount = subjectList.Count();

        //switch (sortOrder)
        //{
        //    case "SubjectName desc":
        //        subjectList = subjectList.OrderByDescending(s => s.SubjectName);
        //        break;
        //    default:
        //        subjectList = subjectList.OrderBy(s => s.SubjectNo);
        //        break;
        //}

        //int pageSize = _pageSize;
        //int pageIndex = (page ?? 1);
        //var subjectAsIPagedList = subjectList.ToPagedList(pageIndex, pageSize);

        //return View(subjectAsIPagedList);  // "~Areas/Admin/Views/Subject/Index", 
        //}

        //public ActionResult Create()
        //{
        //    _facilNo = FacilNo;
        //    _facilName = mvc4ESL.Controllers.Helpers.FacilNameSelected();
        //    _facilType = FacilityManager.GetItem(_facilNo).FacilType;

        //    if (String.IsNullOrEmpty(_facilName))
        //    {
        //        return RedirectToAction("Index", "Home", new { Area = "" });
        //    }

        //    Subject subject = new Subject
        //    {
        //        SubjectNo = -1,
        //        FacilNo = _facilNo,
        //        // FacilType = FacilityManager.GetItem(_facilNo).FacilType,
        //        UpdatedBy = User.Identity.Name.ToUpper() + " - " + UserName
        //    };

        //    ViewBag.FacilNo = _facilNo;
        //    ViewBag.FacilName = _facilName;

        //    return View(subject);
        //}

        //[HttpPost]
        //public ActionResult Create(Subject subject)
        //{
        //    int _facilNo = subject.FacilNo;
        //    string _facilType = FacilityManager.GetItem(_facilNo).FacilType;
        //    int _subjectNo = NextSubjectNo(_facilNo);

        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            if (subject.SubjectNo == -1)
        //            {
        //                subject.SubjectNo = _subjectNo;
        //                subject.FacilType = _facilType;
        //                subject.UpdatedBy = User.Identity.Name.ToUpper() + " - " + UserName;
        //            }

        //            // subject.FacilType = _facilType;
        //            // inForceUpdate = "" when insert
        //            SubjectManager.Update(subject, "");
        //            return RedirectToAction("Index");
        //        }
        //    }
        //    catch (DataException)
        //    {
        //        // Log the error (add a variable name after DataException)
        //        ModelState.AddModelError(String.Empty, "Unable to save changes.  Please try again, and if the problem persists, contact your system administrator.");
        //    }

        //    return View(subject);
        //}

        //public ActionResult Edit(int facilNo, string subjectName)
        //{
        //    bool _disabled = false;
        //    int _subjectNo;
        //    _facilNo = FacilNo;
        //    _facilName = mvc4ESL.Controllers.Helpers.FacilNameSelected();

        //    if (String.IsNullOrEmpty(_facilName))
        //    {
        //        return RedirectToAction("Index", "Home", new { Area = "" });
        //    }

        //    _subjectNo = SubjectManager.GetList(_facilNo).AsEnumerable().Where(s => s.SubjectName == subjectName).FirstOrDefault().SubjectNo;

        //    var subject = SubjectManager.GetItem(_facilNo, _subjectNo);

        //    _disabled = String.IsNullOrEmpty(subject.Disable) ? false : true;

        //    ViewBag.FacilNo = _facilNo;
        //    ViewBag.FacilName = _facilName;
        //    ViewBag.SubjectName = subjectName;
        //    ViewBag.Disabled = _disabled;

        //    return View(subject);
        //}

        //[HttpPost]
        //public ActionResult Edit(SubjectViewModel subject, string Disable)
        //{
        //    subject.Disable = Disable == "true" ? "Y" : string.Empty;
        //    subject.UpdatedBy = User.Identity.Name.ToUpper() + " - " + UserName;

        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            // call the Update method
        //            SubjectManager.Update(subject, forceUpdate);
        //            return RedirectToAction("Index");
        //        }
        //    }
        //    catch (DataException)
        //    {
        //        // Log the error (add a variable name after DataException)
        //        ModelState.AddModelError(String.Empty, "Unable to save changes.  Please try again, and if the problem persists, contact your system administrator.");
        //    }

        //    return View(subject);
        //}

        //public ActionResult Delete(int facilNo, string subjectName)
        //{
        //    _facilNo = FacilNo;
        //    _facilName = mvc4ESL.Controllers.Helpers.FacilNameSelected();

        //    if (String.IsNullOrEmpty(_facilName))
        //    {
        //        return RedirectToAction("Index", "Home", new { Area = "" });
        //    }

        //    ViewBag.FacilNo = _facilNo;
        //    ViewBag.FacilName = _facilName;
        //    ViewBag.SubjectName = subjectName;

        //    int _subjectNo = SubjectManager.GetList(_facilNo).AsEnumerable().Where(s => s.SubjectName == subjectName).FirstOrDefault().SubjectNo;

        //    var subject = SubjectManager.GetItem(facilNo, _subjectNo);

        //    return View(subject);
        //}

        //[HttpPost, ActionName("Delete")]
        //public ActionResult DeleteConfirm(SubjectViewModel subject)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            // inForceUpdate = "D" when insert
        //            SubjectManager.Update(subject, "D");
        //            return RedirectToAction("Index");
        //        }

        //    }
        //    catch (DataException)
        //    {
        //        // Log the error (add a variable name after DataException)
        //        // ModelState.AddModelError(String.Empty, "Unable to save changes.  Please try again, and if the problem persists, contact your system administrator.");
        //        return RedirectToAction("Delete", new System.Web.Routing.RouteValueDictionary { { "subject", subject }, { "saveChangesError", true } });
        //    }

        //    return RedirectToAction("Index");
        //}

        //public ActionResult Details(int facilNo, string subjectName)
        //{
        //    _facilNo = FacilNo;
        //    _facilName = mvc4ESL.Controllers.Helpers.FacilNameSelected();

        //    if (String.IsNullOrEmpty(_facilName))
        //    {
        //        return RedirectToAction("Index", "Home", new { Area = "" });
        //    }

        //    ViewBag.FacilNo = _facilNo;
        //    ViewBag.FacilName = _facilName;
        //    ViewBag.SubjectName = subjectName;

        //    int _subjectNo = SubjectManager.GetList(_facilNo).AsEnumerable().Where(s => s.SubjectName == subjectName).FirstOrDefault().SubjectNo;

        //    var subject = SubjectManager.GetItem(facilNo, _subjectNo);
        //    return View(subject);
        //}

        //public ActionResult LoadSubjects(int facilNo)
        //{
        //    SubjectList allSubjects = facilNo != 0 ? SubjectManager.GetList(facilNo) : null;

        //    if (allSubjects != null)
        //    {

        //        var facilList = FacilityManager.GetList().AsEnumerable().Where(f => f.FacilNo <= 13).Select(f => new SelectListItem { Value = f.FacilNo.ToString(), Text = f.FacilAbbr }).ToList();

        //        SubjectListViewModel subjectListViewModel = new SubjectListViewModel
        //        {
        //            FacilNo = facilNo,
        //            Subjects = allSubjects,
        //            FacilNos = new SelectList(facilList, "Value", "Text"),
        //        };

        //        return PartialView("_LoadSubjects", subjectListViewModel);
        //    }
        //    else
        //    {
        //        // pop up a modal alert for no data.
        //        return View();
        //    }
        //}

        //private int NextSubjectNo(int facilNo)
        //{
        //    return SubjectManager.GetList(facilNo).AsQueryable().Select(s => s.SubjectNo).DefaultIfEmpty().Max() + 1;
        //}

    }

}
