using ESL.Core.Models.ComplexTypes;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace ESL.Core.Models
{
    /// <summary>
    /// The FlowChange class represents an FlowChange that belongs to a <see cref="FlowChange"> FlowChange</see>.
    /// </summary>
    [DebuggerDisplay("FlowChange: {FacilName, nq} {LogTypeName, nq} {EventID, nq} - {EventID_RevNo, nq})")] // ({Type, nq})
    [PrimaryKey(nameof(EventIdentity.FacilNo), nameof(EventIdentity.LogTypeNo), nameof(EventIdentity.EventID), nameof(EventIdentity.EventID_RevNo))]
    [Table($"ESL_({nameof(FlowChange)}s")]
    public partial record FlowChange : LogEvent
    {
        #region Private Variables

        #endregion

        #region Public Properties

        public FlowChange(){ }

        //public EventIdentity EventIdentity { get; set; } = new EventIdentity();
                
        /// <summary>
        /// Gets or sets the requestedBy of the FlowChange.
        /// </summary>
        [DataObjectFieldAttribute(false, false, true, 7)]
        // [Display(Name = "Requested By (optional)")]
        [Column(nameof(RequestedBy))]
        public int? RequestedBy { get; set; }

        /// <summary>
        /// Gets or sets the requestedBy Name of the FlowChange.
        /// </summary>
        [DataObjectFieldAttribute(false, false, true, 80)]
        [Display(Name = "Requested By (optional)")]
        [NotMapped]
        public string RequestedBy_Name => RequestedBy_Employee.FullName;

        /// <summary>
        /// Gets or sets the requestedTo of the FlowChange.
        /// </summary>
        [DataObjectFieldAttribute(false, false, false, 7)]
        // [Display(Name = "Requested To")]
        [Required(ErrorMessage = "Need to select a name from pull-down list.  Please try again.")]
        [Column(nameof(RequestedTo))]
        public int RequestedTo { get; set; }

        /// <summary>
        /// Gets or sets the requestedTo Name of the FlowChange.
        /// </summary>
        [DataObjectFieldAttribute(false, false, false, 80)]
        [Display(Name = "Requested To")]
        [Required(ErrorMessage = "Need to select a name from pull-down list.  Please try again.")]
        [NotMapped]
        public string RequestedTo_Name => RequestedTo_Employee.FullName;
        
        /// <summary>
        /// Gets or sets the requestedDate of the FlowChange.
        /// </summary>
        [DataObjectFieldAttribute(false, false, false)]
        [Display(Name = "Request Date")]
        [Required(ErrorMessage = "Request Date is Required.")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Column(nameof(RequestedDate))] 
        public DateTime RequestedDate { get; set; }

        /// <summary>
        /// Gets or sets the requestedTime of the FlowChange.
        /// </summary>
        [DataObjectFieldAttribute(false, false, false, 5)]
        [Display(Name = "Request Time", Prompt = "hh:mm")]
        [Required(ErrorMessage = "Request Time in hh:mm format is Required.")]
        [RegularExpression("([01]?[0-9]|2[0-3]):[0-5][0-9]")]
        [Column(nameof(RequestedTime))] 
        public string RequestedTime { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the eventDate of the FlowChange.
        /// </summary>
        [DataObjectFieldAttribute(false, false, false)]
        [Display(Name = "Effective Date")]
        [Required(ErrorMessage = "Event Date is Required.")]
        //[UIHint("Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Column(nameof(EventDate))] 
        public DateTime EventDate { get; set; }

        /// <summary>
        /// Gets or sets the eventTime of the FlowChange.
        /// </summary>
        [DataObjectFieldAttribute(false, false, false, 5)]
        [Display(Name = "Effective Time", Prompt = "hh:mm")]
        [RegularExpression("([01]?[0-9]|2[0-3]):[0-5][0-9]", ErrorMessage = "Time must be a valid 24 hour time in HH:MM format")]
        //[RegularExpression("^2[0-3]|[01][0-9]:[0-5][0-9]$")]  // "([01]?[0-9]|2[0-3]):[0-5][0-9]"
        //[RegularExpression("^([0-1]?\d|2[0-3]):([0-5]\d)$")]
        [Column(nameof(EventTime))]
        public string EventTime { get; set; } = string.Empty;
        
        /// <summary>
        /// Gets or sets the offTime of the FlowChange.
        /// </summary>
        [DataObjectFieldAttribute(false, false, true, 5)]
        [Display(Name = "Time Off", Prompt = "hh:mm")]
        [RegularExpression("([01]?[0-9]|2[0-3]):[0-5][0-9]", ErrorMessage = "Time must be a valid 24 hour time in HH:MM format")]
        [Column(nameof(OffTime))] 
        public string? OffTime { get; set; }

        /// <summary>
        /// Gets or sets the meterID of the FlowChange.
        /// </summary>
        [DataObjectFieldAttribute(false,false,false, 30)]
        [Required(ErrorMessage = "Meter ID is missing.  Please select fromt the pull-down.")]
        [Display(Name = "Meter ID")]
        [Column(nameof(MeterID))]
        public string MeterID { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the changedBy of the FlowChange.
        /// </summary>
        [DataObjectFieldAttribute(false, false, true, 10)]
        [Required(ErrorMessage = "Change Value is missing.  When reducing flow, enter a negative sign before the numuber without space.")]
        [Display(Name = "Change +/-", Prompt = "numbers only, no space")]
        [RegularExpression("[-+]?([0-9]*.[0-9]+|[0-9]+)", ErrorMessage = "Change value must be a valid number in digital format.")]  // ^\d+(\.\d{1,2})?$ // ^-*[0-9,\.]+$
        [Column(nameof(ChangeBy))] 
        public string? ChangeBy { get; set; }

        /// <summary>
        /// Gets or sets the newValue of the FlowChange.
        /// </summary>
        [DataObjectFieldAttribute(false, false, true, 10)]
        //[Required(ErrorMessage = "New Value must be equal to the sum of Old and Change Values.")]  // ^[+]?([.]\d+|\d+([.]\d+)?)$
        [Display(Name = "New Flow")]
        [RegularExpression(@"[0-9]*\.?[0-9]+", ErrorMessage = "New value must be a valid positive number in digital format.")]  // "@^(?:[1-9][0-9]*|0)$@"
        [Range(typeof(Decimal), "0", "9999", ErrorMessage = "Price must be a decimal/number between {1} and {2}.")]
        [Column(nameof(NewValue))]
        public decimal? NewValue { get; set; }

        /// <summary>
        /// Gets or sets the unit of the FlowChange.
        /// </summary>
        [DataObjectFieldAttribute(false, false, true, 10)]
        //[Required(ErrorMessage = "All unit must be consistent.")]
        [Display(Name = "New Unit")]
        [Column(nameof(Unit))]
        public string? Unit { get; set; } 

        /// <summary>
        /// Gets or sets the oldValue of the FlowChange.
        /// </summary>
        [DataObjectFieldAttribute(false, false, true, 10)]
        [Display(Name = "Old Value")]
        [RegularExpression(@"[0-9]*\.?[0-9]+", ErrorMessage = "Old value must be a valid positive number in digital format.")] // "@^(?:[1-9][0-9]*|0)$@"  // @"[0-9]*\.?[0-9]+"
        [Range(typeof(Decimal), "0", "9999", ErrorMessage = "Price must be a decimal/number between {1} and {2}.")]
        [Column(nameof(OldValue))]
        public decimal? OldValue { get; set; }

        /// <summary>
        /// Gets or sets the oldUnit of the FlowChange.
        /// </summary>
        [DataObjectFieldAttribute(false, false, true, 10)]
        [Required(ErrorMessage = "All unit must be consistent.")]
        [Display(Name = "Old Unit")]
        [Column("OldUnit")] 
        public string? OldUnit { get; set; }

        /// <summary>
        /// Gets or sets the changedByUnit of the FlowChange.
        /// </summary>
        [DataObjectFieldAttribute(false, false, true, 10)]
        [Required(ErrorMessage = "All unit must be consistent.")]
        [Display(Name = "ChangeBy Unit")]
        [Column(nameof(ChangeByUnit))] 
        public string? ChangeByUnit { get; set; }

        /// <summary>
        /// Gets or sets the accepted of the FlowChange.
        /// </summary>
        [DataObjectFieldAttribute(false, false, true, 10)]
        [Display(Name = "Acceptance Status")]
        [Column(nameof(Accepted))] 
        public string? Accepted { get; set; }

        public Update Update { get; set; } = new Update();

        public Employee RequestedBy_Employee { get; set; } = new Employee();

        public Employee RequestedTo_Employee { get; set; } = new Employee();

        /// <summary>
        /// Gets or sets the eventIdentifier of the FlowChange.
        /// </summary>
        [DataObjectFieldAttribute(false, false, false)]
        //[NotNullOrEmpty(Key = "DetailsNotEmpty")]
        [Display(Name = "Event ID / Revision")]
        [NotMapped]
        public string EventIdentifier => EventID + " / " + Convert.ToString(EventID_RevNo);

        /// <summary>
        /// Gets or sets the eventHighlight of the FlowChange.
        /// </summary>
        [DataObjectFieldAttribute(false, false, false)]
        //[NotNullOrEmpty(Key = "DetailsNotEmpty")
        [Display(Name = "Event Hightlight")]
        [NotMapped]
        public string EventHighlight
        {
            get
            {
                string _EventHighlight = String.Empty;
                _EventHighlight = $"Meter ID: {MeterID}{_CrLf}";

                if (Convert.ToDecimal(ChangeBy) < 0)
                {
                    _EventHighlight += "Decrease:  ";
                }
                else if (Convert.ToDecimal(ChangeBy) > 0)
                {
                    _EventHighlight += "Increase:  ";
                }

                _EventHighlight += $"{ChangeBy} {ChangeByUnit}{_CrLf}";

                if (!String.IsNullOrEmpty(Convert.ToString(NewValue)))
                {
                    _EventHighlight += $"New Value: {Convert.ToString(NewValue)} {Unit}{_CrLf}";
                }

                _EventHighlight += $"Effective Dt/Tm: {EventDate.ToString("MM/dd/yyyy")} {EventTime}{_CrLf}";

                if (!String.IsNullOrEmpty(OffTime))
                {
                    _EventHighlight += $"Time Off: {OffTime}{_CrLf}";
                }

                if (!String.IsNullOrEmpty(RelatedTo))
                {
                    _EventHighlight += $"Related to Event Nos.: {RelatedTo}{_CrLf}";
                }

                if (!String.IsNullOrEmpty(WorkOrders))
                {
                    _EventHighlight += $"Work Order Nos.: {WorkOrders}{_CrLf}";
                }

                if (!String.IsNullOrEmpty(Notes))
                {
                    _EventHighlight += $"Additional Notes: {Notes}{_CrLf}";
                }

                _EventHighlight += $"Scanned docs stored: {ScanDocsNo}";

                return _EventHighlight ;
            }
        }           

        /// <summary>
        /// Gets or sets the eventHeader of the FlowChange.
        /// </summary>
        [DataObjectFieldAttribute(false, false, false)]
        //[NotNullOrEmpty(Key = "DetailsNotEmpty")
        [NotMapped]
        public string EventHeader
        {
            get
            {
                string _EventHeader = "Details for ";
                if (Accepted == "Y")
                {
                    _EventHeader += "Real Time ";
                }
                else
                {
                    _EventHeader += "Pre-Scheduled ";
                }
                _EventHeader += $"Flow Change on MeterID {MeterID}  on {EventDate.ToString("MM/dd/yyyy")}  at {EventTime}";

                return _EventHeader; 
            }
        }

        /// <summary>
        /// Gets or sets the eventTrail of the FlowChange.
        /// </summary>
        [DataObjectFieldAttribute(false, false, false)]
        [Display(Name = "Action History")]
        [NotMapped]
        public string EventTrail
        {
            get
            {
                string _EventTrail = String.Empty;

                if (RequestedBy != 0 && RequestedBy.HasValue)
                {
                    _EventTrail = $"Requested By: {RequestedBy_Employee.FullName}{_CrLf}";
                }
                else
                {
                    _EventTrail = $"Requested By: n/a {_CrLf}";
                }

                if (RequestedTo != 0)
                {
                    _EventTrail += $"Requested To: {RequestedTo_Employee.FullName}{_CrLf}";
                }
                else
                {
                    _EventTrail += $"Requested To: n/a {_CrLf}";
                }


                _EventTrail += $"Requested Dt/Tm: {RequestedDate.ToString("MM/dd/yyyy")} {RequestedTime}{_CrLf}";


                _EventTrail += $"Logged By: {Operator.FullName}{ _CrLf}";
                _EventTrail += $"Logged Dt/Tm: {Update.UpdateDate.ToString("MM/dd/yyyy hh:mm")}{_CrLf}";

                if (NotifiedPerson.HasValue)
                {
                    _EventTrail += $"Notified Person: {NotifiedPerson_Employee.FullName}{_CrLf}";
                }
                else
                {
                    _EventTrail += $"Notified Person: n/a";
                }

                return _EventTrail;
            }
        }

        #endregion
    }
}
