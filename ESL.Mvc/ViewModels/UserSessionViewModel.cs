using ESL.Core.Models.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace ESL.Mvc.ViewModels
{
    public record class UserSessionViewModel
    {
        [Required]
        [Display(Name = "User ID")]
        public string? UserID { get; set; }

        [Required]
        //[DataType(DataType.Password)]
        [Display(Name = "Facility")]
        public int? FacilNo { get; set; }

        [Required]
        [Display(Name = "Operator Type")]
        public OperatorType? OpType { get; set; }

        [Required]
        [Display(Name = "Shift: Day/Night")]
        public Shift? Shft { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }

        public IEnumerable<SelectListItem> OpTypeSelectList { get; set; } = new List<SelectListItem>();

        public IEnumerable<SelectListItem> ShiftSelectList { get; set; } = new List<SelectListItem>();

        // Consider using ViewComponent or PlantService
        // public SelectList Plants { get; set; }
    }
}
