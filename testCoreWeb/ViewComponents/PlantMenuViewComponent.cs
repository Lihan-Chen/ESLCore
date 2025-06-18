using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using testCoreWeb.ViewModels;

namespace testCoreWeb.ViewComponents
{
    public class PlantMenuViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int numFacils)
        {
            // Simulating data retrieval from FacilEnum
            var facilList = Enum.GetValues(typeof(FacilEnum))
                .Cast<FacilEnum>()
                .Select(f => new SelectListItem
                {
                    Value = ((int)f).ToString(), // Assuming facilId is the enum's integer value
                    Text = f.ToString()          // Assuming facilName is the enum's name
                })
                .ToList();

            return View(facilList);

            //var assignmentVM = new AssignmentViewModel
            //{
            //    Shifts = new SelectList(_context.Roles.ToList(), "Id", "Name"),
            //    OpTypes = new SelectList(_context.Categories.ToList(), "Id", "Name")
            //};

            //var facils = new List<int, string>();

            //var selectFacilList = new SelectList(int, string);
        }
    }
}
