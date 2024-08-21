using ESL.Core.IConfiguration;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace ESL.Core.Models.ComplexTypes
{
    /// <summary>
    /// The BaseEvent class represents an event for a type of log that belongs to a <see cref="FlowChange"> AllEvent</see>.
    /// </summary>
    [DebuggerDisplay("Event: {FacilName, nq} {LogTypeName, nq} {EventID, nq} - {EventID_RevNo, nq})")] // ({Type, nq})
    //[PrimaryKey(nameof(FacilNo), nameof(LogTypeNo), nameof(EventID), nameof(EventID_RevNo))]
    [NotMapped]
    [ComplexType]
    public abstract record LogEvent : ILogEventEntity
    {
        #region Internal Variables

        internal string _CrLf = "<br />"; // Environment.NewLine ; // "\\r?\\n"; "<br />"; "\r\n";

        #endregion

        #region Public Properties

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

        ///// <summary>
        ///// Gets or sets the updatedBy of the FlowChange.
        ///// </summary>
        //[DataObjectField(false, false, false, 60)]
        //[DisplayName("Updated By")]
        //[Column(nameof(UpdatedBy))]
        //public string UpdatedBy { get; set; } = null!;

        ///// <summary>
        ///// Gets or sets the updateDate of the FlowChange.
        ///// </summary>
        //[DataObjectField(false, false, false)]
        //[Column(nameof(UpdateDate))]
        //public DateTime UpdateDate { get; set; }

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

        public Facility Facility { get; init; } = new Facility(); 

        public LogType LogType { get; init; } = new LogType();
        
        public Employee Operator { get; init; } = new Employee();

        public Employee CreatedBy_Employee { get; init; } = new Employee();

        public Employee ModifiedBy_Employee { get; init; } = new Employee();

        public Employee NotifiedPerson_Employee { get; init; } = new Employee();

        public Employee UpdatedBy_Employee { get; init; } = new Employee();

        public Facility NotifiedFacility { get; init; } = new Facility();



        ///// <summary>
        ///// Gets or sets the eventSubject of the FlowChange.
        ///// </summary>
        //[DataObjectField(false, false, false)]
        //[DisplayName("Subject")]
        //[NotMapped]
        //public string EventSubject { get; set; }

        ///// <summary>
        ///// Gets or sets the eventDetails of the FlowChange.
        ///// </summary>
        //[DataObjectField(false, false, false)]
        //[NotNullOrEmpty(Key = "DetailsNotEmpty")]
        //[DisplayName("Details")]
        //[NotMapped]
        //public string? EventDetails { get; set; }



        #endregion
    }
}
