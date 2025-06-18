using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ESL.Core.Models.BusinessEntities;

//[PrimaryKey(nameof(FacilNo), nameof(LogTypeNo), nameof(EventID), nameof(EventID_RevNo))]
//[Table("ESL_CLEARANCEISSUES", Schema = "ESL")]
//[Index("FACILNO", "LOGTYPENO", "EVENTID", "EVENTID_REVNO", Name = "ESL_CLEARANCEISSUES_PK", IsUnique = true)]
public partial record ClearanceIssue
{
    #region POCO Properties

    public int FacilNo { get; set; }

    public byte LogTypeNo { get; set; }

    public string EventID { get; set; } = null!;

    public int EventID_RevNo { get; set; }

    public int OperatorID { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int IssuedTo { get; set; }

    public int IssuedBy { get; set; }

    public DateTime IssuedDate { get; set; }

    public string IssuedTime { get; set; } = null!;

    public string? ModifyFlag { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string Yr { get; set; } = null!;

    public string FacilAbbr { get; set; } = null!;

    public int SeqNo { get; set; }

    public string ClearanceType { get; set; } = null!;

    public string ClearanceZone { get; set; } = null!;

    public string? Location { get; set; }

    public string? WorkToBePerformed { get; set; }

    public string? EquipmentInvolved { get; set; }

    public string? WorkOrders { get; set; }

    public string? RelatedTo { get; set; }

    public string? Notes { get; set; }

    public string? NotifiedFacil { get; set; }

    public int? NotifiedPerson { get; set; }

    public int? ShiftNo { get; set; }

    public int? ReleasedTo { get; set; }

    public int? ReleasedBy { get; set; }

    public DateTime? ReleasedDate { get; set; }

    public string? ReleasedTime { get; set; }

    public string? ReleaseType { get; set; }

    public string? TagsRemoved { get; set; }

    public string? OperatorType { get; set; }

    public string UpdatedBy { get; set; } = null!;

    public DateTime UpdateDate { get; set; }

    public string? ClearanceID { get; set; }

    #endregion POCO Properties

    //#region Public Properties
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
    //[Display(Name = "Issued To")]
    //[Column("ISSUEDTO", TypeName = "NUMBER")]
    ////[Precision(7)]
    //public int IssuedTo { get; set; }

    //[DataObjectField(false, false, false, 7)]
    //[Display(Name = "Issued By")]
    //[Column("ISSUEDBY", TypeName = "NUMBER")]
    ////[Precision(7)]
    //public int IssuedBy { get; set; }

    //[DataObjectField(false, false, false)]
    //[Display(Name = "Issued Date")]
    //[Column("ISSUEDDATE", TypeName = "DATE")]
    //public DateTime IssuedDate { get; set; }

    //[DataObjectField(false, false, false, 5)]
    //[Display(Name = "Issued Time")]
    //[Column("ISSUEDTIME", TypeName = "NUMBER")]
    //[StringLength(5)]
    ////[Unicode(false)]
    //public string IssuredTime { get; set; } = null!;

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
    //[DataObjectFieldAttribute(false, false, true, 7)]
    //[Display(Name = "Modified By")]
    //[Column("MODIFIEDBY", TypeName = "NUMBER")]
    //public int? ModifiedBy { get; set; }

    ///// <summary>
    ///// Gets or sets the modifyDate of the FlowChange.
    ///// </summary>
    //[DataObjectFieldAttribute(false, false, true)]
    //[Display(Name = "Date Modified")]
    //[Column("MODIFYDATE", TypeName = "DATE")]
    //public DateTime? ModifiedDate { get; set; }

    ///// <summary>
    ///// Gets or sets the yr of the FlowChange.
    ///// </summary>
    //[DataObjectFieldAttribute(false, false, false, 2)]
    //[Column("YR", TypeName = "NUMBER")]
    ////[NotNullOrEmpty(Key = "DetailsNotEmpty")]
    ////[RegularExpression("^d{2}$", ErrorMessage = "Please enter YY format.")]
    //[Display(Name = "Year")]
    //public string Yr { get; set; } = null!;

    //[DataObjectField(false, false, false, 5)]
    //[Display(Name = "Facility Abbr.")]
    //[Column("FACILABBR", TypeName = "VARCHAR2")]
    ////[StringLength(5)]
    ////[Unicode(false)]
    //public string FacilAbbr { get; set; } = null!;

    ///// <summary>
    ///// Gets or sets the seqNo of the FlowChange.
    ///// </summary>
    //[DataObjectFieldAttribute(false, false, false, 6)]
    //[Display(Name = "Sequence No.")]
    //[Column("SEQNO", TypeName = "NUMBER")]
    //public int SeqNo { get; set; }

    //[DataObjectField(false, false, false, 2)]
    //[Display(Name = "Clearance Type")]
    //[Column("CLEARANCETYPE", TypeName = "NUMBER")]
    ////[StringLength(2)]
    ////[Unicode(false)]
    //public string ClearanceType { get; set; } = null!;

    //[DataObjectField(false, false, false, 300)]
    //[Display(Name = "Clearance Zone")]
    //[Column("CLEARANCEZONE", TypeName = "VARCHAR2")]
    ////[StringLength(300)]
    ////[Unicode(false)]
    //public string ClearanceZone { get; set; } = null!;

    //[DataObjectField(false, false, true, 200)]
    //[Display(Name = "Location")]
    //[Column("LOCATION", TypeName = "VARCHAR2")]
    ////[StringLength(200)]
    ////[Unicode(false)]
    //public string? Location { get; set; }

    //[DataObjectField(false, false, true, 600)]
    //[Display(Name = "Work to be Performed")]
    //[Column("WORKTOBEPERFORMED", TypeName = "VARCHAR2")]
    ////[StringLength(600)]
    ////[Unicode(false)]
    //public string? WorkToBePerformed { get; set; }

    //[DataObjectField(false, false, true, 200)]
    //[Display(Name = "Equipment Involved")]
    //[Column("EQUIPMENTINVOLVED", TypeName = "VARCHAR2")]
    ////[StringLength(200)]
    ////[Unicode(false)]
    //public string? EquipmentInvolved { get; set; }

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
    ///// Gets or sets the notes of the FlowChange.
    ///// </summary>
    //[DataObjectField(false, false, true, 400)]
    //[Display(Name = "Notes")]
    //[Column("NOTES", TypeName = "VARCHAR2")]
    //public string Notes { get; set; } = null!;

    ///// <summary>
    ///// Gets or sets the notifiedFacil of the FlowChange.
    ///// </summary>
    //[DataObjectFieldAttribute(false, false, true, 200)]
    //[Display(Name = "Notified Facility")]
    //[Column("NOTIFIEDFACIL", TypeName = "VARCHAR2")]
    //public string? NotifiedFacil { get; set; }

    ///// <summary>
    ///// Gets or sets the notifiedPerson of the FlowChange.
    ///// </summary>
    //[DataObjectFieldAttribute(false, false, true, 7)]
    //[Column("NOTIFIEDPERSON", TypeName = "NUMBER")]
    ////[Display(Name = "Notified Person")]
    //// [Display(Name = "Notified Person (optional)")]
    //public int? NotifiedPerson { get; set; }

    //[DataObjectField(false, false, true, 2)]
    //[Display(Name = "Shift No.")]
    //[Column("SHIFTNO", TypeName = "NUMBER")]
    ////[Precision(2)]
    //public int? ShiftNo { get; set; }

    //[DataObjectField(false, false, true, 7)]
    //[Display(Name = "Released To")]
    //[Column("RELEASEDTO", TypeName = "NUMBER")]
    ////[Precision(7)]
    //public int? ReleasedTo { get; set; }

    //[DataObjectField(false, false, true, 7)]
    //[Display(Name = "Released By")]
    //[Column("RELEASEDBY", TypeName = "NUMBER")]
    ////[Precision(7)]
    //public int? ReleasedBy { get; set; }

    //[DataObjectField(false, false, true)]
    //[Display(Name = "Released Date")]
    //[Column("RELEASEDDATE", TypeName = "DATE")]
    ////[Column(TypeName = "DATE")]
    //public DateTime? ReleasedDate { get; set; }

    //[DataObjectField(false, false, true, 5)]
    //[Display(Name = "Released Time")]
    //[Column("RELEASEDTIME", TypeName = "VARCHAR2")]
    ////[StringLength(5)]
    ////[Unicode(false)]
    //public string? ReleasedTime { get; set; }

    //[DataObjectField(false, false, true, 30)]
    //[Display(Name = "Release Type")]
    ////[NotNullOrEmpty(Key = "DetailsNotEmpty")]
    //[Column("RELEASETYPE", TypeName = "VARCHAR2")]
    ////[StringLength(30)]
    ////[Unicode(false)]
    //public string? ReleaseType { get; set; }

    //[DataObjectField(false, false, true, 200)]
    //[Display(Name = "Tags Removed")]
    ////[NotNullOrEmpty(Key = "DetailsNotEmpty")]
    //[Column("TAGSREMOVED", TypeName = "VARCHAR2")]
    ////[StringLength(200)]
    ////[Unicode(false)]
    //public string? TagsRemoved { get; set; }

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

    ///// <summary>
    ///// Gets or sets the ClearanceID of the AllEvents.
    ///// </summary>
    //[DataObjectField(false, false, true, 20)]
    ////[NotNullOrEmpty(Key = "DetailsNotEmpty")]
    //[Column("CLEARANCEID", TypeName = "VARCHAR2")]
    ////[StringLength(20)]
    ////[Unicode(false)]
    //public string? ClearanceID { get; set; }

    //#endregion Public Properties
}
