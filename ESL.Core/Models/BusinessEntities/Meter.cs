namespace ESL.Core.Models.BusinessEntities;

public partial record Meter
{
    #region POCO Properties

    public int FacilNo { get; set; }

    public string MeterID { get; set; } = null!;

    public string? MeterType { get; set; }

    public int? SortNo { get; set; }

    public string? Notes { get; set; }

    public string? Disable { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdateDate { get; set; }

    #endregion POCO Properties
}
