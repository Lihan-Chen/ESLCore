using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace ESL.Core.Models.BusinessEntities;

/// <summary>
/// The AllEvent record is an immutable class for readonly  represents an AllEvents that belongs to a <see cref="AllEvent"> AllEvent</see>.
/// AllEvent is using ComplexTypes as components.
/// In EF Core, AllEvents records query should be set to notracking based on CQRS
/// </summary>
[DebuggerDisplay("AllEvent: {FacilName, nq} {LogTypeName, nq} {EventID, nq} - {EventID_RevNo, nq})")] // ({Type, nq})

//[PrimaryKey(nameof(EventIDentity.FacilNo), nameof(EventIDentity.LogTypeNo), nameof(EventIDentity.EventID), nameof(EventIDentity.EventID_RevNo))]
[PrimaryKey(nameof(FacilNo), nameof(LogTypeNo), nameof(EventID), nameof(EventID_RevNo))]
[Index("UPDATEDATE", AllDescending = false, IsUnique = false, Name = "UPDATEDATE")]
[Table("ESL_ALLEVENTS", Schema = "ESL")]
public partial record AllEvent //: EventIDentity 
{

    #region Private Variables

    // constants have all being moved into the constants namespace and decorated as public static readonly 
    private static string _CrLf = "<br />"; // System.Environment.NewLine;

    #endregion

    #region Public Properties

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
    /// Gets or sets the FacilName of the AllEvents.
    /// </summary>
    /// 
    [DataObjectField(false, false, false, 40)]

    [NotMapped]
    public string FacilName { get; set; } = null!;

    /// <summary>
    /// Gets or sets the FacilAbbr of the AllEvents.
    /// </summary>
    /// 
    [DataObjectField(false, false, false, 5)]
    [NotMapped]
    public string FacilAbbr { get; set; } = null!;

    /// <summary>
    /// Gets or sets the LogTypeName of the AllEvents.
    /// </summary>
    /// 
    [DataObjectField(false, false, false, 100)]
    [NotMapped]
    public string LogTypeName { get; set; } = null!;

    /// <summary>
    /// Gets or sets the EventDate of the AllEvents.
    /// </summary>
    [DataObjectField(false, false, false)]
    [Column("EVENTDATE", TypeName = "DATE")]
    public DateTime? EventDate { get; set; }

    /// <summary>
    /// Gets or sets the EventTime of the AllEvents.
    /// </summary>
    [DataObjectField(false, false, false, 5)]
    [Column("EVENTTIME", TypeName = "VARCHAR2")]
    public string? EventTime { get; set; }

    /// <summary>
    /// Gets or sets the subject of the AllEvents.
    /// </summary>
    [DataObjectField(false, false, false, 300)]
    [Column("SUBJECT", TypeName = "VARCHAR2")]
    public string? Subject { get; set; }

    /// <summary>
    /// Gets or sets the details of the AllEvents.
    /// </summary>
    [DataObjectField(false, false, false, 2000)]
    //[NotNullOrEmpty(Key = "DetailsNotEmpty")]
    [Column("DETAILS", TypeName = "VARCHAR2")]
    public string? Details { get; set; }

    /// <summary>
    /// Gets or sets the ModifyFlag of the FlowChange.
    /// </summary>
    [DataObjectField(false, false, true, 100)]
    [Column("MODIFYFLAG", TypeName = "VARCHAR2")]
    public string? ModifyFlag { get; set; }

    /// <summary>
    /// Gets or sets the notes of the FlowChange.
    /// </summary>
    [DataObjectField(false, false, true, 400)]
    [Column("NOTES", TypeName = "VARCHAR2")]
    public string? Notes { get; set; }

    /// <summary>
    /// Gets or sets the OperatorType of the AllEvents.
    /// </summary>
    [DataObjectField(false, false, false, 15)]
    //[NotNullOrEmpty(Key = "DetailsNotEmpty")]
    [Column("OPERATORYTYPE", TypeName = "VARCHAR2")]
    public string? OperatorType { get; set; }

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
    /// Gets or sets the ClearanceID of the AllEvents.
    /// </summary>
    [DataObjectField(false, false, false, 20)]
    //[NotNullOrEmpty(Key = "DetailsNotEmpty")]
    [Column("CLEARANCEID", TypeName = "VARCHAR2")]
    public string? ClearanceID { get; set; } = null!;

    /// <summary>
    /// Gets or sets the ScanDocsNo of the AllEvents.
    /// </summary>
    [DataObjectField(false, false, true, 2)]
    [NotMapped]
    public int ScanDocsNo { get; set; }

    /// <summary>
    /// Gets or sets the EventIDentifier of the AllEvents.
    /// </summary>
    //[DataObjectField(false, false, false)]
    //[NotNullOrEmpty(Key = "DetailsNotEmpty")]
    [NotMapped]
    public string EventIDentifier => $"{EventID}/{EventID_RevNo}";

    /// <summary>
    /// Gets or sets the eventHighlight of the AllEvents.
    /// </summary>
    //[DataObjectField(false, false, false)]
    //[NotNullOrEmpty(Key = "DetailsNotEmpty")]
    [NotMapped]
    public string EventHighlight => String.IsNullOrEmpty(Subject) ? string.Empty : $"{Subject}{_CrLf}" + (String.IsNullOrEmpty(Details) ? string.Empty : $"{Details}{_CrLf}") + $"Updated By: {UpdatedBy} on {UpdateDate}";

    ////// Navigation to be implemented with EF virtural
    ////public virtual ScanDoc? scandoc { get; set; }
    ///
    [NotMapped]
    public virtual Facility Facility { get; set; } = new Facility();
    [NotMapped]
    public virtual LogType LogType { get; set; } = new LogType();

    #endregion
}
