using ESL.Core.Models.ComplexTypes;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace ESL.Core.Models
{
    /// <summary>
    /// The EOS class represents an EOS that belongs to a <see cref="EOS"> EOS</see>.
    /// </summary>
    [PrimaryKey(nameof(FacilNo), nameof(LogTypeNo), nameof(EventID), nameof(EventID_RevNo))]
    [Table($"ESL_{nameof(EOS)}")]
    public partial record EOS // : LogEvent
    {
        #region Private Variables

        private string _CrLf = "<br />"; // Environment.NewLine ; // "\\r?\\n"; "<br />"; "\r\n";

        #endregion

        #region Public Properties

        public EOS() { }

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
        //[DisplayName("Created By")]
        //[Required(ErrorMessage = "Need to select a name from pull-down list.  Please try again.")]
        [ForeignKey(nameof(CreatedBy_Employee))]
        [Column(nameof(CreatedBy))]
        public int? CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the createdDate of the FlowChange.
        /// </summary>
        [DataObjectField(false, false, false)]
        [DisplayName("Created Date")]
        [Column(nameof(CreatedDate))]
        public DateTime? CreatedDate { get; set; }

        [DataObjectField(false, false, true, 7)]
        [ForeignKey(nameof(ReportedBy_Employee))]
        [Column(nameof(ReportedBy))]
        public int? ReportedBy { get; set; }

        [DataObjectField(false, false, true, 7)]
        [ForeignKey(nameof(ReportedTo_Employee))]
        [Column(nameof(ReportedTo))]
        public int? ReportedTo { get; set; }

        [DataObjectField(false, false, true)]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Column(nameof(ReportedDate))]
        public DateTime? ReportedDate { get; set; }

        [DataObjectField(false, false, true, 5)]
        [Column(nameof(ReportedTime))]
        public string? ReportedTime { get; set; }

        [DataObjectField(false, false, false, 120)]
        [Column(nameof(EquipmentInvolved))]
        public string EquipmentInvolved { get; set; } = string.Empty;

        [DataObjectField(false, false, false, 200)]
        [Column(nameof(Location))]
        public string Location { get; set; } = string.Empty;

        [DataObjectField(false, false, true, 7)]
        [ForeignKey(nameof(ReleasedBy_Employee))]
        [Column(nameof(ReleasedBy))]
        public int? ReleasedBy { get; set; }

        [DataObjectField(false, false, true)]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Column(nameof(ReleasedDate))]
        public DateTime? ReleasedDate { get; set; }

        [DataObjectField(false, false, true, 5)]
        [Column(nameof(ReleasedTime))]
        public string? ReleasedTime { get; set; }

        [DataObjectField(false, false, true, 100)]
        [Column(nameof(ReleaseType))]
        public string? ReleaseType { get; set; }

        [DataObjectField(false, false, true, 100)]
        [Column(nameof(TagsInstalled))]
        public string? TagsInstalled { get; set; }

        [DataObjectField(false, false, true, 100)]
        [Column(nameof(TagsRemoved))]
        public string? TagsRemoved { get; set; }

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
        /// <summary>
        /// Gets or sets the yr of the FlowChange.
        /// </summary>
        [DataObjectField(false, false, false, 2)]
        //[NotNullOrEmpty(Key = "DetailsNotEmpty")]
        //[RegularExpression("^d{2}$", ErrorMessage = "Please enter YY format.")]
        [DisplayName("Year")]
        [Column(nameof(Yr))]
        public string Yr { get; set; } = DateTime.Now.Year.ToString();

        /// <summary>
        /// Gets or sets the seqNo of the FlowChange.
        /// </summary>
        [DataObjectField(false, false, false, 6)]
        [DisplayName("Sequence No.")]
        [Column(nameof(SeqNo))]
        public int SeqNo { get; set; }

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
        public Employee ReportedBy_Employee { get; set; } = new Employee();

        [NotMapped] 
        public Employee ReportedTo_Employee { get; set; } = new Employee();

        [NotMapped] 
        public Employee ReleasedBy_Employee { get; set; } = new Employee();

        [NotMapped] 
        public Employee Notified_Employee { get; set; } = new Employee();

        /// <summary>
        /// Gets or sets the eventIdentifier of the FlowChange.
        /// </summary>
        //[DataObjectField(false, false, false)]
        //[NotNullOrEmpty(Key = "DetailsNotEmpty")]
        [NotMapped]
        public string EventIdentifier => $"{EventID} / {EventID_RevNo.ToString()}";

        /// <summary>
        /// Gets or sets the eventHighlight of the FlowChange.
        /// </summary>
        [DataObjectField(false, false, false)]
        [NotMapped]
        //[NotNullOrEmpty(Key = "DetailsNotEmpty")
        public string EventHighlight
        {
            get
            {
                string _EventHighlight = String.Empty;

                _EventHighlight = $"Location: {Location}{_CrLf}";

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

        /// <summary>
        /// Gets or sets the eventTrail of the FlowChange.
        /// </summary>
        [DataObjectField(false, false, false)]
        [NotMapped]
        //[NotNullOrEmpty(Key = "DetailsNotEmpty")
        public string EventTrail
        {
            get
            {
                string _EventTrail = String.Empty;
                _EventTrail = "Reported By: " + ReportedBy != null ? ReleasedBy_Employee.FullName : "n/a" + _CrLf;

                if (ReportedTo != null)
                {
                    _EventTrail += "Reported To: " + ReportedTo_Employee.FullName + _CrLf;
                }

                if (ReportedDate != null)
                {
                    _EventTrail += "Reported Dt/Tm: " + ReportedDate.Value.ToString("MM/dd/yyyy") + " " + ReportedTime + _CrLf;
                }

                if (!String.IsNullOrEmpty(ReleaseType))
                {
                    switch (ReleaseType)
                    {
                        case "Full Release":
                            _EventTrail += "Full Released by: " + ReleasedBy != null ? ReleasedBy_Employee.FullName : "n/a" + _CrLf; // +"Full Released to: " + ReleasedTo + _CrLf;
#pragma warning disable CS8629 // Nullable value type may be null.
                            _EventTrail += "Full Released Dt/Tm: " + ReleasedDate.Value.ToString("MM/dd/yyyy") + " " + ReleasedTime + _CrLf;
#pragma warning restore CS8629 // Nullable value type may be null.
                            break;
                        case "Test Release": _EventTrail += "Test Released by: " + ReleasedBy != null ? ReleasedBy_Employee.FullName : "n/a" + _CrLf; // +"Test Released to: " + ReleasedTo + _CrLf;
                            _EventTrail += $"Test Released Dt/Tm: {ReleasedDate.Value.ToString("MM/dd/yyyy")} {ReleasedTime}{_CrLf}";
#pragma warning restore CS8629 // Nullable value type may be null.
                            break;
                        case "Transfer": _EventTrail += "Transferred by: " + ReleasedBy != null ? ReleasedBy_Employee.FullName : "n/a" + _CrLf; // +"Released to: " + ReleasedTo + _CrLf;
                            _EventTrail += "Transferred by: " + ReleasedBy != null ? ReleasedBy_Employee.FullName : "n/a" + _CrLf;
                            //_EventTrail += "Released Dt/Tm: " + ReleasedDate.ToString("MM/dd/yyyy") + " " + ReleasedTime + _CrLf;

                            //ToDo: Verify IssuedTo, IssuedDate, IssuedTime  (There are no such fields in EOS table)
                            //_EventTrail += "Transferred to: " + Issuedto != null ? Helpers.GetEmpFullName("ReleasedBy", ReleasedBy.Value, FacilNo) : "n/a" + _CrLf;;
                            //_EventTrail += "Transferred Dt/Tm: " + IssuedDate.ToString("MM/dd/yyyy") + " " + IssuedTime + _CrLf;
                            break;
                    }
                }

                if (!String.IsNullOrEmpty(OperatorID.ToString()))
                {
                    _EventTrail += "Logged By: " + Operator.FullName + _CrLf;
                    _EventTrail += "Logged Dt/Tm: " + UpdateDate.ToString("MM/dd/yyyy hh:mm") + _CrLf;
                }

                if (NotifiedPerson != null)
                {
                    _EventTrail += "Notified Person: " + Notified_Employee.FullName + _CrLf;
                }

                return _EventTrail;
            }
        }

        #endregion
    }
}
