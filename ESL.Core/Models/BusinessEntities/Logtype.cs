namespace ESL.Core.Models.BusinessEntities;

public partial record LogType
{
    #region POCO Properties

    public int LogTypeNo { get; set; }

    public string LogTypeName { get; set; } = null!;

    public string? Notes { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdateDate { get; set; }

    #endregion POCO Properties
}
