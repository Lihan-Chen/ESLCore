using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;

namespace ESL.Mvc.Area.Admin.Controllers
{
    public class ConstantController : AdminBaseController
    {
        private int _facilNo = 0;
        private string _facilName;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ConstantController(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor) //, IDownstreamApi downstreamApi
        {
            this._httpContextAccessor = httpContextAccessor;
        }

        //
        // GET: /Admin/Constant/

        public ActionResult Index(string Active, string sortOrder, string currentFilter, string searchString, int? page)
        {

            bool _Active;
            int _totalItemCount;

            _facilNo = FacilNo; // Convert.ToInt32(Session["facilNo"]); //mvc4ESL.Controllers.Helpers.FacilNoSelected(); 

            if (_facilNo == 0)
            {
                ViewBag.ShowAlert = true;
                ViewBag.Alert = "You must select a facility first!";
                return RedirectToAction("Index", "Home", new { Area = "", returnUrl = "", showAlert = true });
            }

            _facilName = FacilName; // mvc4ESL.Controllers.Helpers.FacilNameSelected();

            // setup PagedList Parameters
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "ConstantName desc" : "";
            ViewBag.DateSortParm = sortOrder == "StartDate" ? "StartDate desc" : "StartDate";

            if (Request.Method == "GET")
            {
                searchString = currentFilter;
            }
            else
            {
                page = 1;
            }

            ViewBag.CurrentFilter = searchString;

            //Set Default to Active,
            _Active = Active != "false" ? true : false;

            ViewBag.ActiveSelector = _Active;

            ViewBag.FacilNo = _facilNo;
            ViewBag.FacilName = _facilName; // FacilityManager.GetItem(_facilNo).FacilName.Split(' ').FirstOrDefault();

            var constantList = from c in ConstantManager.GetList(_facilNo).AsEnumerable()
                               select c;

            if (_Active == true)
            {
                constantList = constantList.Where(c => c.FacilNo == _facilNo && (c.EndDate >= System.DateTime.Now.Date || !c.EndDate.HasValue));
            }
            else
            {
                constantList = constantList.Where(c => c.FacilNo == _facilNo);
            }

            if (!String.IsNullOrEmpty(searchString))
            {
                constantList = constantList.Where(c => (c.ConstantName + " " + c.Notes).ToUpper().Contains(searchString.ToUpper()));
            }

            _totalItemCount = constantList.Count();

            switch (sortOrder)
            {
                case "ConstantName desc":
                    constantList = constantList.OrderByDescending(c => c.ConstantName);
                    break;
                case "StartDate":
                    constantList = constantList.OrderBy(c => c.StartDate);
                    break;
                case "StartDate desc":
                    constantList = constantList.OrderByDescending(c => c.StartDate);
                    break;
                default:
                    constantList = constantList.OrderBy(c => c.ConstantName);
                    break;
            }

            int pageSize = 10;
            int pageIndex = (page ?? 1);
            var constantAsIPagedList = constantList.ToPagedList(pageIndex, pageSize);

            return View(constantAsIPagedList);  // "~Areas/Admin/Views/Constant/Index", 
        }

        public ActionResult Create()
        {
            _facilNo = FacilNo;
            _facilName = mvc4ESL.Controllers.Helpers.FacilNameSelected();

            if (String.IsNullOrEmpty(_facilName))
            {
                return RedirectToAction("Index", "Home", new { Area = "" });
            }

            ViewBag.FacilNo = _facilNo;
            ViewBag.FacilName = _facilName;

            ConstantViewModel constant = new ConstantViewModel
            {
                FacilNo = _facilNo,
                StartDate = System.DateTime.Today.Date,
                UpdatedBy = HttpContext.User.Identity.Name
            };

            return View(constant);
        }

        [HttpPost]
        public ActionResult Create(ConstantViewModel constant)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ConstantManager.Update(constant, "Y");
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                // Log the error (add a variable name after DataException)
                ModelState.AddModelError(String.Empty, "Unable to save changes.  Please try again, and if the problem persists, contact your system administrator.");
            }

