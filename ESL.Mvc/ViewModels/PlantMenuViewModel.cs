using Microsoft.AspNetCore.Mvc.Rendering;

namespace ESL.Mvc.ViewModels
{
    public class PlantMenuViewModel
    {
        public int? FacilNo;
        public SelectList? PlantSelectList { get; set; }
    }
}
