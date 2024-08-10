using static Microsoft.Graph.CoreConstants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Diagnostics;
using ESL.API.Models.BusinessEntities.ValueObjects;
using System.Data;

namespace ESL.API.Models.BusinessEntities
{
    /// <summary>
    /// The BaseEvent class represents an event for a type of log that belongs to a <see cref="FlowChange"> AllEvent</see>.
    /// </summary>
    [DebuggerDisplay("Event: {FacilName, nq} {LogTypeName, nq} {EventID, nq} - {EventID_RevNo, nq})")] // ({Type, nq})
    public class BaseEvent : BaseEventID //: IBaseEvent, IEquatable<BaseEvent>
    {
        #region Internal Variables

        internal string _CrLf = "<br />"; // Environment.NewLine ; // "\\r?\\n"; "<br />"; "\r\n";

        #endregion

        #region Public Properties

        ///// <summary>
        ///// Gets or sets the facilName of the FlowChange.
        ///// </summary>
        //[DataObjectField(true, true, false, 2)]
        //[Display(Name = "Facil. No.")]
        //public int FacilNo { get; set; }

        /// <summary>
        /// Gets or sets the facilName of the FlowChange.
        /// </summary>
        /// 
        [DataObjectField(false, false, false)]
        [Display(Name = "Facility")]
        public string FacilName => Facility.FacilName;

        ///// <summary>
        ///// Gets or sets the logTypeNo of the FlowChange.
        ///// </summary>
        //[DataObjectField(true, true, false, 2)]
        //[Display(Name = "Log Type No.")]
        //public int LogTypeNo { get; set; }

        /// <summary>
        /// Gets or sets the logTypeName of the FlowChange.
        /// </summary>
        /// 
        [DataObjectField(false, false, false)]
        [Display(Name = "Log Type")]
        public string LogTypeName => LogType.LogTypeName;

        ///// <summary>
        ///// Gets or sets the eventID of the FlowChange.
        ///// </summary>
        //[DataObjectField(true, true, false, 20)]
        //[Display(Name = "Event ID")]
        //public string EventID { get; set; }

        ///// <summary>
        ///// Gets or sets the eventID_RevNo of the FlowChange.
        ///// </summary>
        //[DataObjectField(true, true, false, 2)]
        //[Display(Name = "Revision No.")]
        //public int EventID_RevNo { get; set; }

        /// <summary>
        /// Gets or sets the operatorID of the FlowChange.
        /// </summary>
        [DataObjectField(false, false, false, 7)]
        [Display(Name = "Operator")]
        [Required(ErrorMessage = "Need to select a name from pull-down list.  Please try again.")]
        public int OperatorID => Operator.Id;

        /// <summary>
        /// Gets or sets the createdBy of the FlowChange.
        /// </summary>
        [DataObjectField(false, false, true, 7)]
        //[Display(Name = "Created By")]
        //[Required(ErrorMessage = "Need to select a name from pull-down list.  Please try again.")]
        public int CreatedBy => Operator.Id;

        /// <summary>
        /// Gets or sets the createdDate of the FlowChange.
        /// </summary>
        [DataObjectField(false, false, false)]
        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; } = DateTime.Today;

        ///// <summary>
        ///// Gets or sets the notes of the FlowChange.
        ///// </summary>
        //[DataObjectField(false, false, true, 400)]
        //[Display(Name = "Notes")]
        //public string? Notes { get; set; }

        /// <summary>
        /// Gets or sets the notifiedFacil of the FlowChange.
        /// </summary>
        [DataObjectField(false, false, true, 200)]
        [Display(Name = "Notified Facility")]
        public string? NotifiedFacil { get; set; }

        /// <summary>
        /// Gets or sets the notifiedPerson of the FlowChange.
        /// </summary>
        [DataObjectField(false, false, true, 7)]
        // [Display(Name = "Notified Person (optional)")]
        public int? NotifiedPersonId
        { get
            {return NotifiedPerson?.Id;}  
        }

        /// <summary>
        /// Gets or sets the notifiedPerson of the FlowChange.
        /// </summary>
        [DataObjectField(false, false, true, 80)]
        [Display(Name = "Notified Person (optional)")]
        public string? NotifiedPerson_Name
        {
            get
            {
                return NotifiedPerson?.ToString();
            }
        }

        /// <summary>
        /// Gets or sets the yr of the FlowChange.
        /// </summary>
        [DataObjectField(false, false, false, 2)]
        //[NotNullOrEmpty(Key = "DetailsNotEmpty")]
        //[RegularExpression("^d{2}$", ErrorMessage = "Please enter YY format.")]
        [Display(Name = "Year")]
        public string Yr { get; set; } = DateTime.Now.Year.ToString();

        /// <summary>
        /// Gets or sets the seqNo of the FlowChange.
        /// </summary>
        [DataObjectField(false, false, false, 6)]
        [Display(Name = "Sequence No.")]
        public int SeqNo { get; set; }

        /// <summary>
        /// Gets or sets the workOrders of the FlowChange.
        /// </summary>
        [DataObjectField(false, false, true, 100)]
        [Display(Name = "Work Orders")]
        public string? WorkOrders { get; set; }

        /// <summary>
        /// Gets or sets the relatedTo of the FlowChange.
        /// </summary>
        [DataObjectField(false, false, true, 200)]
        [Display(Name = "Related To")]
        public string? RelatedTo { get; set; }

        ///// <summary>
        ///// Gets or sets the operatorType of the FlowChange.
        ///// </summary>
        //[DataObjectField(false, false, true, 15)]
        //[Display(Name = "Operator Type (Optional)")]
        //public string OperatorType { get; set; } = null!;

        /// <summary>
        /// Gets or sets the eventSubject of the FlowChange.
        /// </summary>
        [DataObjectField(false, false, false)]
        [Display(Name = "Subject")]
        public string EventSubject { get; set; } = null!;

        /// <summary>
        /// Gets or sets the eventDetails of the FlowChange.
        /// </summary>
        [DataObjectField(false, false, false)]
        //[NotNullOrEmpty(Key = "DetailsNotEmpty")]
        [Display(Name = "Details")]
        public string EventDetails { get; set; } = null!;

        /// <summary>
        /// Gets or sets the ScanDocsNo of the AllEvents.
        /// </summary>
        [DataObjectField(false, false, true, 2)]
        public int ScanDocsNo { get; set; }

        public virtual Employee? NotifiedPerson { get; set; }

        public virtual Employee? RequestedBy { get; set; }

        #endregion
    }
}
