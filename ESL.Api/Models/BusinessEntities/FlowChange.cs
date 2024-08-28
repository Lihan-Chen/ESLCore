using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Diagnostics;

namespace ESL.Api.Models.BusinessEntities
{
    /// <summary>
    /// The FlowChange class represents an FlowChange that belongs to a <see cref="FlowChange"> FlowChange</see>.
    /// </summary>
    [DebuggerDisplay("FlowChange: {FacilName, nq} {LogTypeName, nq} {EventID, nq} - {EventID_RevNo, nq})")] // ({Type, nq})
    [PrimaryKey(nameof(FacilNo), nameof(LogTypeNo), nameof(EventID), nameof(EventID_RevNo))]
    [Table($"ESL_FLOWCHANGES")]
    public partial record FlowChange
    {
        #region Private Variables

        internal string _CrLf = "<br />"; // Environment.NewLine ; // "\\r?\\n"; "<br />"; "\r\n";

        #endregion

        #region Public Properties

        //public FlowChange() { }

        /// <summary>
        /// Gets or sets the FacilNo of the Facility.
        /// <summary>
        /// Gets or sets the FacilNo of the Facility.
        /// </summary>
        [DataObjectField(true, true, false, 2)]
        [DisplayName("Facil. No.")]
        [Column("FACILNO", TypeName = "NUMBER")]
        public int FacilNo { get; set; }
        /// <summary>
        /// Gets or sets the LogTypeNo of the Log Type.
        /// </summary>
        [DataObjectField(true, true, false, 2)]
        [DisplayName("Log Type No.")]
        [Column("LOGTYPENO", TypeName = "NUMBER")]
        public int LogTypeNo { get; set; }

        /// <summary>
        /// Gets or sets the EventID of the Event.
        /// </summary>
        [DataObjectField(true, true, false, 20)]
        [DisplayName("Event ID")]
        [Column("EVENTID", TypeName = "VARCHAR2")]
        public string EventID { get; set; } = null!;
        /// <summary>
        /// Gets or sets the EventID_RevNo of the Event.
        /// </summary>
        [DataObjectField(true, true, false, 2)]
        [DisplayName("Revision No.")]
        [Column("EVENTID_REVNO", TypeName = "NUMBER")]
        public int EventID_RevNo { get; set; }

        /// <summary>
        /// Gets or sets the FacilName of the event.
        /// </summary>
        /// 
        [DataObjectField(false, false, false)]
        [DisplayName("Facility")]
        [NotMapped]
        public string FacilName { get; set; }

        /// <summary>
        /// Gets or sets the LogTypeName of the FlowChange.
        /// </summary>
        /// 
        [DataObjectField(false, false, false)]
        [DisplayName("Log Type")]
        [NotMapped]
        public string LogTypeName { get; set; } = null!;

        /// <summary>
        /// Gets or sets the OperatorID of the FlowChange.
        /// </summary>
        [DataObjectField(false, false, false, 7)]
        [DisplayName("Operator")]
        [Required(ErrorMessage = "Need to select a name from pull-down list.  Please try again.")]
        [ForeignKey(nameof(Operator))]
        [Column("OPERATORID", TypeName = "NUMBER")]
        public int OperatorID { get; set; }

        /// <summary>
        /// Gets or sets the CreatedBy of the FlowChange.
        /// </summary>
        [DataObjectField(false, false, true, 7)]
        //[DisplayName("Created By")]
        //[Required(ErrorMessage = "Need to select a name from pull-down list.  Please try again.")]
        [ForeignKey(nameof(CreatedBy_Employee))]
        [Column("CREATEDBY", TypeName = "NUMBER")]
        public int? CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the CreatedDate of the FlowChange.
        /// </summary>
        [DataObjectField(false, false, false)]
        [DisplayName("Created Date")]
        [Column("CREATEDDATE", TypeName = "DATE")]
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets the requestedBy of the FlowChange.
        /// </summary>
        [DataObjectField(false, false, true, 7)]
        // [DisplayName("Requested By (optional)")]
        [Column("REQUESTEDBY", TypeName = "NUMBER")]
        public int? RequestedBy { get; set; }

        /// <summary>
        /// Gets or sets the requestedBy Name of the FlowChange.
        /// </summary>
        [DataObjectField(false, false, true, 80)]
        [DisplayName("Requested By (optional)")]
        [NotMapped]
        public string RequestedBy_Name => RequestedBy_Employee.FullName;

        /// <summary>
        /// Gets or sets the requestedTo of the FlowChange.
        /// </summary>
        [DataObjectField(false, false, false, 7)]
        // [DisplayName("Requested To")]
        [Required(ErrorMessage = "Need to select a name from pull-down list.  Please try again.")]
        [Column("REQUESTEDTO", TypeName = "NUMBER")]
        public int RequestedTo { get; set; }

