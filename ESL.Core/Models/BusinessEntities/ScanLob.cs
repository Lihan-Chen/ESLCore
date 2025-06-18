﻿namespace ESL.Core.Models.BusinessEntities;

public partial record ScanLob
{
    #region POCO Properties

    public int ScanSeqNo { get; set; }

    public int FacilNo { get; set; }

    public int LogTypeNo { get; set; }

    public string EventID { get; set; } = null!;

    public int ScanNo { get; set; }

    public byte[]? ScanBlob { get; set; }

    public string? ScanLobType { get; set; }

    public string? Notes { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdateDate { get; set; }

    public string? ScanFileName { get; set; }

    #endregion POCO Properties
}
