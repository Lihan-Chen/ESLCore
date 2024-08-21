using ESL.Core.Models.ComplexTypes;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace ESL.Core.Models
{
    /// <summary>
    /// The ClearanceIssues class represents an ClearanceIssues that belongs to a <see cref="ClearanceIssue"> ClearanceIssues</see>.
    /// </summary>
    [DebuggerDisplay("ClearanceIssues : {FacilName, nq} {LogTypeName, nq} {EventID, nq} - {EventID_RevNo, nq})")] // ({Type, nq})
    [PrimaryKey(nameof(FacilNo), nameof(LogTypeNo), nameof(EventID), nameof(EventID_RevNo))]
    [Table($"ESL_{nameof(ClearanceIssue)}s")]
    public partial record ClearanceIssue // : LogEvent
    {

        #region Private Variables

        private string _CrLf = "<br />"; // Environment.NewLine ; // "\\r?\\n"; "<br />"; "\r\n";

        #endregion

        #region Public Properties

        public ClearanceIssue() { }

        //public EventIdentity EventIdentity { get; set; } = new EventIdentity();

        //public EventIdentity EventIdentity { get; set; } = new EventIdentity();

        /// <summary>
        /// Gets or sets the facilNo of the Facility.
        /// </summary>
        [DataObjectField(true, true, false, 2)]
        [DisplayName("Facil. No.")]
        [ForeignKey(nameof(Facility))]
        public int FacilNo { get; set; }
        /// <summary>
        /// Gets or sets the logTypeNo of the Log Type.
        /// </summary>
        [DataObjectField(true, true, false, 2)]
        [DisplayName("Log Type No.")]
        [ForeignKey(nameof(LogType))]
        public int LogTypeNo { get; set; }

        /// <summary>
        /// Gets or sets the eventID of the Event.
        /// </summary>
        [DataObjectField(true, true, false, 20)]
        [DisplayName("Event ID")]
        public string EventID { get; set; } = null!;
        /// <summary>
        /// Gets or sets the eventID_RevNo of the Event.
        /// </summary>
        [DataObjectField(true, true, false, 2)]
        [DisplayName("Revision No.")]
        public int EventID_RevNo { get; set; }

        /// <summary>
        /// Gets or sets the facilName of the event.
        /// </summary>
        /// 
        [DataObjectField(false, false, false)]
        [DisplayName("Facility")]
        [NotMapped]
        public string FacilName { get; set; }

        /// <summary>
        /// Gets or sets the logTypeName of the FlowChange.
        /// </summary>
        /// 
        [DataObjectField(false, false, false)]
        [DisplayName("Log Type")]
        [NotMapped]
        public string LogTypeName { get; set; } = null!;

        /// <summary>
        /// Gets or sets the operatorID of the FlowChange.
        /// </summary>
        [DataObjectField(false, false, false, 7)]
        [DisplayName("Operator")]
        [Required(ErrorMessage = "Need to select a name from pull-down list.  Please try again.")]
        [ForeignKey(nameof(Operator))]
        [Column(nameof(OperatorID))]
        public int OperatorID { get; set; }

        /// <summary>
        /// Gets or sets the createdBy of the FlowChange.
        /// </summary>
        [DataObjectField(false, false, true, 7)]
        [DisplayName("Created By")]
        [Required(ErrorMessage = "Need to select a name from pull-down list.  Please try again.")]
        [ForeignKey(nameof(CreatedBy_Employee))]
        [Column(nameof(CreatedBy))]
        public int? CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the createdDate of the FlowChange.
        /// </summary>
        [DataObjectField(false, false, true)]
        [DataType("date")]
        [DisplayName("Created Date")]
        [Column(nameof(CreatedDate))]
        public DateTime? CreatedDate { get; set; }

        [DataObjectField(false, false, false, 7)]
        [Column(nameof(IssuedTo))]
        public int IssuedTo { get; set; }

        [DataObjectField(false, false, false, 7)]
        [Column(nameof(IssuedBy))]
        public int IssuedBy { get; set; }

        /// <summary>
        /// Gets or sets the issuedDate of the ClearanceIssues .
        /// </summary>
        [DataObjectField(false, false, false)]
        [Column(nameof(IssuedDate))]
        public DateTime IssuedDate { get; set; }

        /// <summary>
        /// Gets or sets the eventTime of the ClearanceIssues .
        /// </summary>
        [DataObjectField(false, false, false, 5)]
        [Display(Name = "Issued Time", Prompt = "hh:mm")]
        [RegularExpression("([01]?[0-9]|2[0-3]):[0-5][0-9]", ErrorMessage = "Time must be a valid 24 hour time in HH:MM format")]
        [Column(nameof(IssuedTime))]
        public string IssuedTime { get; set; } = null!;

        /// <summary>
        /// Gets or sets the modifyFlag of the FlowChange.
        /// </summary>
        [DataObjectField(false, false, true, 100)]
        [DisplayName("Modify Flag")]
        [Column(nameof(ModifyFlag))]
        public string? ModifyFlag { get; set; }

        /// <summary>
        /// Gets or sets the modifiedBy of the FlowChange.
        /// </summary>
        [DataObjectField(false, false, true, 7)]
        [DisplayName("Modified By")]
        [ForeignKey(nameof(ModifiedBy_Employee))]
        [Column(nameof(ModifiedBy))]
        public int? ModifiedBy { get; set; }

        /// <summary>
        /// Gets or sets the modifyDate of the FlowChange.
        /// </summary>
        [DataObjectField(false, false, true)]
        [DisplayName("Date Modified")]
        [Column(nameof(ModifiedDate))]
        public DateTime? ModifiedDate { get; set; }

        /// <summary>
        /// Gets or sets the yr of the FlowChange.
        /// </summary>
        [DataObjectField(false, false, false, 2)]
        //[NotNullOrEmpty(Key = "DetailsNotEmpty")]
        //[RegularExpression("^d{2}$", ErrorMessage = "Please enter YY format.")]
        [DisplayName("Year")]
        [Column(nameof(Yr))]
        public string Yr { get; set; } = DateTime.Now.Year.ToString();


        [DataObjectField(false, false, false, 6)]
        [Column(nameof(FacilAbbr))]
        public string FacilAbbr { get; set; } = null!;

        /// <summary>
        /// Gets or sets the seqNo of the FlowChange.
        /// </summary>
        [DataObjectField(false, false, false, 6)]
        [DisplayName("Sequence No.")]
        [Column(nameof(SeqNo))]
        public int SeqNo { get; set; }

        [DataObjectField(false, false, false, 2)]
        [Column(nameof(ClearanceType))]
        public string ClearanceType { get; set; } = null!;

        [DataObjectField(false, false, false, 300)]
        [Column(nameof(ClearanceZone))]
        public string ClearanceZone { get; set; } = null!;

        [DataObjectField(false, false, true, 200)]
        [Column(nameof(Location))]
        public string? Location { get; set; }

        [DataObjectField(false, false, true, 600)]
        [Column(nameof(WorkToBePerformed))]
        public string? WorkToBePerformed { get; set; }

        [DataObjectField(false, false, true, 200)]
        [Column(nameof(EquipmentInvolved))]
        public string? EquipmentInvolved { get; set; }

        /// <summary>
        /// Gets or sets the workOrders of the FlowChange.
        /// </summary>
        [DataObjectField(false, false, true, 100)]
        [DisplayName("Work Orders")]
        [Column(nameof(WorkOrders))]
        public string? WorkOrders { get; set; }

        /// <summary>
        /// Gets or sets the relatedTo of the FlowChange.
        /// </summary>
        [DataObjectField(false, false, true, 200)]
        [DisplayName("Rnelated To")]
        [Column(nameof(RelatedTo))]
        public string? RelatedTo { get; set; }

        /// <summary>
        /// Gets or sets the notes of the FlowChange.
        /// </summary>
        [DataObjectField(false, false, true, 400)]
        [DisplayName("Notes")]
        [Column(nameof(Notes))]
        public string? Notes { get; set; }

        /// <summary>
        /// Gets or sets the notifiedFacil of the FlowChange.
        /// </summary>
        [DataObjectField(false, false, true, 200)]
        [DisplayName("Notified Facility")]
        [Column(nameof(NotifiedFacil))]
        public string? NotifiedFacil { get; set; }

        /// <summary>
        /// Gets or sets the notifiedPerson of the FlowChange.
        /// </summary>
        [DataObjectField(false, false, true, 7)]
        // [DisplayName("Notified Person (optional)")]
        [ForeignKey(nameof(NotifiedPerson_Employee))]
        [Column(nameof(NotifiedPerson))]
        public int? NotifiedPerson { get; set; }

        /// <summary>
        /// Gets or sets the notifiedPerson of the FlowChange.
        /// </summary>
        [DataObjectField(false, false, true, 80)]
        [DisplayName("Notified Person (optional)")]
        [NotMapped]
        public string? NotifiedPerson_Name => NotifiedPerson_Employee.FullName;

        /// <summary>
        /// Gets or sets the shiftNo of the FlowChange.
        /// </summary>
        [DataObjectField(false, false, true, 2)]
        [DisplayName("Shift No")]
        [Column(nameof(ShiftNo))]
        public int? ShiftNo { get; set; }

        [DataObjectField(false, false, true, 7)]
        [Column(nameof(ReleasedTo))]
        public int? ReleasedTo { get; set; }

        [DataObjectField(false, false, true, 7)]
        [Column(nameof(ReleasedBy))]
        public int? ReleasedBy { get; set; }

        [DataObjectField(false, false, true)]
        [Column(nameof(ReleasedDate))]
        public DateTime? ReleasedDate { get; set; }

        [DataObjectField(false, false, true, 5)]
        [Column(nameof(ReleasedTime))]
        public string? ReleasedTime { get; set; }

        [DataObjectField(false, false, true, 30)]
        [Column(nameof(ReleaseType))]
        public string? ReleaseType { get; set; }

        [DataObjectField(false, false, true, 200)]
        [Column(nameof(TagsRemoved))]
        public string? TagsRemoved { get; set; }

        /// <summary>
        /// Gets or sets the operatorType of the FlowChange.
        /// </summary>
        [DataObjectField(false, false, true, 15)]
        [DisplayName("Operator Type (Optional)")]
        [Column(nameof(OperatorType))]
        public string? OperatorType { get; set; }

        /// <summary>
        /// Gets or sets the ScanDocsNo of the AllEvents.
        /// </summary>
        [DataObjectField(false, false, true, 2)]
        [NotMapped]
        public int ScanDocsNo { get; set; }
        
        [DataObjectField(false, false, true, 20)]
        [Column(nameof(ClearanceID))] 
        public string? ClearanceID { get; set; }

        //public Update Update { get; set; } = new Update();

        /// <summary>
        /// Gets or sets the UID of the record.
        /// </summary>
        [DataObjectField(false, false, false, 60)]
        [DisplayName("Updated By")]
        public string UpdatedBy { get; set; } = null!;

        /// <summary>
        /// Gets or sets the updateDate of the record.
        /// </summary>
        [DataObjectField(false, false, false)]
        [DisplayName("Updated on")]
        public DateTimeOffset UpdateDate { get; set; }

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
        public Employee IssuedBy_Employee { get; set; } = new Employee();

        [NotMapped]
        public Employee IssuedTo_Employee { get; set; } = new Employee();

        [NotMapped]public Employee ReleasedBy_Employee { get; set;} = new Employee();

        [NotMapped]
        public Employee ReleasedTo_Employee { get;set; } = new Employee();
        
        /// <summary>
        /// Gets or sets the eventIdentifier of the FlowChange.
        /// </summary>
        //[DataObjectField(false, false, false)]
        [NotMapped]
        public string EventIdentifier => $"{ClearanceID} / {Convert.ToString(EventID_RevNo)}";

        /// <summary>
        /// Gets or sets the eventHighlight of the FlowChange.
        /// </summary>
        [NotMapped]
        public string EventHighlight
        {
            get
            {
                string _EventHighlight = null!;

                if (!String.IsNullOrEmpty(Location))
                {
                    _EventHighlight = $"Location: {Location}{_CrLf}";
                }

                if (!String.IsNullOrEmpty(ClearanceZone))
                {
                    _EventHighlight += $"Clearance Area: {ClearanceZone}{ _CrLf}";
                }

                if (!String.IsNullOrEmpty(WorkToBePerformed))
                {
                    _EventHighlight += $"Work to be performed: {WorkToBePerformed}{_CrLf}";
                }

                if (!String.IsNullOrEmpty(EquipmentInvolved))
                {
                    _EventHighlight += $"Equipment involved: {EquipmentInvolved}{_CrLf}";
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

                if (!String.IsNullOrEmpty(ReleaseType))
                {
                    _EventHighlight += $"Tags removed: {TagsRemoved}{_CrLf}";
                }

                _EventHighlight += "Scanned docs stored: " + ScanDocsNo;

                return _EventHighlight;
            }
        }

        // need to add "Scanned Docs Stored: " (scandocs.count) when scanned docs directory are established on servers, or just ignore for now.

        /// <summary>
        /// Gets or sets the eventTrail of the FlowChange.
        /// </summary>
        
        [NotMapped]
        public string EventTrail
        {
            get
            {
                string _EventTrail = null!;
                string _ReleasedBy = null!;
                string _ReleasedTo = null!;
                string _IssuedTo = null!;

                _EventTrail = $"Issued to: {IssuedBy_Employee.FullName}{_CrLf}";

                _EventTrail += $"Issued by: {IssuedBy_Employee.FullName}{_CrLf}";

                 if (IssuedDate != DateTime.MinValue)
                {
                    _EventTrail += $"Requested Dt/Tm: {IssuedDate.ToString("MM/dd/yyyy")} {IssuedTime}{_CrLf}";
                }

                _ReleasedBy = ReleasedBy.HasValue ? ReleasedBy_Employee.FullName : "n/a";

                _ReleasedTo = ReleasedTo.HasValue ? ReleasedTo_Employee.FullName : "n/a";

                _IssuedTo = IssuedTo_Employee.FullName;


                switch (ReleaseType)
                {
                    case "Full Release": 
                        _EventTrail += $"Full Released by: { _ReleasedBy}{_CrLf}Full Released to: {_ReleasedTo}{_CrLf}";                  
                        if (ReleasedDate.HasValue) _EventTrail += $"Full Released Dt/Tm: {ReleasedDate.Value.ToString("MM/dd/yyyy")} {ReleasedTime}{_CrLf}";
                        break;

                    case "Test Release": 
                        _EventTrail += $"Test Released by: {_ReleasedBy }{_CrLf}Test Released to: {_ReleasedTo}{_CrLf}";
                        if (ReleasedDate.HasValue) _EventTrail += $"Test Released Dt/Tm: {ReleasedDate.Value.ToString("MM/dd/yyyy")} {ReleasedTime}{_CrLf}";
                        
                        break;

                    case "Transfer":
                        _EventTrail += $"Released by: {_ReleasedBy}{_CrLf} + Issud to: {_IssuedTo}{_CrLf}";
                        _EventTrail += $"Transfer Dt/Tm: {IssuedDate.ToString("MM/dd/yyyy")} {IssuedTime}{_CrLf}";
                        //_EventTrail += "Released Dt/Tm: " + (ReleasedDate.HasValue ? ReleasedDate.Value.ToString("MM/dd/yyyy") : "n/a") + " " + ReleasedTime + _CrLf;
 
                        //_EventTrail = "Transferred to: " + IssuedTo.ToString() + _CrLf + "Relased by: " + IssuedTo.ToString() + _CrLf;
                        //_EventTrail += "Transferred Dt/Tm: " + IssuedDate.ToString("MM/dd/yyyy") + " " + IssuedTime + _CrLf;
                        break;
                }

                if (!String.IsNullOrEmpty(OperatorID.ToString()))
                {
                    _EventTrail += $"Logged By: {Operator.FullName}{_CrLf}";
                    _EventTrail += $"Logged Dt/Tm: {UpdateDate.ToString("MM/dd/yyyy hh:mm")}{_CrLf}";
                }

                //if (!String.IsNullOrEmpty(NotifiedPerson))
                if (!String.IsNullOrEmpty(NotifiedPerson.ToString()))
                {
                    _EventTrail += $"Notified Person: {NotifiedPerson_Employee.FullName}{_CrLf}";
                }

                return _EventTrail;
            }
        }

        #endregion

    }
}
