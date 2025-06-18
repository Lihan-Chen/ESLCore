using ESL.Core.Models.BusinessEntities.ValueObjects;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace ESL.Core.Models.BusinessEntities;

/// <summary>
/// The AllEvent record is an immutable readonly summary records of all logged events, represents an AllEvents that belongs to a <see cref="AllEvent"> AllEvent</see>.
/// The following commented attributes and similarly commented attributes are from data scaffolding with EF Core
/// [PrimaryKey] attribute is newer than [Key]
/// PrimaryKey(nameof(FacilNo), nameof(LogTypeNo), nameof(EventID), nameof(EventID_RevNo)) is described in DbContext OnModelCreating method (same names as the property names)
/// DataObjectField(key, identity, isNullable, length in byte)
/// [Precision(2)]
/// [Unicode(false)] sets the column to VARCHAR2 instead of NVARCHAR2 (half the size of NVARCHAR2)
/// - nvarchar columns are Unicode safe, while varchar columns only store ACSCII characters
/// DisplayName("Facility No.") is used for data binding
/// </summary>
[DebuggerDisplay("AllEvent: {FacilName, nq} {LogTypeName, nq} {EventID, nq} - {EventID_RevNo, nq})")] // ({Type, nq})


public partial record AllEvent : BaseLogEvent //, IAllEvent
{
    #region Private Fields

    // constants have all being moved into the constants namespace and decorated as public static readonly 
    public string _CrLf = System.Environment.NewLine; // "<br />";

    #endregion Private Fields

    #region POCO Properties

    //public int FacilNo { get; set; }

    //public int LogTypeNo { get; set; }

    //public string EventID { get; set; } = null!;

    //public int EventID_RevNo { get; set; }

    public DateTime? EventDate { get; set; }

    public string? EventTime { get; set; }

    public string? Subject { get; set; }

    public string? Details { get; set; }

    //public string? ModifyFlag { get; set; }

    //public string? Notes { get; set; }

    //public string? OperatorType { get; set; }

    public string UpdatedBy { get; set; } = null!;

    public DateTime UpdateDate { get; set; }

    public string? ClearanceID { get; set; }

    #endregion POCO Properties

    #region Public Extended Properties

    ///// <summary>
    ///// Gets or sets the ScanDocsNo of the AllEvents.
    ///// </summary>
    //[NotMapped]
    //public int ScanDocsNo { get; set; }

    ///// <summary>
    ///// Gets or sets the EventIDentifier of the AllEvents.
    ///// </summary>
    //[NotMapped]
    //public string EventIDentifier => $"{EventID}/{EventID_RevNo}";

    ///// <summary>
    ///// Gets or sets the eventHighlight of the AllEvents.
    ///// </summary>
    //[NotMapped]
    //public string EventHighlight => String.IsNullOrEmpty(Subject) ? string.Empty : $"{Subject}{_CrLf}" + (String.IsNullOrEmpty(Details) ? string.Empty : $"{Details}{_CrLf}") + $"Updated By: {UpdatedBy} on {UpdateDate}";

    #endregion Public Extended Properties

    #region Navigation Properties

    //[NotMapped]
    //public virtual Facility Facility { get; set; } = new();

    //[NotMapped]
    //public virtual LogType LogType { get; set; } = new();

    #endregion
}
