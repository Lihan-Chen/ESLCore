using ESL.Core.Models.Enums;
using ESL.Infrastructure.DataAccess;
using ESL.Application.Interfaces.IServices;
using ESL.Mvc.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;

namespace ESL.Mvc.Controllers
{
    public class CheckInController : BaseController<CheckInController>
    {
        
        private readonly EslDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger<CheckInController> _logger;
        private readonly ICoreService _coreService;

        private int? _facilNo;
        private string _facilName = string.Empty;
        private bool showAlert = false;
        private ESL.Core.Models.Enums.Shift _shift;

        public CheckInController(EslDbContext context, IHttpContextAccessor httpContextAccessor, ILogger<CheckInController> logger, ICoreService coreService) : base(context, httpContextAccessor, logger, coreService) //, IDownstreamApi downstreamApi
        {
            this._context = context;
            this._httpContextAccessor = httpContextAccessor;
            this._logger = logger;
            this._coreService = coreService;
        }

        // https://github.com/Azure-Samples/active-directory-aspnetcore-webapp-openidconnect-v2/blob/master/5-WebApp-AuthZ/5-1-Roles/Controllers/HomeController.cs
        [Authorize]
        [HttpGet]
        public IActionResult Index(string returnUrl, bool showAlert = false)   // this only checks necessary parameters are available before redirecting to AllEvents/
        {
            Guid sessionId = Guid.Parse(HttpContext.Session.Id);

            showAlert = showAlert.Equals(true);

            // Redirect to select a plant by setting true if facilName is not found
            if (IsNewSession)
            {
                if (showAlert)
                {
                    ViewBag.ShowAlert = true;
                    ViewBag.Alert = "Please check in to a facility to start!";
                }

                ViewBag.ShowCheckIn = true;
                ViewBag.Message = "Please select one facility from the list - ";
                ViewBag.ReturnUrl = this.Url;

                var plants = Enum.GetValues<Plant>()
                    .Cast<OperatorType>()
                    .Select(s => new { ID = s, Name = s.ToString() });

                var myOpTypeList = Enum.GetValues<OperatorType>()
                    .Cast<OperatorType>()
                    .Select(s => new { ID = s, Name = s.ToString() });

                var myShiftList = Enum.GetValues<Core.Models.Enums.Shift>()
                    .Cast<Core.Models.Enums.Shift>()
                    .Select(s => new { ID = s, Name = s.ToString() });

                if (DateTime.Now.TimeOfDay >= TimeSpan.Parse(ShiftStartTimeString) && DateTime.Now.TimeOfDay < TimeSpan.Parse(ShiftEndTimeString))
                {
                    _shift = ESL.Core.Models.Enums.Shift.Day;
                }
                else
                {
                    _shift = ESL.Core.Models.Enums.Shift.Night;
                }

                ViewBag.Shift = _shift;

                var model = new UserSessionViewModel()
                {
                    SessionID = sessionId,
                    UserID = UserID,
                    SelectedShift = _shift,
                    SelectedPlantId = FacilNo,
                    FacilSelectList = new SelectList(plants, "ID", "Name", _facilNo),
                    OpTypeSelectList = new SelectList(myOpTypeList, "ID", "Name"),
                    ShiftSelectList = new SelectList(myShiftList, "ID", "Name", _shift)
                };

                ViewBag.ReturnUrl = returnUrl;

                return View(model);

                //// CheckInViewModel
                //CheckInViewModel checkInVM = new CheckInViewModel
                //{
                //    UserID = UserID,
                //    Shift = _shift,
                //    FacilNo = FacilNo,
                //    optionOpType = new SelectList(myOpTypeList, "ID", "Name"),
                //    optionShift = new SelectList(myShiftList, "ID", "Name", _shift)
                //    // FacilName = FacilName,
                //    //IsSuperAdmin = IsSuperAdmin,
                //    //IsAdmin = IsAdmin,
                //    //IsOperator = IsOperator,
                //    //IsCheckingFacility = IsCheckingFacility,
                //    //ShowAlert = showAlert
                //};

                //return View("Index", checkInVM);
            }

            return RedirectToAction("Index", "AllEvents");
        }

        public ActionResult SelectPlant()
        {
            // FacilNo = 0;
            HttpContext.Session.SetString(SessionKeyUserEmployeeNo, String.Empty);
            HttpContext.Session.SetInt32(SessionKeyUserSelectedPlant, (int)this.FacilNo);
            
            // IsCheckingFacility = false;
            showAlert = false;

            return RedirectToAction("index", new { ReturnUrl = this.Url, showAlert });
        }

        public IActionResult IndexVC()
        {
            return ViewComponent("PlantMenu");
        }

        /// <summary>
        /// Set Session for facility from Home/Index
        /// </summary>
        /// <param name="facilNo"></param>
        /// <returns></returns>
        //[ChildActionOnly]
        public async Task<ActionResult> CheckIn(string userName, string shift, string operatorType, int facilNo, string returnUrl)
        {
            if (FacilNo != facilNo)
            {
                //string[] _roles = Roles.GetRolesForUser(UserID);
                //Roles.RemoveUserFromRoles(UserID, _roles);

                // set FacilNo to session
                facilNo = FacilNo ?? 0;
                HttpContext.Session.SetInt32(SessionKeyUserSelectedPlant, facilNo);                               
            }

            _facilName = (await _coreService.GetAllPlants())
                    .Where(predicate: p => p.FacilNo == facilNo)
                    .Select(p => p.FacilName)
                    .FirstOrDefault() ?? string.Empty;

            FacilName = _facilName;

            string _userID = SessionUser.Result?.EmployeeID;

            // reset all roles
            string? _role = await _coreService.GetRole(_userID!, facilNo);

            // To do IsInRole not defined in IEmployeeService
            //IsSuperAdmin = false;
            //IsAdmin = false;
            //IsOperator = _employeeService.IsInRole(_userID, _role, facilNo);
            // CheckFacil = false;
            showAlert = false;
            //IsSuperAdmin = isSuperAdminfromOracle(UserID);
            //IsAdmin = isAdminfromOracle(UserID);
            //IsOperator = isOperatorfromOracle(UserID);

            // set session variables
            // HttpContext.Session.SetString(SessionKeyUserSelectedPlant) = FacilName;
            
            // Session["CheckFacil"] = CheckFacil;

            return Redirect(returnUrl);
        }

        #region Helpers

        #endregion
    }
}
