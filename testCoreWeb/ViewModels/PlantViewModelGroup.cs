using Microsoft.AspNetCore.Mvc.Rendering;

namespace testCoreWeb.ViewModels
{
    public class PlantViewModelGroup
    {
        public PlantViewModelGroup()
        {
            var OCC = new SelectListGroup { Name = "OCC" };
            var PumpingPlant = new SelectListGroup { Name = "Pumping Plant" };
            var TreatmentPlant = new SelectListGroup { Name = "Treatment Plant" };

            Plants = new List<SelectListItem>
            {
                new SelectListItem { Value = "1", Text = "OCC", Group = OCC},
                new SelectListItem { Value = "2", Text = "Diemer", Group = PumpingPlant},
                new SelectListItem { Value = "3", Text = "Jensen", Group = PumpingPlant},
                new SelectListItem { Value = "4", Text = "Mills", Group = PumpingPlant},
                new SelectListItem { Value = "5", Text = "WEymouth", Group = PumpingPlant},
                new SelectListItem { Value = "6", Text = "Skinner", Group = PumpingPlant},
                new SelectListItem { Value = "7", Text = "Desert", Group = OCC},
                new SelectListItem { Value = "8", Text = "Intake", Group = TreatmentPlant},
                new SelectListItem { Value = "9", Text = "Gene", Group = TreatmentPlant},
                new SelectListItem { Value = "10", Text = "Irone", Group = TreatmentPlant},
                new SelectListItem { Value = "11", Text = "Eagle", Group = TreatmentPlant},
                new SelectListItem { Value = "12", Text = "Hinds", Group = TreatmentPlant},
                new SelectListItem { Value = "13", Text = "DVL", Group = TreatmentPlant}
            };
        }
    
        public int FacilNo { get; set; }

        public List<SelectListItem> Plants { get; }
    }
}
