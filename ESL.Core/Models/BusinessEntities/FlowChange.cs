using ESL.Core.Models.ValueObjects;

namespace ESL.Core.Models.BusinessEntities;

//[PrimaryKey("FacilNo", "LogTypeNo", "EventID", "EventID_RevNo")]
//[Table("ESL_FLOWCHANGES", Schema = "ESL")]
public partial record FlowChange
{
    private decimal? mlminToCFS = (decimal)5.88577770211022e7;
    private decimal? lbsdayToCFS = (decimal)2.50766394e7;
    private decimal? mgdToCFS = (decimal)1.5472286365101;

    #region POCO Properties

    public int FacilNo { get; set; }

    public int LogTypeNo { get; set; }

    public string EventID { get; set; } = null!;

    public int EventID_RevNo { get; set; }

    public int OperatorID { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int RequestedBy { get; set; }

    public int RequestedTo { get; set; }

    public DateTime RequestedDate { get; set; }

    public string RequestedTime { get; set; } = null!;

    public DateTime EventDate { get; set; }

    public string EventTime { get; set; } = null!;

    public string? OffTime { get; set; }

    public string MeterID { get; set; } = null!;

    public string? ChangeBy { get; set; }

    public Flow? OldFlow { get; set; }

    public Flow? NewFlow { get; set; }

    public Flow? ChangeByFlow // => string.IsNullOrEmpty(ChangeBy) ? null : new Flow() { Value = Convert.ToDecimal(ChangeBy), Unit = ChangeByUnit };
    {
        get => string.IsNullOrEmpty(ChangeBy) ? null : new Flow(Convert.ToDecimal(ChangeBy), ChangeByUnit!);

        set
        {
            decimal? changeByValueInCFS = NewFlow?.ValueInCFS - OldFlow?.ValueInCFS;
            decimal? changeByValue = ChangeByUnit?.ToLower() switch
            {
                "cfs" => changeByValueInCFS,
                "ml/min" => changeByValueInCFS / mlminToCFS,
                "lbsday" => changeByValueInCFS / lbsdayToCFS,
                "mgd" => changeByValueInCFS / mgdToCFS,
                _ => null
            };

            ChangeBy = changeByValue?.ToString();
        }
    }

    //public decimal? NewValue { get; set; }

    //public string? Unit { get; set; }

    //public decimal? OldValue { get; set; }

    //public string? OldUnit { get; set; }

    public string? ChangeByUnit { get; set; }

    public string? Accepted { get; set; }

    public string? ModifyFlag { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? Notes { get; set; }

    public string? NotifiedFacil { get; set; }

    public int? NotifiedPerson { get; set; }

    public int? ShiftNo { get; set; }

    public string Yr { get; set; } = null!;

    public int SeqNo { get; set; }

    public Update? Update { get; set; } = new Update();

    //public string UpdatedBy { get; set; } = null!;

    //public DateTime UpdateDate { get; set; }

    public string? WorkOrders { get; set; }

    public string? RelatedTo { get; set; }

    public string? OperatorType { get; set; }

    #endregion POCO Properties

    #region Public Properties

    ///// <summary>
    ///// Gets or sets the FacilNo of the Facility of the Event.
    ///// </summary>
    //[DataObjectField(true, true, false, 2)]
    //[DisplayName("Facil. No.")]
    //[Column("FACILNO", TypeName = "NUMBER")]
    ////[Key]
    ////[Precision(2)]
    //public int FacilNo { get; set; }

    ///// <summary>
    ///// Gets or sets the LogTypeNo of the Log Type of the Event.
    ///// </summary>
    //[DataObjectField(true, true, false, 2)]
    //[DisplayName("Log Type No.")]
    //[Column("LOGTYPENO", TypeName = "NUMBER")]
    ////[Key]
    ////[Precision(2)]
    //public int LogTypeNo { get; set; } = 1;

    ///// <summary>
    ///// Gets or sets the EventID of the Event.
    ///// </summary>
    //[DataObjectField(true, true, false, 20)]
    //[DisplayName("Event ID")]
    //[Column("EVENTID", TypeName = "VARCHAR2")]
    ////[Key]
    ////[StringLength(20)]
    ////[Unicode(false)]
    //public string EventID { get; set; } = null!;

    ///// <summary>
    ///// Gets or sets the EventID RevNo of the Event.
    ///// </summary>
    //[DataObjectField(true, true, false, 2)]
    //[DisplayName("Revision No.")]
    //[Column("EVENTID_REVNO", TypeName = "NUMBER")]
    ////[Key]
    ////[Precision(2)]
    //public int EventID_RevNo { get; set; }

    ///// <summary>
    ///// Gets or sets the operatorID of the FlowChange.
    ///// </summary>
    //[DataObjectField(false, false, false, 7)]
    //[Display(Name = "Operator")]
    //[Required(ErrorMessage = "Need to select a name from pull-down list.  Please try again.")]
    //[Column("OPERATORID", TypeName = "NUMBER")]
    //public int OperatorID { get; set; }

    ///// <summary>
    ///// Gets or sets the createdBy of the FlowChange.
    ///// </summary>
    //[DataObjectField(false, false, true, 7)]
    //[Column("CREATEDBY", TypeName = "NUMBER")]
    ////[Display(Name = "Created By")]
    ////[Required(ErrorMessage = "Need to select a name from pull-down list.  Please try again.")]
    //public int? CreatedBy { get; set; }

    ///// <summary>
    ///// Gets or sets the createdDate of the FlowChange.
    ///// </summary>
    //[DataObjectField(false, false, true)]
    //[Display(Name = "Created Date")]
    //[Column("CREATEDDATE", TypeName = "DATE")]
    //public DateTime? CreatedDate { get; set; }

    //[DataObjectField(false, false, false, 7)]
    //[Display(Name = "Requested By")]
    //[Column("REQUESTEDBY", TypeName = "NUMBER")]
    ////[Precision(7)]
    //public int RequestedBy { get; set; }

    //[DataObjectField(false, false, false, 7)]
    //[Display(Name = "Requested To")]
    //[Column("REQUESTEDTO", TypeName = "NUMBER")]
    ////[Precision(7)]
    //public int RequestedTo { get; set; }

    //[DataObjectField(false, false, false, 7)]
    //[Display(Name = "Requested Date")]
    //[Column("REQUESTEDDATE", TypeName = "DATE")]
    //public DateTime RequestedDate { get; set; }

    //[DataObjectField(false, false, false, 5)]
    //[Display(Name = "Requested Time")]
    //[Column("REQUESTEDTIME", TypeName = "VARCHAR2")]
    ////[StringLength(5)]
    ////[Unicode(false)]
    //public string RequestedTime { get; set; } = null!;

    //[DataObjectField(false, false, false, 7)]
    //[Display(Name = "Event Date")]
    //[Column("EVENTDATE", TypeName = "DATE")]
    //public DateTime EventDate { get; set; }

    //[DataObjectField(false, false, false, 5)]
    //[Display(Name = "Event Time")]
    //[Column("EVENTTIME", TypeName = "VARCHAR2")]
    ////[StringLength(5)]
    ////[Unicode(false)]
    //public string EventTime { get; set; } = null!;

    //[DataObjectField(false, false, true, 5)]
    //[Display(Name = "Off Time")]
    //[Column("OFFTIME", TypeName = "VARCHAR2")]
    ////[StringLength(5)]
    ////[Unicode(false)]
    //public string? OffTime { get; set; }


    //[DataObjectField(false, false, false, 30)]
    //[Display(Name = "Meter ID")]
    //[Column("METERID", TypeName = "VARCHAR2")]
    //[StringLength(30)]
    //[Unicode(false)]
    //public string MeterID { get; set; } = null!;

    //[DataObjectField(false, false, false, 10)]
    //[Display(Name = "Change By")]
    //[Column("CHANGEBY", TypeName = "VARCHAR2")]
    ////[StringLength(10)]
    ////[Unicode(false)]
    //public string? ChangeBy { get; set; }

    //[DataObjectField(false, false, true)]
    //[Display(Name = "New Value")]
    //[Column("NEWVALUE", TypeName = "NUMBER(10,2)")]
    //public decimal? NewValue { get; set; }

    //[DataObjectField(false, false, true, 10)]
    //[Display(Name = "Unit")]
    //[Column("UNIT", TypeName = "VARCHAR2")]
    ////[StringLength(10)]
    ////[Unicode(false)]
    //public string? Unit { get; set; }

    //[DataObjectField(false, false, true)]
    //[Display(Name = "Old Value")]
    //[Column("OLDVALUE", TypeName = "NUMBER(10,2)")]
    //public decimal? OldValue { get; set; }

    //[DataObjectField(false, false, true, 10)]
    //[Display(Name = "Old Unit")]
    //[Column("OLDUNIT", TypeName = "VARCHAR2")]
    ////[StringLength(10)]
    ////[Unicode(false)]
    //public string? OldUnit { get; set; }

    //[DataObjectField(false, false, true, 10)]
    //[Display(Name = "Change By Unit")]
    //[Column("CHANGEBYUNIT", TypeName = "VARCHAR2")]
    ////[StringLength(10)]
    ////[Unicode(false)]
    //public string? ChangeByUnit { get; set; }

    //[DataObjectField(false, false, true, 10)]
    //[Display(Name = "Accepted")]
    //[Column("ACCEPTED", TypeName = "VARCHAR2")]
    ////[StringLength(10)]
    ////[Unicode(false)]
    //public string? Accepted { get; set; }

    ///// <summary>
    ///// Gets or sets the modifyFlag of the FlowChange.
    ///// </summary>
    //[DataObjectField(false, false, true, 100)]
    //[Display(Name = "Modify Flag")]
    //[Column("MODIFYFLAG", TypeName = "VARCHAR2")]
    //public string ModifyFlag { get; set; } = null!;

    ///// <summary>
    ///// Gets or sets the modifiedBy of the FlowChange.
    ///// </summary>
    //[DataObjectField(false, false, true, 7)]
    //[Display(Name = "Modified By")]
    //[Column("MODIFIEDBY", TypeName = "NUMBER")]
    //public int? ModifiedBy { get; set; }

    ///// <summary>
    ///// Gets or sets the modifyDate of the FlowChange.
    ///// </summary>
    //[DataObjectField(false, false, true)]
    //[Display(Name = "Date Modified")]
    //[Column("MODIFYDATE", TypeName = "DATE")]
    //public DateTime? ModifiedDate { get; set; }

    ///// <summary>
    ///// Gets or sets the notes of the FlowChange.
    ///// </summary>
    //[DataObjectField(false, false, true, 400)]
    //[Display(Name = "Notes")]
    //[Column("NOTES", TypeName = "VARCHAR2")]
    //public string Notes { get; set; } = null!;

    ///// <summary>
    ///// Gets or sets the notifiedFacil of the FlowChange.
    ///// </summary>
    //[DataObjectField(false, false, true, 200)]
    //[Display(Name = "Notified Facility")]
    //[Column("NOTIFIEDFACIL", TypeName = "VARCHAR2")]
    //public string? NotifiedFacil { get; set; }

    ///// <summary>
    ///// Gets or sets the notifiedPerson of the FlowChange.
    ///// </summary>
    //[DataObjectField(false, false, true, 7)]
    //[Column("NOTIFIEDPERSON", TypeName = "NUMBER")]
    ////[Display(Name = "Notified Person")]
    //// [Display(Name = "Notified Person (optional)")]
    //public int? NotifiedPerson { get; set; }

    //[DataObjectField(false, false, true, 2)]
    //[Display(Name = "Shift No.")]
    //[Column("SHIFTNO", TypeName = "NUMBER")]
    ////[Precision(2)]
    //public int? ShiftNo { get; set; }

    ///// <summary>
    ///// Gets or sets the yr of the FlowChange.
    ///// </summary>
    //[DataObjectFieldAttribute(false, false, false, 2)]
    //[Column("YR", TypeName = "NUMBER")]
    ////[NotNullOrEmpty(Key = "DetailsNotEmpty")]
    ////[RegularExpression("^d{2}$", ErrorMessage = "Please enter YY format.")]
    //[Display(Name = "Year")]
    //public string Yr { get; set; } = null!;

    ///// <summary>
    ///// Gets or sets the seqNo of the FlowChange.
    ///// </summary>
    //[DataObjectFieldAttribute(false, false, false, 4)]
    //[Display(Name = "Sequence No.")]
    //[Column("SEQNO", TypeName = "NUMBER")]
    //public int SeqNo { get; set; }

    ///// <summary>
    ///// Gets or sets the UID of the record.
    ///// </summary>
    //[DataObjectField(false, false, false, 60)]
    //[DisplayName("Updated By")]
    //[Column("UPDATEDBY", TypeName = "VARCHAR2")]
    ////[StringLength(60)]
    ////[Unicode(false)]
    //public string UpdatedBy { get; set; } = null!;

    ///// <summary>
    ///// Gets or sets the UpdateDate of the record.
    ///// </summary>
    //[DataObjectField(false, false, false)]
    //[DisplayName("Updated on")]
    //[Column("UPDATEDATE", TypeName = "DATE")]
    ////[Column(TypeName = "DATE")]
    //public DateTime UpdateDate { get; set; }

    //[DataObjectField(false, false, true, 100)]
    //[Display(Name = "Work Orders")]
    //[Column("WORKORDERS", TypeName = "VARCHAR2")]
    //[StringLength(100)]
    //[Unicode(false)]
    //public string? WorkOrders { get; set; }

    //[DataObjectField(false, false, true, 200)]
    //[Display(Name = "Related To")]
    //[Column("RELATEDTO", TypeName = "VARCHAR2")]
    //[StringLength(200)]
    //[Unicode(false)]
    //public string? RelatedTo { get; set; }

    ///// <summary>
    ///// Gets or sets the OperatorType of the AllEvents.
    ///// </summary>
    //[DataObjectField(false, false, true, 15)]
    //[Display(Name = "Operator Type")]
    ////[NotNullOrEmpty(Key = "DetailsNotEmpty")]
    //[Column("OPERATORYTYPE", TypeName = "VARCHAR2")]
    ////[StringLength(15)]
    ////[Unicode(false)]
    //public string? OperatorType { get; set; }

    #endregion Public Properties
}
