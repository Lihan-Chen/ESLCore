namespace ESL.Core.Models.BusinessEntities;

//[Table("ESL_LOGTABLENAMES", Schema = "ESL")]
public partial record LogTable
{
    #region POCO Properties

    public int LogTypeNo { get; set; }

    public string? LogTableName { get; set; }

    #endregion POCO Properties

    //#region Public Properties

    //[DataObjectField(true, true, false, 2)]
    //[DisplayName("Log Type No.")]
    //[Column("LOGTYPENO", TypeName = "NUMBER")]
    //[Key]
    //public int LogTypeNo { get; set; }

    //[DataObjectField(false, false, false, 30)]
    //[DisplayName("Log Type Name")]
    //[Column("LOGTYPENAME", TypeName = "VARCHAR2")]
    ////[StringLength(30)]
    ////[Unicode(false)]
    //public string? LogTableName { get; set; }

    //#endregion Public Properties
}
