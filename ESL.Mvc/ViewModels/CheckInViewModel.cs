using ESL.Core.Models.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace ESL.Mvc.ViewModels
{
    public class CheckInViewModel
    {
        //refine and check the data types

        [Required]
        [Display(Name = "User ID")]
        public string? UserID { get; set; }

        [Required]
        [Display(Name = "Facility")]
        public int? FacilNo { get; set; }

        [Required]
        [Display(Name = "Shift: Day/Night")]
        public Shift? Shift { get; set; } 

        [Required]
        [Display(Name = "Operator Type")]
        public OperatorType? OpType { get; set; }

        public IEnumerable<SelectListItem> optionOpType { get; set; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "1", Text = "Primary" },
            new SelectListItem { Value = "2", Text = "Secondary" }
        };

        public IEnumerable<SelectListItem> optionShift { get; set; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "1", Text = "Day" },
            new SelectListItem { Value = "2", Text = "Night" }
        };
    }
}