            return View(constant);
        }

        public ActionResult Edit(int facilNo, string constantName, string startDate)
        {
            _facilNo = FacilNo;
            _facilName = mvc4ESL.Controllers.Helpers.FacilNameSelected();

            if (String.IsNullOrEmpty(_facilName))
            {
                return RedirectToAction("Index", "Home", new { Area = "" });
            }

            ViewBag.FacilNo = _facilNo;
            ViewBag.FacilName = _facilName;
            ViewBag.ConstantName = constantName;

            var constant = ConstantManager.GetItem(_facilNo, constantName, startDate);

            return View(constant);
        }

        [HttpPost]
        public ActionResult Edit(ConstantViewModel constant)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ConstantManager.Update(constant, "Y");
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                // Log the error (add a variable name after DataException)
                ModelState.AddModelError(String.Empty, "Unable to save changes.  Please try again, and if the problem persists, contact your system administrator.");
            }

            return View(constant);
        }

        public ActionResult Delete(int facilNo, string constantName, string startDate)
        {
            var constant = ConstantManager.GetItem(facilNo, constantName, startDate);

            return View(constant);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(ConstantViewModel constant)
        {
            // Check if the End Date is greater than today
            if (!constant.EndDate.HasValue || constant.EndDate >= System.DateTime.Today)
            {
                ViewBag.Message = "The End Data must be a date before today's date.";
                return View(constant);
            }

            try
            {

                ConstantManager.Update(constant, "Y");

            }
            catch (DataException)
            {
                // Log the error (add a variable name after DataException)
                // ModelState.AddModelError(String.Empty, "Unable to save changes.  Please try again, and if the problem persists, contact your system administrator.");
                return RedirectToAction("Delete", new System.Web.Routing.RouteValueDictionary { { "constant", constant }, { "saveChangesError", true } });
            }

            return RedirectToAction("Index");
        }

        public ActionResult Details(int facilNo, string constantName, string startDate)
        {
            if (String.IsNullOrEmpty(HttpContext.Session["FacilName"].ToString()))
            {
                ViewBag.FacilName = String.IsNullOrEmpty(HttpContext.Session["FacilName"].ToString());
            }

            var constant = ConstantManager.GetItem(facilNo, constantName, startDate);

            return View(constant);
        }

        public ActionResult LoadConstants(int facilNo)
        {
            ConstantList allConstants = facilNo != 0 ? ConstantManager.GetList(facilNo) : null;

            if (allConstants != null)
            {

                var facilList = FacilityManager.GetList().AsEnumerable().Where(f => f.FacilNo <= 13).Select(f => new SelectListItem { Value = f.FacilNo.ToString(), Text = f.FacilAbbr }).ToList();

                ConstantListViewModel constantListViewModel = new ConstantListViewModel
                {
                    FacilNo = facilNo,
                    Active = true,
                    Constants = allConstants,
                    FacilNos = new SelectList(facilList, "Value", "Text"),
                };

                return PartialView("_LoadConstants", constantListViewModel);
            }
            else
            {
                // pop up a modal alert for no data.
                return View();
            }
        }

        // The following is for DataTable using Ajax (checkout the JQueryDataTableParamModel in ViewModels)
        public ActionResult AjaxHandler(JQueryDataTableParamModel param, int facilNo)
        {
            ConstantList allConstants = ConstantManager.GetList(facilNo);

            IEnumerable<Constant> filteredConstants;

            //Check whether the constants should be filtered by keyword
            if (!string.IsNullOrEmpty(param.sSearch))
            {
                //Used if particulare columns are filtered 
                var nameFilter = Convert.ToString(Request["sSearch_1"]);
                var valueFilter = Convert.ToString(Request["sSearch_2"]);
                var notesFilter = Convert.ToString(Request["sSearch_3"]);

                //Optionally check whether the columns are searchable at all 
                var isNameSearchable = Convert.ToBoolean(Request["bSearchable_1"]);
                var isValueSearchable = Convert.ToBoolean(Request["bSearchable_2"]);
                var isNotesSearchable = Convert.ToBoolean(Request["bSearchable_3"]);

                filteredConstants = allConstants.AsEnumerable()
                   .Where(c => isNameSearchable && c.ConstantName.ToLower().Contains(param.sSearch.ToLower())
                               ||
                               isValueSearchable && c.Value.ToString().ToLower().Contains(param.sSearch.ToLower())
                               ||
                               isNotesSearchable && c.Notes.ToLower().Contains(param.sSearch.ToLower()));
            }
            else
            {
                filteredConstants = allConstants;
            }

            var isNameSortable = Convert.ToBoolean(Request["bSortable_1"]);
            var isValueSortable = Convert.ToBoolean(Request["bSortable_2"]);
            var isNotesSortable = Convert.ToBoolean(Request["bSortable_3"]);
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            Func<Constant, string> orderingFunction = (c => sortColumnIndex == 1 && isNameSortable ? c.ConstantName :
                                                           sortColumnIndex == 2 && isValueSortable ? c.Value.ToString() :
                                                           sortColumnIndex == 3 && isNotesSortable ? c.Notes :
                                                           "");

            var sortDirection = Request["sSortDir_0"]; // asc or desc
            if (sortDirection == "asc")
                filteredConstants = filteredConstants.OrderBy(orderingFunction);
            else
                filteredConstants = filteredConstants.OrderByDescending(orderingFunction);

            //var displayedConstants = filteredConstants.Skip(param.iDisplayStart).Take(5); //param.iDisplayLength);
            var result = filteredConstants.Select(c => new { c.ConstantName, c.Value, c.StartDate, c.EndDate, c.Notes, c.UpdatedBy, c.UpdateDate });  // testing using filteredConstants rather than dispayedConstants

            ////"Business logic" method that filters constants by the facilNo (applicable for mater-detail also by changing the where clause)
            ////var _constants = (from c in constants
            ////                        where (facilNo == null || facilNo == FacilNo)
            ////                        select e).ToList();

            ////UI processing logic that filter constants by name and paginates them
            //var filteredConstants = (from c in constants
            //                         where (param.sSearch == null || c.ConstantName.ToLower().Contains(param.sSearch.ToLower()))
            //                         select c).ToList();
            //var result = from c in filteredConstants.Skip(param.iDisplayStart).Take(param.iDisplayLength)
            //             select (c => new { c.ConstantName, c.StartDate, c.EndDate, c.Value, c.Notes, c.UpdatedBy, c.UpdateDate });

            return Json(new
            {
                sEcho = param.sEcho,
                iTotalRecords = allConstants.Count(),
                iTotalDisplayRecords = filteredConstants.Count(),
                aaData = result
            },
                        JsonRequestBehavior.AllowGet);
        }

        //private void CheckSelectedFacility()
        //{
        //    if (HttpContext.Session["facilName"] != null)
        //    {
        //        _facilName = HttpContext.Session["facilName"].ToString();
        //        _facilNo = FacilityManager.GetList().Where(f => f.FacilName == _facilName).Select(f => f.FacilNo).SingleOrDefault();
        //    }
        //    else
        //    {
        //        _facilName = String.Empty;
        //        _facilNo = 0;
        //    }
        //}

    }

}

