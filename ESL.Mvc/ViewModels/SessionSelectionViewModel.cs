using ESL.Core.Models.Enums;

namespace ESL.Mvc.ViewModels
{
    public class SessionSelectionViewModel
    {
        public int? EmployeeNo { get; set; }
        public int? SelectedPlantId { get; set; }

        // Radio button options
        public OperatorType OperatorSelectionType { get; set; }

        public Shift ShiftSelectionType { get; set; }
    }
}
