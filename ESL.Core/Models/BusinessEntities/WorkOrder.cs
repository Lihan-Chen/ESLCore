namespace ESL.Core.Models.BusinessEntities;

//[Keyless]
//[Table("ESL_WORKORDERS")]
//[Index("FACILNO", "LOGTYPENO", "EVENTID", "WO_NO", Name = "ESL_WORKORDERS_PK", IsUnique = true)]
public partial record WorkOrder
{
    public int FacilNo { get; set; }

    public int LogTypeNo { get; set; }

    public string EventID { get; set; } = null!;

    public string WoNo { get; set; } = null!;

    public string? Notes { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdateDate { get; set; }

    //[Precision(2)]
    //public byte FACILNO { get; set; }

    //[Precision(2)]
    //public byte LOGTYPENO { get; set; }

    //[StringLength(20)]
    //[Unicode(false)]
    //public string EVENTID { get; set; } = null!;

    //[StringLength(20)]
    //[Unicode(false)]
    //public string WO_NO { get; set; } = null!;

    //[StringLength(400)]
    //[Unicode(false)]
    //public string? NOTES { get; set; }

    //[StringLength(60)]
    //[Unicode(false)]
    //public string? UPDATEDBY { get; set; }

    //[Column(TypeName = "DATE")]
    //public DateTime? UPDATEDATE { get; set; }
}
