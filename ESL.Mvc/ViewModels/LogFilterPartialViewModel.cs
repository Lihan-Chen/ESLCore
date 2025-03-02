using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace ESL.Mvc.ViewModels
{
    public partial record class LogFilterPartialViewModel
    {
        [Required]
        [Display(Name = "Facility")]
        public int? FacilNo { get; set; }

        [Display(Name = "Log Type")]
        public int? LogTypeNo { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name = "Start Date")]
        public DateOnly? StartDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name = "End Date")]
        public DateOnly? EndDate { get; set; }

        [Display(Name = "Primary Operator?")]
        public Boolean OperatorType { get; set; }

        [Display(Name = "Keyword")]
        [RegularExpression("([a-zA-Z0-9_]+)", ErrorMessage = "Enter only alphabets and numbers of Keywords")]  //[a-zA-Z0-9_] or "\w"
        public string? CurrentFilter { get; set; }

        public SelectList FacilNos { get; set; } = new SelectList(new List<SelectListItem>());
        public SelectList LogTypeNos { get; set; } = new SelectList(new List<SelectListItem>());
    }
}
