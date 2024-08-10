using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ESL.Core.Models
{
    /// <summary>
    /// The FlowChange class represents an FlowChange that belongs to a <see cref="AllEvent"> AllEvent</see>.
    /// </summary>
    [Table("ESL_General")]
    public class GeneralLog : BaseEvent
    {

        #region Private Variables

        //private string _CrLf = "<br />"; // Environment.NewLine ; // "\\r?\\n"; "<br />"; "\r\n";

        #endregion

        #region Public Properties

        [DataObjectField(false, false, true, 7)]
        [Display(Name = "Reported By (Optional)")]
        [Column(nameof(ReportedBy))]
        public int? ReportedBy { get; set; }

        [DataObjectField(false, false, true)]
        [Column(nameof(EventDate))]
        public DateTime? EventDate { get; set; }

        [DataObjectField(false, false, true, 5)]
        [Column(nameof(EventTime))]
        public string? EventTime { get; set; }

        [DataObjectField(false, false, false, 300)]
        [Column(nameof(Subject))]
        public string Subject { get; set; } = null!;

        [DataObjectField(false, false, true, 600)]
        [Column(nameof(Details))]
        public string? Details { get; set; }

        [DataObjectField(false, false, false, 200)]
        [Column(nameof(Location))]
        public string? Location { get; set; }

        /// <summary>
        /// Gets or sets the eventIdentifier of the FlowChange.
        /// </summary>
        [DataObjectField(false, false, false)]
        //[NotNullOrEmpty(Key = "DetailsNotEmpty")]
        [NotMapped]
        public string EventIdentifier => $"{EventID} / {Convert.ToString(EventID_RevNo)}";

        /// <summary>
        /// Gets or sets the eventHighlight of the FlowChange.
        /// </summary>
        [DataObjectField(false, false, false)]
        //[NotNullOrEmpty(Key = "DetailsNotEmpty")
        [NotMapped]
        public string EventHighlight
        {
            get
            {
                string _EventHighlight = null!;

                _EventHighlight = $"Location: {Location}{_CrLf}";

                if (!String.IsNullOrEmpty(Subject))
                {
                    _EventHighlight += $"Subject: {Subject}{_CrLf}";
                }

                if (!String.IsNullOrEmpty(Details))
                {
                    _EventHighlight += $"Details: {Details}{_CrLf}";
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

        // need to add "Scanned Docs Stored: " (scandocs.count) when scanned docs directory are established on servers, or just ignore for now.

        /// <summary>
        /// Gets or sets the eventTrail of the FlowChange.
        /// </summary>
        [DataObjectField(false, false, false)]
        //[NotNullOrEmpty(Key = "DetailsNotEmpty")
        [NotMapped]
        public string EventTrail
        {
            get
            {
                string _EventTrail = null!;

                if (EventDate != null)
                {
                    _EventTrail = $"Event Dt/Tm: {EventDate.Value.ToString("MM/dd/yyyy")}, {EventTime}{_CrLf}";
                }

                if (!String.IsNullOrEmpty(OperatorID.ToString()))
                {
                    _EventTrail += $"Logged By: " + Helpers.GetEmpFullName("LoggedBy", OperatorID, FacilNo) + _CrLf;
                    _EventTrail += $"Logged Dt/Tm: " + UpdateDate.ToString("MM/dd/yyyy hh:mm") + _CrLf;
                }

                if (ReportedBy != null)
                {
                    _EventTrail += "Reported by: " + Helpers.GetEmpFullName("ReportedBy", ReportedBy.Value, FacilNo) + _CrLf;
                }

                if (NotifiedPerson != null)
                {
                    _EventTrail += "Notified Person: " + Helpers.GetEmpFullName("Notified", NotifiedPerson.Value, FacilNo) + _CrLf;
                } return _EventTrail;
            }
        }

        #endregion
    }
}
