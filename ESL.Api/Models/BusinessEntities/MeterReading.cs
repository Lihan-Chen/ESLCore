using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ESL.Api.Models.BusinessEntities
{
    public partial record MeterReading
    {
        /// <summary>
        /// Gets or sets the meterID of the FlowChange.
        /// </summary>
        [DataObjectField(false, false, false, 30)]
        [Required(ErrorMessage = "Meter ID is missing.  Please select fromt the pull-down.")]
        [Display(Name = "Meter ID")]
        public string MeterID { get; set; } = null!;

        /// <summary>
        /// Gets or sets the oldValue of the FlowChange.
        /// </summary>
        [DataObjectField(false, false, true, 10)]
        [Display(Name = "New Value")]
        public decimal? Value { get; set; }

        /// <summary>
        /// Gets or sets the oldUnit of the FlowChange.
        /// </summary>
        [DataObjectField(false, false, true, 10)]
        [Required(ErrorMessage = "All unit must be consistent.")]
        [Display(Name = "Unit")]
        public string? Unit { get; set; } = null!;

        /// <summary>
        /// Gets or sets the eventDate of the FlowChange.
        /// </summary>
        [DataObjectField(false, false, false)]
        [Display(Name = "Effective Date")]
        [Required(ErrorMessage = "Event Date is Required.")]
        //[UIHint("Date")]
        [DataType(DataType.Date)]
        public DateTime EventDate { get; set; }

        /// <summary>
        /// Gets or sets the eventTime of the FlowChange.
        /// </summary>
        [DataObjectField(false, false, false, 5)]
        [Display(Name = "Effective Time", Prompt = "hh:mm")]
        [RegularExpression("([01]?[0-9]|2[0-3]):[0-5][0-9]", ErrorMessage = "Time must be a valid 24 hour time in HH:MM format")]
        //[RegularExpression("^2[0-3]|[01][0-9]:[0-5][0-9]$")]  // "([01]?[0-9]|2[0-3]):[0-5][0-9]"
        //[RegularExpression("^([0-1]?\d|2[0-3]):([0-5]\d)$")]
        public string EventTime { get; set; } = null!;

        /// <summary>
        /// Gets or sets the offTime of the FlowChange.
        /// </summary>
        [DataObjectField(false, false, true, 5)]
        [Display(Name = "Time Off", Prompt = "hh:mm")]
        [RegularExpression("([01]?[0-9]|2[0-3]):[0-5][0-9]", ErrorMessage = "Time must be a valid 24 hour time in HH:MM format")]
        public string? OffTime { get; set; }

        /// <summary>
        /// Gets or sets the requestedDate of the FlowChange.
        /// </summary>
        [DataObjectField(false, false, false)]
        [Display(Name = "Request Date")]
        [Required(ErrorMessage = "Request Date is Required.")]
        [DataType(DataType.Date)]
        public DateTime RequestedDate { get; set; }

        /// <summary>
        /// Gets or sets the requestedTime of the FlowChange.
        /// </summary>
        [DataObjectField(false, false, false, 5)]
        [Display(Name = "Request Time", Prompt = "hh:mm")]
        [Required(ErrorMessage = "Request Time in hh:mm format is Required.")]
        [RegularExpression("([01]?[0-9]|2[0-3]):[0-5][0-9]")]
        public string RequestedTime { get; set; } = null!;

        /// <summary>
        /// Gets or sets the eventID of the FlowChange.
        /// </summary>
        [DataObjectField(true, true, false, 20)]
        [Display(Name = "Event ID")]
        public string EventID { get; set; } = null!;

        /// <summary>
        /// Gets or sets the eventID_RevNo of the FlowChange.
        /// </summary>
        [DataObjectField(true, true, false, 2)]
        [Display(Name = "Revision No.")]
        public int EventID_RevNo { get; set; }

        /// <summary>
        /// Gets or sets the updateDate of the FlowChange.
        /// </summary>
        [DataObjectField(false, false, false)]
        public DateTime UpdateDate { get; set; }
    }
}
