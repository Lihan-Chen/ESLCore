using ESL.Core.Models.BusinessEntities;
using ESL.Mvc.Services;
using ESL.Mvc.ViewModels;
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

        int? _facilNo;

        private async Task<SelectList> PlantSelectList(int? facilNo)
        {
            _facilNo = facilNo;
            return await _employeeService.GetFacilSelectList(facilNo); // Task.FromResult(items)
        }
        #region InvokeAsync
        public async Task<IViewComponentResult> InvokeAsync(int? facilNo)
        {
            string _view = "Default";

            // https://stackoverflow.com/questions/20387205/asp-net-mvc-selectlist-in-viewmodel
            PlantMenuViewModel plants = new PlantMenuViewModel { FacilNo = _facilNo, PlantSelectList = PlantSelectList(_facilNo = 1).Result };
            return View(_view, plants);
        }
        #endregion
    }
}
