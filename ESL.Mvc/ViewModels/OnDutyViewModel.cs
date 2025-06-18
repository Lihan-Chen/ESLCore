using ESL.Core.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace ESL.Mvc.ViewModels
{
    public class OnDutyViewModel
    {
        public int EmployeeNo { get; set; }
        
        public string? UserName { get; set; }
        
        public string? UserRole { get; set; }

        /// <summary>
        /// Represents the selected shift for the on-duty employee.
        /// If null, it indicates that the employee is not currently assigned to a shift.
        /// </summary>
        [Display(Name = "Shift")]
        public Shift? SelectedShift { get; set; }

        /// <summary>
        /// Represents the selected operator type for the on-duty employee.
        /// If null, it indicates that the employee does not have a primary operator type assigned.
        /// </summary>
        [Display(Name = "Primary?")]
        public OperatorType? SelectedOperatorType { get; set; }

        [Required(ErrorMessage = "Please select a plant")]
        [Display(Name = "Plant")]
        public int SelectedPlantId { get; set; }

        public DateTime StartTime { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Indicates whether the user is authenticated only as opposed to being authenticated and authorized.
        /// </summary>
        public bool IsAuthenticatedOnly => SelectedShift == null || SelectedOperatorType == null;
    }
}
