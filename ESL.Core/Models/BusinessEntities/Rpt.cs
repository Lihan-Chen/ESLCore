namespace ESL.Core.Models.BusinessEntities;

/// <summary>
/// The Report class represents an event for a type of log that belongs to a <see cref="AllEvent"> AllEvent</see>.
/// </summary>

public partial record Rpt
{
    #region POCO Properties

    public string? FacilName { get; set; }

    public string? LogTypeName { get; set; }

    public string? EventID { get; set; }

    public byte? EventID_RevNo { get; set; }

    public DateTime? EventDate { get; set; }

    public string? EventTime { get; set; }

    public string? Subject { get; set; }

    public string? Details { get; set; }

    public string? UpdatedByName { get; set; }

    public DateTime? UpdateDate { get; set; }

    public int? FacilNo { get; set; }

    public int? LogTypeNo { get; set; }

    #endregion POCO Properties
}
