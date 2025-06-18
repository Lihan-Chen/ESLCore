using Microsoft.AspNetCore.Mvc.Rendering;

namespace ESL.Mvc.ViewModels
{
    public class PlantMenuViewModel
    {
        public int? FacilNo;
        public SelectList? PlantSelectList { get; set; }
    }

    //public enum OperatorSelectionType
    //{
    //    Primary = 1,
    //    Secondary = 2
    //}

    //public enum ShiftSelectionType
    //{
    //    Day = 1,
    //    Night = 2
    //}
}
