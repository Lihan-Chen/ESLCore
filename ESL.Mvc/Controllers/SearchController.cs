using ESL.Core.Models.Enums;
using ESL.Mvc.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Graph.SecurityNamespace;
using X.PagedList;

namespace ESL.Mvc.Controllers
{
    public class SearchController : Controller
    {
        //
        // GET: /Search/
        DateTime _Today = System.DateTime.Now.Date;
        DateTime _Yesterday = System.DateTime.Now.Date.AddDays(-1);

        public const string FacilNoSessionKey = "FacilNo";
        int _facilNo = 0;
        int _logTypeNo = 0;
        string _startDate = string.Empty;
        string _endDate = string.Empty;
        DateTime? initialStartDate;
        int _daysOffSet = -1;
        string _operatorType = String.Empty;
        bool _opType = true;
        string _facilName = string.Empty;
        string _optionAll = string.Empty;
        string _searchKeyWords = string.Empty;

        int _pageSize = 10;
        // string yesterdayDate = System.DateTime.Now.AddDays(-1).Date.ToString("MM/dd/yyyy");
        // string todayDate = System.DateTime.Now.Date.ToString("MM/dd/yyyy");

        [Authorize]
        [HttpGet]
        public IActionResult Index(SearchFilterPartialViewModel searchFilterPartial, int? logTypeNo, DateTime? startDate, DateTime? endDate, string searchString, int? page, string optionAll, bool operatorType = false)
        {
            bool _showAlert = false;

            // _facilNo = searchFilterPartial.FacilNo; // != 0 ? searchFilterPartial.FacilNo.Value : FacilNo != 0 ? FacilNo : _facilNo;

            _facilNo = searchFilterPartial.FacilNo ?? _facilNo;

            if (_facilNo == 0)
            {
                if (HttpContext.Request.GetTypedHeaders().Referer?.AbsolutePath != "/")
                {
                    _showAlert = true;
                }
                return RedirectToAction("Index", "Home", new { ReturnUrl = this.Url, ShowAlert = _showAlert });
            }
            else
            {
                _facilName = FacilityManager.GetItem(_facilNo).FacilName.Split(' ').ElementAt(0);
            }

            if (!logTypeNo.HasValue)
            {
                _logTypeNo = searchFilterPartial.LogTypeNo.HasValue ? searchFilterPartial.LogTypeNo.Value : 0;
            }
            else
            {
                _logTypeNo = logTypeNo.Value;
            }

            if (Session["OperatorType"] == null || Session["Shift"] == null)
            {
                return RedirectToAction("Login", "Account", new { ReturnUrl = this.Url });
                // RedirectToLocal("/");
            }
            // Set up default values
            DateTime _enDt = searchFilterPartial.EndDate.HasValue ? searchFilterPartial.EndDate.Value : endDate.HasValue ? endDate.Value : System.DateTime.Now.Date; //.AddDays(-30) for testing on dev7
            DateTime _stDt = searchFilterPartial.StartDate.HasValue ? searchFilterPartial.StartDate.Value : startDate.HasValue ? startDate.Value : _enDt.AddDays(_daysOffSet);

            Session["startDate"] = _stDt;
            Session["endDate"] = _enDt;

            searchString = !String.IsNullOrEmpty(searchFilterPartial.SearchValues) ? searchFilterPartial.SearchValues : searchString;

            // _operatorType = Session["OperatorType"].ToString();

            //_operatorType = searchFilterPartial.OperatorType == true ? "Primary" : operatorType.Equals(true) ? "Primary" : _operatorType;
            //_opType = _operatorType == "Primary" ? true : false;
            _opType = operatorType ? true : searchFilterPartial.OperatorType;

            //_shiftNo = Session["Shift"].ToString() == "Day" ? 1 : 2;

            //_optionAll = optionAll != null ? optionAll : "OR";

            _optionAll = !String.IsNullOrEmpty(searchFilterPartial.OptionAll) ? searchFilterPartial.OptionAll : !String.IsNullOrEmpty(optionAll) ? optionAll : "OR";

            ViewBag.Message = "Please select the Start-End Dates and check if Primary.";
            ViewBag.Title = "Search";

            // string OptionAll = String.Empty;  // not used in stored procedure
            var SearchOptionTypes = Enum.GetValues(typeof(SearchOptionType))  // AND = 1, OR = 0
                .Cast<SearchOptionType>()
                .Select(s => new { ID = s, Name = s.ToString() });

            // Prepare and set up model and ViewBag
            // FacilityList facilities = (FacilityList)FacilityManager.GetList();
            var facilAbbrList = FacilityManager.GetList().AsEnumerable().Where(f => f.FacilNo <= 13).Select(f => new SelectListItem { Value = f.FacilNo.ToString(), Text = f.FacilAbbr }).ToList();
            var logTypeNames = LogTypeManager.GetList().AsEnumerable().Where(l => l.LogTypeNo < 7).Select(l => new SelectListItem { Value = l.LogTypeNo.ToString(), Text = l.LogTypeName }).ToList(); //.Where(f => f.LogTypeNo )

            var defaultItem = new SelectListItem()
            {
                Value = "0",
                Text = "All Events",
                Selected = true
            };

            //defaultItem.Value = "0";
            //defaultItem.Text = "All Events";
            //defaultItem.Selected = true;
            logTypeNames.Add(defaultItem);
            ViewBag.Title = "Searching All Events for " + _facilName;

            SearchFilterPartialViewModel _searchFilterPartial = new SearchFilterPartialViewModel()
            {
                FacilNo = _facilNo,
                LogTypeNo = _logTypeNo != 0 ? _logTypeNo : 0,
                StartDate = _stDt,
                EndDate = _enDt,
                OperatorType = _opType,
                OptionAll = _optionAll != null ? _optionAll : "OR",
                SearchValues = searchString,
                FacilNos = new SelectList(facilAbbrList, "Value", "Text", _facilNo),
                LogTypeNos = new SelectList(logTypeNames, "Value", "Text", _logTypeNo),
                OptionAllTypes = new SelectList(SearchOptionTypes, "ID", "Name")
            };

            var viewmodel = new SearchListViewModel()
            {
                SearchFilterPartial = _searchFilterPartial
            };

            if (!_searchFilterPartial.StartDate.HasValue || !_searchFilterPartial.EndDate.HasValue)
            {
                ViewBag.Message = "Please select the start and end dates, with (optional) keywords, to search releated logs.";
                ViewBag.ShowSearchList = false;
                return View("Index", viewmodel);
            }

            if (_stDt != null && _enDt != null)
            {
                ViewBag.FacilSelected = FacilityManager.GetItem(_facilNo).FacilName.Split(' ').ElementAt(0);
                ViewBag.Title = "Search Logs for " + _facilName;
                ViewBag.ShowSearchList = true;
                string _startDate = _stDt.ToString("MM/dd/yyyy");
                string _endDate = _enDt.ToString("MM/dd/yyyy");

                Searches _searchList = SearchManager.GetList(_facilNo, _logTypeNo, _startDate, _endDate, _operatorType, _optionAll, searchString);

                if (_searchList != null)
                {
                    int _Count = _searchList.Count();

                    int pageSize = _pageSize;
                    int pageIndex = (page ?? 1);
                    IPagedList<Search> SearchAsIPagedList = _searchList.ToPagedList(pageIndex, pageSize);

                    viewmodel.count = _Count;
                    viewmodel.SearchPagedList = SearchAsIPagedList;
                }
                else
                {
                    ViewBag.Message = "There are no records found.";
                }
                return View("Index", viewmodel);
            }
            else
            {
                ViewBag.ShowSearchList = false;
                //ViewBag.Message = "Please select the date range, with keywords (optional) to search related logs.";
                return View();
            }
        }
    }
}
