using ESL.Core.Models.Enums;
using ESL.Mvc.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design;
using OperatorSelectionType = ESL.Core.Models.Enums.OperatorType;
using ShiftSelectionType = ESL.Core.Models.Enums.Shift;

namespace ESL.Mvc.Controllers
{
    public class SessionController : Controller
    {
        public IActionResult Index()
        {
            var model = new SessionSelectionViewModel
            {
                EmployeeNo = 6337,  // SessionUser.EmployeeNo,
                OperatorSelectionType = OperatorSelectionType.Primary,
                ShiftSelectionType = ShiftSelectionType.Day,
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(SessionSelectionViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Handle the selection
            var plantName = model.SelectedPlantId.HasValue
                ? PlantHelper.GetPlantName(model.SelectedPlantId.Value)
                : "No plant selected";

            // Add your business logic here
            TempData["Message"] = $"Selected plant: {model.SelectedPlantId}, name: {plantName}";

            return RedirectToAction(nameof(Index));
        }
    }
}
