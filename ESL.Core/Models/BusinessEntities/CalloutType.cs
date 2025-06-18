namespace ESL.Core.Models.BusinessEntities;

//[Table("ESL_CALLOUTTYPES", Schema = "ESL")]
//[Index("CalloutTypeNo", AllDescending = false, IsUnique = true, Name = "ESL_CALLOUTTYPES_PK")]
public partial record CalloutType
{
    #region POCO Properties

    public int CalloutTypeNo { get; set; }

    public string? CalloutTypeName { get; set; }

    public string? Notes { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdateDate { get; set; }

    #endregion POCO Properties

    //#region Public Properties

    //[DataObjectField(true, true, false, 38)]
    //[DisplayName("Callout Type No.")]
    //[Key]
    //[Column("CALLTYPENO", TypeName = "NUMBER")]
    //public int CalloutTypeNo { get; set; }

    //[DataObjectField(false, false, true, 50)]
    //[DisplayName("Callout Type")]
    //[Column("CALLOUTTYPENAME", TypeName = "VARCHAR2")]
    ////[StringLength(50)]
    ////[Unicode(false)]
    //public string? CalloutTypeName { get; set; }

    //[DataObjectField(false, false, true, 400)]
    //[DisplayName("Comment")]
    //[Column("NOTES", TypeName = "VARCHAR2")]
    ////[StringLength(400)]
    ////[Unicode(false)]
    //public string? Notes { get; set; }

    ///// <summary>
    ///// Gets or sets the UID of the record.
    ///// </summary>
    //[DataObjectField(false, false, true, 60)]
    //[DisplayName("Updated By")]
    //[Column("UPDATEDBY", TypeName = "VARCHAR2")]
    ////[StringLength(60)]
    ////[Unicode(false)]
    //public string? UpdatedBy { get; set; }

    ///// <summary>
    ///// Gets or sets the UpdateDate of the record.
    ///// </summary>
    //[DataObjectField(false, false, true)]
    //[DisplayName("Updated on")]
    //[Column("UPDATEDATE", TypeName = "DATE")]
    ////[Column(TypeName = "DATE")]
    //public DateTime? UpdateDate { get; set; }

    //#endregion Public Properties
}
