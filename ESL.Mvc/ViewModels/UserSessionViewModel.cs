using ESL.Core.Models.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace ESL.Mvc.ViewModels
{
    public record class UserSessionViewModel
    {
        [RegularExpression(@"'[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}")]
        [Display(Name = "Session ID")] 
        public required Guid SessionID { get; set; }

        [Display(Name = "User ID")]
        public required string? UserID { get; set; }

        public int? EmployeeNo => int.Parse(UserID.AsSpan(1));

        public string? UserRole { get; set; }
             
        [Display(Name = "Plant")]
        public int? SelectedPlantId { get; set; }

        [Display(Name = "Operator Type")]
        public OperatorType? SelectedOperatorType { get; set; }

        [Required]
        [Display(Name = "Shift: Day/Night")]
        public Shift? SelectedShift { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }

        public IEnumerable<SelectListItem> FacilSelectList { get; set; } = new List<SelectListItem>();
        //{
        //    new SelectListItem { Value = "1", Text = "Primary" },
        //    new SelectListItem { Value = "2", Text = "Secondary" }
        //};

        //public IEnumerable<SelectListItem> OpTypeSelectList { get; set; } = new List<SelectListItem>
        //{
        //    new SelectListItem { Value = "1", Text = "Primary" },
        //    new SelectListItem { Value = "2", Text = "Secondary" }
        //};

        //public IEnumerable<SelectListItem> ShiftSelectList { get; set; } = new List<SelectListItem>
        //{
        //    new SelectListItem { Value = "1", Text = "Day" },
        //    new SelectListItem { Value = "2", Text = "Night" }
        //};

        public IEnumerable<SelectListItem> OpTypeSelectList { get; set; } = new List<SelectListItem>();

        public IEnumerable<SelectListItem> ShiftSelectList { get; set; } = new List<SelectListItem>();

        // Consider using ViewComponent or PlantService
        // public SelectList Plants { get; set; }
    }
}
