using ESL.Core.Models.ComplexTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace ESL.Core.Models.BusinessEntities
{
    /// <summary>
    /// The ClearanceIssues class represents an ClearanceIssues that belongs to a <see cref="ClearanceIssue"> ClearanceIssues</see>.
    /// </summary>
    [DebuggerDisplay("ClearanceIssues : {FacilName, nq} {LogTypeName, nq} {EventID, nq} - {EventID_RevNo, nq})")] // ({Type, nq})
    [PrimaryKey(nameof(FacilNo), nameof(LogTypeNo), nameof(EventID), nameof(EventID_RevNo))]
    [Table($"ESL_CLEARANCEISSUES", Schema = "ESL")]
    public partial record ClearanceIssue // : LogEvent
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
        [ForeignKey(nameof(OperatorID))]
        [Column("OPERATORID", TypeName = "NUMBER")]
        public int OperatorID { get; set; }

        /// <summary>
        /// Gets or sets the CreatedBy of the FlowChange.
        /// </summary>
        [DataObjectField(false, false, true, 7)]
        [DisplayName("Created By")]
        [Required(ErrorMessage = "Need to select a name from pull-down list.  Please try again.")]
        //[ForeignKey(nameof(CreatedBy_Employee))]
        [Column("CREATEDBY", TypeName = "NUMBER")]
        public int? CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the CreatedDate of the FlowChange.
        /// </summary>
        [DataObjectField(false, false, true)]
        [DataType("date")]
        [DisplayName("Created Date")]
        [Column("CREATEDDATE", TypeName = "DATE")]
        public DateTime? CreatedDate { get; set; }

        [DataObjectField(false, false, false, 7)]
        [Column("ISSUEDTO", TypeName = "NUMBER")]
        public int IssuedTo { get; set; }

        [DataObjectField(false, false, false, 7)]
        [Column("ISSUEDBY", TypeName = "NUMBER")]
        public int IssuedBy { get; set; }

        /// <summary>
        /// Gets or sets the IssedDate of the ClearanceIssues .
        /// </summary>
        [DataObjectField(false, false, false)]
        [Column("ISSUEDDATE", TypeName = "DATE")]
        public DateTime IssuedDate { get; set; }

        /// <summary>
        /// Gets or sets the EventTime of the ClearanceIssues .
        /// </summary>
        [DataObjectField(false, false, false, 5)]
        [Display(Name = "Issued Time", Prompt = "hh:mm")]
        [RegularExpression("([01]?[0-9]|2[0-3]):[0-5][0-9]", ErrorMessage = "Time must be a valid 24 hour time in HH:MM format")]
        [Column("ISSUEDTIME", TypeName = "VARCHAR2")]
        public string IssuedTime { get; set; } = null!;

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
        //[ForeignKey(nameof(ModifiedBy_Employee))]
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
        /// Gets or sets the yr of the FlowChange.
        /// </summary>
        [DataObjectField(false, false, false, 2)]
        //[NotNullOrEmpty(Key = "DetailsNotEmpty")]
        //[RegularExpression("^d{2}$", ErrorMessage = "Please enter YY format.")]
        [DisplayName("Year")]
        [Column("YR", TypeName = "VARCHAR2")]
        public string Yr { get; set; } = DateTime.Now.Year.ToString();


        [DataObjectField(false, false, false, 6)]
        [Column("FACILABBR", TypeName = "VARCHAR2")]
        public string FacilAbbr { get; set; } = null!;

        /// <summary>
        /// Gets or sets the SeqNo of the FlowChange.
        /// </summary>
        [DataObjectField(false, false, false, 6)]
        [DisplayName("Sequence No.")]
        [Column("SEQNO", TypeName = "NUMBER")]
        public int SeqNo { get; set; }

        [DataObjectField(false, false, false, 2)]
        [Column("CLEARANCETYPE", TypeName = "VARCHAR2")]
        public string ClearanceType { get; set; } = null!;

        [DataObjectField(false, false, false, 300)]
        [Column("CLEARANCEZONE", TypeName = "VARCHAR2")]
        public string ClearanceZone { get; set; } = null!;

        [DataObjectField(false, false, true, 200)]
        [Column("LOCATION", TypeName = "VARCHAR2")]
        public string? Location { get; set; }

        [DataObjectField(false, false, true, 600)]
        [Column("WORKTOBEPERFORMED", TypeName = "VARCHAR2")]
        public string? WorkToBePerformed { get; set; }

        [DataObjectField(false, false, true, 200)]
        [Column("EQUIPMENTINVOLVED", TypeName = "VARCHAR2")]
        public string? EquipmentInvolved { get; set; }

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
        //[ForeignKey(nameof(NotifiedPerson_Employee))]
        [Column("NOTIFIEDPERSON", TypeName = "NUMBER")]
        public int? NotifiedPerson { get; set; }

        /// <summary>
        /// Gets or sets the NotifiedPerson of the FlowChange.
        /// </summary>
        [DataObjectField(false, false, true, 80)]
        [DisplayName("Notified Person (optional)")]
        [NotMapped]
        public string? NotifiedPerson_Name { get; set; } = string.Empty; // => NotifiedPerson_Employee.FullName;

        /// <summary>
        /// Gets or sets the ShiftNo of the FlowChange.
        /// </summary>
        [DataObjectField(false, false, true, 2)]
        [DisplayName("Shift No")]
        [Column("SHIFTNO", TypeName = "NUMBER")]
        public int? ShiftNo { get; set; }

        [DataObjectField(false, false, true, 7)]
        [Column("RELEASEDTO", TypeName = "NUMBER")]
        public int? ReleasedTo { get; set; }

        [DataObjectField(false, false, true, 7)]
        [Column("RELEASEDBY", TypeName = "NUMBER")]
        public int? ReleasedBy { get; set; }

        [DataObjectField(false, false, true)]
        [Column("RELEASEDDATE", TypeName = "DATE")]
        public DateTime? ReleasedDate { get; set; }

        [DataObjectField(false, false, true, 5)]
        [Column("RELEASEDTIME", TypeName = "VARCHAR2")]
        public string? ReleasedTime { get; set; }

        [DataObjectField(false, false, true, 30)]
        [Column("RELEASETYPE", TypeName = "VARCHAR2")]
        public string? ReleaseType { get; set; }

        [DataObjectField(false, false, true, 200)]
        [Column("TAGSREMOVED", TypeName = "VARCHAR2")]
        public string? TagsRemoved { get; set; }

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

        [DataObjectField(false, false, true, 20)]
        [Column("CLEARANCEID", TypeName = "VARCHAR2")]
        public string? ClearanceID { get; set; }

        //[NotMapped]
        //public Facility Facility { get; init; } = new Facility();

        //[NotMapped]
        //public LogType LogType { get; init; } = new LogType();

        //[NotMapped]        
        //public Employee Operator { get; init; } = new Employee();

        //[NotMapped]
        //public Employee CreatedBy_Employee { get; init; } = new Employee();

        //[NotMapped] 
        //public Employee ModifiedBy_Employee { get; init; } = new Employee();

        //[NotMapped] 
        //public Employee NotifiedPerson_Employee { get; init; } = new Employee();

        //[NotMapped]
        //public Employee UpdatedBy_Employee { get; init; } = new Employee();

        //[NotMapped]
        //public Facility NotifiedFacility { get; init; } = new Facility();

        //[NotMapped]
        //public Employee IssedBy_Employee { get; set; } = new Employee();

        //[NotMapped]
        //public Employee IssedTo_Employee { get; set; } = new Employee();

        //[NotMapped]public Employee ReleasedBy_Employee { get; set;} = new Employee();

        //[NotMapped]
        //public Employee ReleasedTo_Employee { get;set; } = new Employee();

        /// <summary>
        /// Gets or sets the EventIDentifier of the FlowChange.
        /// </summary>
        //[DataObjectField(false, false, false)]
        [NotMapped]
        public string EventIDentifier => $"{ClearanceID} / {Convert.ToString(EventID_RevNo)}";

        /// <summary>
        /// Gets or sets the eventHighlight of the FlowChange.
        /// </summary>
        [NotMapped]
        public string EventHighlight
        {
            get
            {
                string _EventHighlight = null!;

                if (!string.IsNullOrEmpty(Location))
                {
                    _EventHighlight = $"Location: {Location}{_CrLf}";
                }

                if (!string.IsNullOrEmpty(ClearanceZone))
                {
                    _EventHighlight += $"Clearance Area: {ClearanceZone}{_CrLf}";
                }

                if (!string.IsNullOrEmpty(WorkToBePerformed))
                {
                    _EventHighlight += $"Work to be performed: {WorkToBePerformed}{_CrLf}";
                }

                if (!string.IsNullOrEmpty(EquipmentInvolved))
                {
                    _EventHighlight += $"Equipment involved: {EquipmentInvolved}{_CrLf}";
                }

                if (!string.IsNullOrEmpty(RelatedTo))
                {
                    _EventHighlight += $"Related to Event Nos.: {RelatedTo}{_CrLf}";
                }

                if (!string.IsNullOrEmpty(WorkOrders))
                {
                    _EventHighlight += $"Work Order Nos.: {WorkOrders}{_CrLf}";
                }

                if (!string.IsNullOrEmpty(Notes))
                {
                    _EventHighlight += $"Additional Notes: {Notes}{_CrLf}";
                }

                if (!string.IsNullOrEmpty(ReleaseType))
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

                _EventTrail = $"Issued to: IssedBy_Name{_CrLf}"; // {IssedBy_Name}

                _EventTrail += $"Issued by: IssedBy_Name{_CrLf}"; // {IssedBy_Name}

                if (IssuedDate != DateTime.MinValue)
                {
                    _EventTrail += $"Requested Dt/Tm: {IssuedDate.ToString("MM/dd/yyyy")} {IssuedTime}{_CrLf}";
                }

                _ReleasedBy = ReleasedBy.HasValue ? $"ReleasedBy_Name" : "n/a";

                _ReleasedTo = ReleasedTo.HasValue ? $"ReleasedTo_Name" : "n/a";

                _IssuedTo = $"IssuedTo_Name";


                switch (ReleaseType)
                {
                    case "Full Release":
                        _EventTrail += $"Full Released by: {_ReleasedBy}{_CrLf}Full Released to: {_ReleasedTo}{_CrLf}";
                        if (ReleasedDate.HasValue) _EventTrail += $"Full Released Dt/Tm: {ReleasedDate.Value.ToString("MM/dd/yyyy")} {ReleasedTime}{_CrLf}";
                        break;

                    case "Test Release":
                        _EventTrail += $"Test Released by: {_ReleasedBy}{_CrLf}Test Released to: {_ReleasedTo}{_CrLf}";
                        if (ReleasedDate.HasValue) _EventTrail += $"Test Released Dt/Tm: {ReleasedDate.Value.ToString("MM/dd/yyyy")} {ReleasedTime}{_CrLf}";

                        break;

                    case "Transfer":
                        _EventTrail += $"Released by: {_ReleasedBy}{_CrLf} + Issud to: {_IssuedTo}{_CrLf}";
                        _EventTrail += $"Transfer Dt/Tm: {IssuedDate.ToString("MM/dd/yyyy")} {IssuedTime}{_CrLf}";
                        //_EventTrail += "Released Dt/Tm: " + (ReleasedDate.HasValue ? ReleasedDate.Value.ToString("MM/dd/yyyy") : "n/a") + " " + ReleasedTime + _CrLf;

                        //_EventTrail = "Transferred to: " + IssedTo.ToString() + _CrLf + "Relased by: " + IssedTo.ToString() + _CrLf;
                        //_EventTrail += "Transferred Dt/Tm: " + IssedDate.ToString("MM/dd/yyyy") + " " + IssedTime + _CrLf;
                        break;
                }

                if (!string.IsNullOrEmpty(OperatorID.ToString()))
                {
                    _EventTrail += $"Logged By: Operator.FullName{_CrLf}";
                    _EventTrail += $"Logged Dt/Tm: {UpdateDate?.ToString("MM/dd/yyyy hh:mm")}{_CrLf}";
                }

                //if (!String.IsNullOrEmpty(NotifiedPerson))
                if (!string.IsNullOrEmpty(NotifiedPerson.ToString()))
                {
                    _EventTrail += $"Notified Person: {NotifiedPerson_Name}{_CrLf}";
                }

                return _EventTrail;
            }
        }

        #endregion

    }
}
