namespace ESL.Core.Models.BusinessEntities;

public partial record Subject
{
    #region POCO Properties

    public int FacilNo { get; set; }

    public int SubjNo { get; set; }

    public string SubjName { get; set; } = null!;

    public string FacilType { get; set; } = null!;

    public int? SortNo { get; set; }

    public string? Notes { get; set; }

    public string? Disable { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdateDate { get; set; }

    #endregion POCO Properties
}
