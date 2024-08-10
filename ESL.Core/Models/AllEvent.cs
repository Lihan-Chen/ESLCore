using ESL.Core.Models.ComplexTypes;
using ESL.Core.Models.Validation;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace ESL.Core.Models;

/// <summary>
/// The AllEvent record is an immutable class for readonly  represents an AllEvents that belongs to a <see cref="AllEvent"> AllEvent</see>.
/// AllEvent is using ComplexTypes as components.
/// In EF Core, AllEvents records query should be set to notracking based on CQRS
/// </summary>
[DebuggerDisplay("AllEvent: {FacilName, nq} {LogTypeName, nq} {EventID, nq} - {EventID_RevNo, nq})")] // ({Type, nq})

[PrimaryKey(nameof(EventIdentity.FacilNo), nameof(EventIdentity.LogTypeNo), nameof(EventIdentity.EventID), nameof(EventIdentity.EventID_RevNo))]
[Table($"ESL_{nameof(AllEvent)}s")]
public partial record AllEvent : EventIdentity 
{

    #region Private Variables

    // constants have all being moved into the constants namespace and decorated as public static readonly 
    private static string _CrLf = "<br />"; // System.Environment.NewLine;

    #endregion

    #region Public Properties

    public EventIdentity EventIdentity { get; set; } = new EventIdentity();


    /// <summary>
    /// Gets or sets the facilName of the AllEvents.
    /// </summary>
    /// 
    [DataObjectField(false, false, false, 40)]
    
    [NotMapped]
    public string FacilName { get; set; } = null!;

    /// <summary>
    /// Gets or sets the facilAbbr of the AllEvents.
    /// </summary>
    /// 
    [DataObjectField(false, false, false, 5)]
    [NotMapped]
    public string FacilAbbr { get; set; } = null!;

    /// <summary>
    /// Gets or sets the logTypeName of the AllEvents.
    /// </summary>
    /// 
    [DataObjectField(false, false, false, 100)]
    [NotMapped]
    public string LogTypeName { get; set; } = null!;

    /// <summary>
    /// Gets or sets the eventDate of the AllEvents.
    /// </summary>
    [DataObjectField(false, false, false)]
    [Column(nameof(EventDate))]
    public DateTime? EventDate { get; set; }

    /// <summary>
    /// Gets or sets the eventTime of the AllEvents.
    /// </summary>
    [DataObjectField(false, false, false, 5)]
    [Column(nameof(EventTime))]
    public string EventTime { get; set; } = null!;

    /// <summary>
    /// Gets or sets the subject of the AllEvents.
    /// </summary>
    [DataObjectField(false, false, false, 300)]
    [Column(nameof(Subject))]
    public string Subject { get; set; } = null!;

    /// <summary>
    /// Gets or sets the details of the AllEvents.
    /// </summary>
    [DataObjectField(false, false, false, 2000)]
    //[NotNullOrEmpty(Key = "DetailsNotEmpty")]
    [Column(nameof(Details))] 
    public string Details { get; set; } = null!;

    /// <summary>
    /// Gets or sets the modifyFlag of the FlowChange.
    /// </summary>
    [DataObjectField(false, false, true, 100)]
    [Column(nameof(ModifyFlag))]
    public string? ModifyFlag { get; set; }

    /// <summary>
    /// Gets or sets the notes of the FlowChange.
    /// </summary>
    [DataObjectField(false, false, true, 400)]
    [Column(nameof(Notes))]
    public string? Notes { get; set; }

    /// <summary>
    /// Gets or sets the operatorType of the AllEvents.
    /// </summary>
    [DataObjectField(false, false, false, 15)]
    //[NotNullOrEmpty(Key = "DetailsNotEmpty")]
    [Column(nameof(OperatorType))]
    public string? OperatorType { get; set; }

    public Update Update { get; set; }  = new Update();


    /// <summary>
    /// Gets or sets the clearanceID of the AllEvents.
    /// </summary>
    [DataObjectField(false, false, false, 20)]
    //[NotNullOrEmpty(Key = "DetailsNotEmpty")]
    [Column(nameof(ClearanceID))]
    public string? ClearanceID { get; set; } = null!;

    /// <summary>
    /// Gets or sets the ScanDocsNo of the AllEvents.
    /// </summary>
    [DataObjectField(false, false, true, 2)]
    [NotMapped]
    public int ScanDocsNo { get; set; }

    /// <summary>
    /// Gets or sets the eventIdentifier of the AllEvents.
    /// </summary>
    //[DataObjectField(false, false, false)]
    [NotNullOrEmpty(Key = "DetailsNotEmpty")]
    [NotMapped]
    public string EventIdentifier => $"{EventID}/{EventID_RevNo.ToString()}";

    /// <summary>
    /// Gets or sets the eventHighlight of the AllEvents.
    /// </summary>
    //[DataObjectField(false, false, false)]
    //[NotNullOrEmpty(Key = "DetailsNotEmpty")]
    [NotMapped]
    public string EventHighlight => Subject ?? $"{Subject}{_CrLf}" + (Details ?? $"{Details}{_CrLf}") + $"Updated By: {Update.UpdatedBy} on {Update.UpdateDate}";

    //// Navigation to be implemented with EF virtural
    //public virtual ScanDoc? scandoc { get; set; }

    public virtual Facility Facility { get; set; } = new Facility();

    public virtual LogType LogType { get; set; } = new LogType(); 

    #endregion
}
