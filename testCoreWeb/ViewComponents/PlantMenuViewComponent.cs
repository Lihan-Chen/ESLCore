using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace testCoreWeb.ViewComponents
{
    public class PlantMenuViewComponent : ViewComponent
    {
        
        
        public async Task<IViewComponentResult> InvokeAsync(int numFacils)
        {
            //var assignmentVM = new AssignmentViewModel
            //{
            //    Shifts = new SelectList(_context.Roles.ToList(), "Id", "Name"),
            //    OpTypes = new SelectList(_context.Categories.ToList(), "Id", "Name")
            //};

            //var facils = new List<int, string>();
            
            //var selectFacilList = new SelectList(int, string);

            return View();
        }
    }
}