        /// <summary>
        /// Gets or sets the requestedTo Name of the FlowChange.
        /// </summary>
        [DataObjectField(false, false, false, 80)]
        [DisplayName("Requested To")]
        [Required(ErrorMessage = "Need to select a name from pull-down list.  Please try again.")]
        [NotMapped]
        public string RequestedTo_Name => RequestedTo_Employee.FullName;

        /// <summary>
        /// Gets or sets the RequestedDate of the FlowChange.
        /// </summary>
        [DataObjectField(false, false, false)]
        [DisplayName("Request Date")]
        [Required(ErrorMessage = "Request Date is Required.")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Column("REQUESTEDDATE", TypeName = "DATE")]
        public DateTime RequestedDate { get; set; }

        /// <summary>
        /// Gets or sets the RequestedTime of the FlowChange.
        /// </summary>
        [DataObjectField(false, false, false, 5)]
        [Display(Name = "Request Time", Prompt = "hh:mm")]
        [Required(ErrorMessage = "Request Time in hh:mm format is Required.")]
        [RegularExpression("([01]?[0-9]|2[0-3]):[0-5][0-9]")]
        [Column("REQUESTEDTIME", TypeName = "VARCHAR2")]
        public string RequestedTime { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the EventDate of the FlowChange.
        /// </summary>
        [DataObjectField(false, false, false)]
        [DisplayName("Effective Date")]
        [Required(ErrorMessage = "Event Date is Required.")]
        //[UIHint("Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Column("EVENTDATE", TypeName = "DATE")]
        public DateTime EventDate { get; set; }

        /// <summary>
        /// Gets or sets the EventTime of the FlowChange.
        /// </summary>
        [DataObjectField(false, false, false, 5)]
        [Display(Name = "Effective Time", Prompt = "hh:mm")]
        [RegularExpression("([01]?[0-9]|2[0-3]):[0-5][0-9]", ErrorMessage = "Time must be a valid 24 hour time in HH:MM format")]
        //[RegularExpression("^2[0-3]|[01][0-9]:[0-5][0-9]$")]  // "([01]?[0-9]|2[0-3]):[0-5][0-9]"
        //[RegularExpression("^([0-1]?\d|2[0-3]):([0-5]\d)$")]
        [Column("EVENTTIME", TypeName = "VARCHAR2")]
        public string EventTime { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the offTime of the FlowChange.
        /// </summary>
        [DataObjectField(false, false, true, 5)]
        [Display(Name = "Time Off", Prompt = "hh:mm")]
        [RegularExpression("([01]?[0-9]|2[0-3]):[0-5][0-9]", ErrorMessage = "Time must be a valid 24 hour time in HH:MM format")]
        [Column("OFFTIME", TypeName = "VARCHAR2")]
        public string? OffTime { get; set; }

        /// <summary>
        /// Gets or sets the MeterID of the FlowChange.
        /// </summary>
        [DataObjectField(false, false, false, 30)]
        [Required(ErrorMessage = "Meter ID is missing.  Please select fromt the pull-down.")]
        [DisplayName("Meter ID")]
        [Column("METERID", TypeName = "VARCHAR2")]
        public string MeterID { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the changedBy of the FlowChange.
        /// </summary>
        [DataObjectField(false, false, true, 10)]
        [Required(ErrorMessage = "Change Value is missing.  When reducing flow, enter a negative sign before the numuber without space.")]
        [Display(Name = "Change +/-", Prompt = "numbers only, no space")]
        [RegularExpression("[-+]?([0-9]*.[0-9]+|[0-9]+)", ErrorMessage = "Change value must be a valid number in digital format.")]  // ^\d+(\.\d{1,2})?$ // ^-*[0-9,\.]+$
        [Column("CHANGEBY", TypeName = "VARCHAR2")]
        public string? ChangeBy { get; set; }

        /// <summary>
        /// Gets or sets the NewValue of the FlowChange.
        /// </summary>
        [DataObjectField(false, false, true, 10)]
        //[Required(ErrorMessage = "New Value must be equal to the sum of Old and Change Values.")]  // ^[+]?([.]\d+|\d+([.]\d+)?)$
        [DisplayName("New Flow")]
        [RegularExpression(@"[0-9]*\.?[0-9]+", ErrorMessage = "New value must be a valid positive number in digital format.")]  // "@^(?:[1-9][0-9]*|0)$@"
        [Range(typeof(Decimal), "0", "9999", ErrorMessage = "Price must be a decimal/number between {1} and {2}.")]
        [Column("NEWVALUE", TypeName = "NUMBER")]
        public int? NewValue { get; set; }

        /// <summary>
        /// Gets or sets the unit of the FlowChange.
        /// </summary>
        [DataObjectField(false, false, true, 10)]
        //[Required(ErrorMessage = "All unit must be consistent.")]
        [DisplayName("New Unit")]
        [Column("NEWUNIT", TypeName = "VARCHAR2")]
        public string? Unit { get; set; }

        /// <summary>
        /// Gets or sets the OldValue of the FlowChange.
        /// </summary>
        [DataObjectField(false, false, true, 10)]
        [DisplayName("Old Value")]
        [RegularExpression(@"[0-9]*\.?[0-9]+", ErrorMessage = "Old value must be a valid positive number in digital format.")] // "@^(?:[1-9][0-9]*|0)$@"  // @"[0-9]*\.?[0-9]+"
        [Range(typeof(Decimal), "0", "9999", ErrorMessage = "Price must be a decimal/number between {1} and {2}.")]
        [Column("OLDVALUE", TypeName = "NUMBER")]
        public int? OldValue { get; set; }

        /// <summary>
        /// Gets or sets the OldUnit of the FlowChange.
        /// </summary>
        [DataObjectField(false, false, true, 10)]
        [Required(ErrorMessage = "All unit must be consistent.")]
        [DisplayName("Old Unit")]
        [Column("OLDUNIT", TypeName = "VARCHAR2")]
        public string? OldUnit { get; set; }

        /// <summary>
        /// Gets or sets the changedByUnit of the FlowChange.
        /// </summary>
        [DataObjectField(false, false, true, 10)]
        [Required(ErrorMessage = "All unit must be consistent.")]
        [DisplayName("ChangeBy Unit")]
        [Column("CHANGEBYUNIT", TypeName = "VARCHAR2")]
        public string? ChangeByUnit { get; set; }

        /// <summary>
        /// Gets or sets the accepted of the FlowChange.
        /// </summary>
        [DataObjectField(false, false, true, 10)]
        [DisplayName("Acceptance Status")]
        [Column("ACCEPTED", TypeName = "VARCHAR2")]
        public string? Accepted { get; set; }

        /// <summary>
        /// Gets or sets the ModifyFlag of the FlowChange.
        /// </summary>
        [DataObjectField(false, false, true, 100)]
        [DisplayName("Modify Flag")]
        [Column("MODIFYFLAG", TypeName = "VARCHAR2")]
        public string? ModifyFlag { get; set; }

        /// <summary>
        /// Gets or sets the ModifiedBy of the FlowChange.
        /// </summary>
        [DataObjectField(false, false, true, 7)]
        [DisplayName("Modified By")]
        [ForeignKey(nameof(ModifiedBy_Employee))]
        [Column("MODIFIEDBY", TypeName = "NUMBER")]
        public int? ModifiedBy { get; set; }

        /// <summary>
        /// Gets or sets the modifyDate of the FlowChange.
        /// </summary>
        [DataObjectField(false, false, true)]
        [DisplayName("Date Modified")]
        [Column("MODIFIEDDATE", TypeName = "DATE")]
        public DateTime? ModifiedDate { get; set; }

        /// <summary>
        /// Gets or sets the notes of the FlowChange.
        /// </summary>
        [DataObjectField(false, false, true, 400)]
        [DisplayName("Notes")]
        [Column("NOTES", TypeName = "VARCHAR2")]
        public string? Notes { get; set; }

        /// <summary>
        /// Gets or sets the NotifiedFacil of the FlowChange.
        /// </summary>
        [DataObjectField(false, false, true, 200)]
        [DisplayName("Notified Facility")]
        [Column("NOTIFIEDFACIL", TypeName = "VARCHAR2")]
        public string? NotifiedFacil { get; set; }

        /// <summary>
        /// Gets or sets the NotifiedPerson of the FlowChange.
        /// </summary>
        [DataObjectField(false, false, true, 7)]
        // [DisplayName("Notified Person (optional)")]
        [ForeignKey(nameof(NotifiedPerson_Employee))]
        [Column("NOTIFIEDPERSON", TypeName = "NUMBER")]
        public int? NotifiedPerson { get; set; }

        /// <summary>
        /// Gets or sets the NotifiedPerson of the FlowChange.
        /// </summary>
        [DataObjectField(false, false, true, 80)]
        [DisplayName("Notified Person (optional)")]
        [NotMapped]
        public string? NotifiedPerson_Name => NotifiedPerson_Employee.FullName;

        /// <summary>
        /// Gets or sets the ShiftNo of the FlowChange.
        /// </summary>
        [DataObjectField(false, false, true, 2)]
        [DisplayName("Shift No")]
        [Column("SHIFTNO", TypeName = "NUMBER")]
        public int? ShiftNo { get; set; }
        /// <summary>
        /// Gets or sets the yr of the FlowChange.
        /// </summary>
        [DataObjectField(false, false, false, 2)]
        //[NotNullOrEmpty(Key = "DetailsNotEmpty")]
        //[RegularExpression("^d{2}$", ErrorMessage = "Please enter YY format.")]
        [DisplayName("Year")]
        [Column("YR", TypeName = "VARCHAR2")]
        public string Yr { get; set; } = DateTime.Now.Year.ToString();

        /// <summary>
        /// Gets or sets the SeqNo of the FlowChange.
        /// </summary>
        [DataObjectField(false, false, false, 6)]
        [DisplayName("Sequence No.")]
        [Column("SEQNO", TypeName = "NUMBER")]
        public int SeqNo { get; set; }

        // <summary>
        /// Gets or sets the UID of the record.
        /// </summary>
        [DataObjectField(false, false, false, 60)]
        [DisplayName("Updated By")]
        [Column("UPDATEDBY", TypeName = "VARCHAR2")]
        public string? UpdatedBy { get; set; } = null!;

        /// <summary>
        /// Gets or sets the UpdateDate of the record.
        /// </summary>
        [DataObjectField(false, false, false)]
        [DisplayName("Updated on")]
        [Column("UPDATEDATE", TypeName = "DATE")]
        public DateTime? UpdateDate { get; set; }

        /// <summary>
        /// Gets or sets the WorkOrders of the FlowChange.
        /// </summary>
        [DataObjectField(false, false, true, 100)]
        [DisplayName("Work Orders")]
        [Column("WORKORDERS", TypeName = "VARCHAR2")]
        public string? WorkOrders { get; set; }

        /// <summary>
        /// Gets or sets the RelatedTo of the FlowChange.
        /// </summary>
        [DataObjectField(false, false, true, 200)]
        [DisplayName("Rnelated To")]
        [Column("RELATEDTO", TypeName = "VARCHAR2")]
        public string? RelatedTo { get; set; }

        /// <summary>
        /// Gets or sets the OperatorType of the FlowChange.
        /// </summary>
        [DataObjectField(false, false, true, 15)]
        [DisplayName("Operator Type (Optional)")]
        [Column("OPERATORTYPE", TypeName = "VARCHAR2")]
        public string? OperatorType { get; set; }

        /// <summary>
        /// Gets or sets the ScanDocsNo of the AllEvents.
        /// </summary>
        [DataObjectField(false, false, true, 2)]
        [NotMapped]
        public int ScanDocsNo { get; set; }

        [NotMapped]
        public Facility Facility { get; init; } = new Facility();

        [NotMapped]
        public LogType LogType { get; init; } = new LogType();

        [NotMapped]
        public Employee Operator { get; init; } = new Employee();

        [NotMapped]
        public Employee CreatedBy_Employee { get; init; } = new Employee();

        [NotMapped]
        public Employee ModifiedBy_Employee { get; init; } = new Employee();

        [NotMapped]
        public Employee NotifiedPerson_Employee { get; init; } = new Employee();

        [NotMapped]
        public Employee UpdatedBy_Employee { get; init; } = new Employee();

        [NotMapped]
        public Facility NotifiedFacility { get; init; } = new Facility();


        [NotMapped]
        public Employee RequestedBy_Employee { get; set; } = new Employee();

        [NotMapped]
        public Employee RequestedTo_Employee { get; set; } = new Employee();

        /// <summary>
        /// Gets or sets the EventIDentifier of the FlowChange.
        /// </summary>
        [DataObjectField(false, false, false)]
        //[NotNullOrEmpty(Key = "DetailsNotEmpty")]
        [DisplayName("Event ID / Revision")]
        [NotMapped]
        public string EventIDentifier => EventID + " / " + Convert.ToString(EventID_RevNo);

        /// <summary>
        /// Gets or sets the eventHighlight of the FlowChange.
        /// </summary>
        [DataObjectField(false, false, false)]
        //[NotNullOrEmpty(Key = "DetailsNotEmpty")
        [DisplayName("Event Hightlight")]
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

                return _EventHighlight;
            }
        }

        /// <summary>
        /// Gets or sets the eventHeader of the FlowChange.
        /// </summary>
        [DataObjectField(false, false, false)]
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
        [DataObjectField(false, false, false)]
        [DisplayName("Action History")]
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


                _EventTrail += $"Logged By: {Operator.FullName}{_CrLf}";
                _EventTrail += $"Logged Dt/Tm: {UpdateDate?.ToString("MM/dd/yyyy hh:mm")}{_CrLf}";

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
