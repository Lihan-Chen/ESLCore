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
    public partial record EOS : LogEvent
    {
        #region Private Variables

        //private string _CrLf = "<br />"; // Environment.NewLine ; // "\\r?\\n"; "<br />"; "\r\n";

        #endregion

        #region Public Properties

        public EOS() { }

        //public EventIdentity EventIdentity { get; set; } = new EventIdentity();
        
        [DataObjectFieldAttribute(false, false, true, 7)]
        [ForeignKey(nameof(ReportedBy_Employee))]
        [Column(nameof(ReportedBy))]
        public int? ReportedBy { get; set; }

        [DataObjectFieldAttribute(false, false, true, 7)]
        [ForeignKey(nameof(ReportedTo_Employee))]
        [Column(nameof(ReportedTo))]
        public int? ReportedTo { get; set; }

        [DataObjectFieldAttribute(false, false, true)]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Column(nameof(ReportedDate))]
        public DateTime? ReportedDate { get; set; }

        [DataObjectFieldAttribute(false, false, true, 5)]
        [Column(nameof(ReportedTime))]
        public string? ReportedTime { get; set; }

        [DataObjectFieldAttribute(false, false, false, 120)]
        [Column(nameof(EquipmentInvolved))]
        public string EquipmentInvolved { get; set; } = string.Empty;

        [DataObjectFieldAttribute(false, false, false, 200)]
        [Column(nameof(Location))]
        public string Location { get; set; } = string.Empty;

        [DataObjectFieldAttribute(false, false, true, 7)]
        [ForeignKey(nameof(ReleasedBy_Employee))]
        [Column(nameof(ReleasedBy))]
        public int? ReleasedBy { get; set; }

        [DataObjectFieldAttribute(false, false, true)]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Column(nameof(ReleasedDate))]
        public DateTime? ReleasedDate { get; set; }
        
        [DataObjectFieldAttribute(false, false, true, 5)]
        [Column(nameof(ReleasedTime))]
        public string? ReleasedTime { get; set; }

        [DataObjectFieldAttribute(false, false, true, 100)]
        [Column(nameof(ReleaseType))] 
        public string? ReleaseType { get; set; }

        [DataObjectFieldAttribute(false, false, true, 100)]
        [Column(nameof(TagsInstalled))]
        public string? TagsInstalled { get; set; }

        [DataObjectFieldAttribute(false, false, true, 100)]
        [Column(nameof(TagsRemoved))] 
        public string? TagsRemoved { get; set; }

        public Update Update { get; set; } = new Update();

        public Employee ReportedBy_Employee { get; set; } = new Employee();

        public Employee ReportedTo_Employee { get; set; } = new Employee();

        public Employee ReleasedBy_Employee { get; set; } = new Employee();

        public Employee Notified_Employee { get; set; } = new Employee();

        /// <summary>
        /// Gets or sets the eventIdentifier of the FlowChange.
        /// </summary>
        //[DataObjectFieldAttribute(false, false, false)]
        //[NotNullOrEmpty(Key = "DetailsNotEmpty")]
        [NotMapped]
        public string EventIdentifier => $"{EventID} / {EventID_RevNo.ToString()}";

        /// <summary>
        /// Gets or sets the eventHighlight of the FlowChange.
        /// </summary>
        [DataObjectFieldAttribute(false, false, false)]
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
        [DataObjectFieldAttribute(false, false, false)]
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
                    _EventTrail += "Logged Dt/Tm: " + Update.UpdateDate.ToString("MM/dd/yyyy hh:mm") + _CrLf;
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
