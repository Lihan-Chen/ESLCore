using Microsoft.AspNetCore.Mvc.Rendering;

namespace testCoreWeb.ViewModels
{
    public class PlantViewModel
    {
        public int FacilNo {  get; set; }

        //public string FacilName { get; set; }

        public List<SelectListItem> Plants { get; } = new List<SelectListItem>
        { 
            new SelectListItem { Value = "1", Text = "OCC"},
            new SelectListItem { Value = "2", Text = "Diemer"},
            new SelectListItem { Value = "3", Text = "Jensen"},
            new SelectListItem { Value = "4", Text = "Mills"},
            new SelectListItem { Value = "5", Text = "WEymouth"},
            new SelectListItem { Value = "6", Text = "Skinner"},
            new SelectListItem { Value = "7", Text = "Desert"},
            new SelectListItem { Value = "8", Text = "Intake"},
            new SelectListItem { Value = "9", Text = "Gene"},
            new SelectListItem { Value = "10", Text = "Irone"},
            new SelectListItem { Value = "11", Text = "Eagle"},
            new SelectListItem { Value = "12", Text = "Hinds"},
            new SelectListItem { Value = "13", Text = "DVL"},
        };
    }
}
