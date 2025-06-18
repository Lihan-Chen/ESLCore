namespace ESL.Core.Models.BusinessEntities;

//[Table("ESL_LOGSTATUS", Schema ="ESL")]
public partial record LogStatus
{
    #region POCO Properties

    public int LogStatusNo { get; set; }

    public string Status { get; set; } = null!;

    public string? Notes { get; set; }

    #endregion POCO Properties

    //#region Public Properties

    //[DataObjectField(true, true, false, 2)]
    //[DisplayName("Log Status No.")]
    //[Key]
    //[Column("LOGSTATUSNO", TypeName = "NUMBER")]
    //public int LogStatusNo { get; set; }

    //[DataObjectField(false, false, false, 20)]
    //[DisplayName("Log Status")]
    //[Column("LOGSTATUS", TypeName = "VARCHAR2")]
    ////[StringLength(20)]
    ////[Unicode(false)]
    //public string Status { get; set; } = null!;

    //[DataObjectField(false, false, true, 50)]
    //[DisplayName("Notes")]
    //[Column("NOTES", TypeName = "VARCHAR2")]
    ////[StringLength(50)]
    ////[Unicode(false)]
    //public string? Notes { get; set; }

    //#endregion Public Properties
}
