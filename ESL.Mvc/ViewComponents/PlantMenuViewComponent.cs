using ESL.Core.Models.BusinessEntities;
using ESL.Mvc.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewComponents;


namespace ESL.Mvc.ViewComponents
{
    public class PlantMenuViewComponent : ViewComponent
    {
        private readonly EmployeeService _employeeService;

        public PlantMenuViewComponent(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        private async Task<SelectList> GetPlants()
        {
            return await _employeeService.GetPlantSelectList(); // Task.FromResult(items)
        }
        #region InvokeAsync
        public async Task<IViewComponentResult> InvokeAsync()
        {
            string _view = "Default";
            var plants = await GetPlants();
            return View(_view, plants);
        }
        #endregion
    }
}
