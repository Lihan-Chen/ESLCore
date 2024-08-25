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
    [Table($"ESL_EOS")]
    public partial record EOS // : LogEvent
    {
        #region Private Variables

        private string _CrLf = "<br />"; // Environment.NewLine ; // "\\r?\\n"; "<br />"; "\r\n";

        #endregion

        #region Public Properties

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
        public string FacilName { get; set; } = null!;

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
        [Column("OPERATORID", TypeName ="NUMBER")]
        public int OperatorID { get; set; }

        /// <summary>
        /// Gets or sets the CreatedBy of the FlowChange.
        /// </summary>
        [DataObjectField(false, false, true, 7)]
        //[DisplayName("Created By")]
        //[Required(ErrorMessage = "Need to select a name from pull-down list.  Please try again.")]
        [ForeignKey(nameof(CreatedBy_Employee))]
        [Column("CREATEDBY", TypeName ="NUMBER")]
        public int? CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the CreatedDate of the FlowChange.
        /// </summary>
        [DataObjectField(false, false, false)]
        [DisplayName("Created Date")]
        [Column("CREATEDDATE", TypeName = "DATE")]
        public DateTime? CreatedDate { get; set; }

        [DataObjectField(false, false, true, 7)]
        [ForeignKey(nameof(ReportedBy_Employee))]
        [Column("REPORTEDBY", TypeName = "NUMBER")]
        public int? ReportedBy { get; set; }

        [DataObjectField(false, false, true, 7)]
        [ForeignKey(nameof(ReportedTo_Employee))]
        [Column("REPORTEDTO", TypeName = "NUMBER")]
        public int? ReportedTo { get; set; }

        [DataObjectField(false, false, true)]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Column("REPORTEDDATE", TypeName = "DATE")]
        public DateTime? ReportedDate { get; set; }

        [DataObjectField(false, false, true, 5)]
        [Column("REPORTEDTIME", TypeName = "VARCHAR2")]
        public string? ReportedTime { get; set; }

        [DataObjectField(false, false, false, 120)]
        [Column("EQUIPMENTINVOLVED", TypeName = "VARCHAR2")]
        public string EquipmentInvolved { get; set; } = string.Empty;

        [DataObjectField(false, false, false, 200)]
        [Column("LOCATION", TypeName = "VARCHAR2")]
        public string Location { get; set; } = string.Empty;

        [DataObjectField(false, false, true, 7)]
        [ForeignKey(nameof(ReleasedBy_Employee))]
        [Column("RELEASEDBY", TypeName = "NUMBER")]
        public int? ReleasedBy { get; set; }

        [DataObjectField(false, false, true)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Column("RELEASEDDATE", TypeName = "DATE")]
        public DateTime? ReleasedDate { get; set; }

        [DataObjectField(false, false, true, 5)]
        [Column("RELEASEDTIME", TypeName = "VARCHAR2")]
        public string? ReleasedTime { get; set; }

        [DataObjectField(false, false, true, 100)]
        [Column("RELEASETYPE", TypeName = "VARCHAR2")]
        public string? ReleaseType { get; set; }

        [DataObjectField(false, false, true, 100)]
        [Column("TAGSINSTALLED", TypeName = "VARCHAR2")]
        public string? TagsInstalled { get; set; }

        [DataObjectField(false, false, true, 100)]
        [Column("TAGSREMOVED", TypeName = "VARCHAR2")]
        public string? TagsRemoved { get; set; }

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
        [Column("SHIFTNO", TypeName = "VARCHAR2")]
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

        /// <summary>
        /// Gets or sets the UID of the record.
        /// </summary>
        [DataObjectField(false, false, false, 60)]
        [DisplayName("Updated By")]
        [Column("UPDATEDBY", TypeName = "VARCHAR2")]
        public string? UpdatedBy { get; set; }

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
        public Employee ReportedBy_Employee { get; set; } = new Employee();

        [NotMapped] 
        public Employee ReportedTo_Employee { get; set; } = new Employee();

        [NotMapped] 
        public Employee ReleasedBy_Employee { get; set; } = new Employee();

        [NotMapped] 
        public Employee Notified_Employee { get; set; } = new Employee();

        /// <summary>
        /// Gets or sets the EventIDentifier of the FlowChange.
        /// </summary>
        //[DataObjectField(false, false, false)]
        //[NotNullOrEmpty(Key = "DetailsNotEmpty")]
        [NotMapped]
        public string EventIDentifier => $"{EventID} / {EventID_RevNo.ToString()}";

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

                            //ToDo: Verify IssedTo, IssedDate, IssedTime  (There are no such fields in EOS table)
                            //_EventTrail += "Transferred to: " + IssedTo != null ? Helpers.GetEmpFullName("ReleasedBy", ReleasedBy.Value, FacilNo) : "n/a" + _CrLf;;
                            //_EventTrail += "Transferred Dt/Tm: " + IssedDate.ToString("MM/dd/yyyy") + " " + IssedTime + _CrLf;
                            break;
                    }
                }

                if (!String.IsNullOrEmpty(OperatorID.ToString()))
                {
                    _EventTrail += "Logged By: " + Operator.FullName + _CrLf;
                    _EventTrail += "Logged Dt/Tm: " + UpdateDate?.ToString("yyyy-MM-dd HH:mm") + _CrLf;
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
