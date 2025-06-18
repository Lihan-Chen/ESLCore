using ESL.Core.Models.Enums;
using ESL.Infrastructure.DataAccess;
using ESL.Mvc.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ESL.Mvc.Controllers
{
    [Authorize]
    public class OnDutyController(EslDbContext context, IHttpContextAccessor httpContextAccessor) : EslBaseController(context, httpContextAccessor)
    {
        protected readonly EslDbContext _context = context ?? throw new ArgumentNullException(nameof(context));

        protected readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));

        //// from EslBaseController
        //int employeeNo = UserEmployeeNo  ?? 0;
        //string userName = User.Identity!.IsAuthenticated ? User.FindFirst(c => c.Type == "name")?.Value : string.Empty;

        [HttpGet]
        public IActionResult Index()
        {
            // Get authenticated user info from Azure AD claims
            var employeeNo = UserEmployeeNo; // User.Claims.FirstOrDefault(c => c.Type == "employeeId")?.Value;
            var username = User.Identity!.IsAuthenticated ? User.FindFirst(c => c.Type == "name")?.Value : string.Empty;
            
            var model = new OnDutyViewModel
            {
                EmployeeNo = (int)UserEmployeeNo,
                UserName = UserName,
                //IsAuthenticated = IsAuthenticated,
                SelectedShift = Shift.Day // Default to day shift
            };

            // Get user role from Oracle DB
            if (model.EmployeeNo > 0)
            {
                string _employeeID = model.EmployeeNo.ToString().Length == 4 ? $"U0{model.EmployeeNo}" : $"U{model.EmployeeNo}";
                
                var userRole = _context.UserRoles
                    .FirstOrDefault(u => u.UserID == _employeeID);

                model.UserRole = userRole?.Role;
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(OnDutyViewModel model)
        {
            if (!ModelState.IsValid)
            {
                // Repopulate user information on validation failure
                model.UserName = User.Identity?.Name;
                //model.IsAuthenticated = User.Identity?.IsAuthenticated ?? false;

                // Get user role from Oracle DB
                if (model.EmployeeNo > 0)
                {
                    string _employeeID = model.EmployeeNo.ToString().Length == 4 ? $"U0{model.EmployeeNo}" : $"U{model.EmployeeNo}";

                    var userRole = _context.UserRoles
                        .FirstOrDefault(u => u.UserID == _employeeID);

                    model.UserRole = userRole?.Role;
                }

                return View(model);
            }

            // from EslBaseController to save to session
            SaveToSession(model);

            var returnUrl = HttpContext.Session.GetString("ReturnUrl");
            if (!string.IsNullOrEmpty(returnUrl))
            {
                HttpContext.Session.Remove("ReturnUrl");
                return LocalRedirect(returnUrl);
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult SignOut()
        {
            // Clear session
            HttpContext.Session.Clear();

            // Sign out of Azure AD
            return SignOut(
                new AuthenticationProperties { RedirectUri = "/" },
                "Cookies", "OpenIdConnect");
        }

        //private void SaveToSession(OnDutyViewModel model)
        //{
        //    // Save primary session data
        //    HttpContext.Session.SetInt32("EmployeeNo", model.EmployeeNo);
        //    HttpContext.Session.SetString("UserName", model.UserName ?? string.Empty);
        //    HttpContext.Session.SetString("UserRole", model.UserRole ?? "Operator");
        //    HttpContext.Session.SetString("Shift", model.SelectedShift.ToString());

        //    // Save plant related data
        //    if (model.SelectedPlantId.HasValue)
        //    {
        //        HttpContext.Session.SetInt32("PlantId", model.SelectedPlantId.Value);
        //        HttpContext.Session.SetString("PlantName", PlantHelper.GetPlantName(model.SelectedPlantId.Value));
        //    }

        //    // Save timestamp for session tracking
        //    HttpContext.Session.SetString("SessionStartTime", DateTime.Now.ToString("o"));
        //}
    }
}
