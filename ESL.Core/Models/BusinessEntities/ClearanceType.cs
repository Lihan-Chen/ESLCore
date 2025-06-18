namespace ESL.Core.Models.BusinessEntities;

//[Table("ESL_CLEARANCETYPES", Schema = "ESL")]
public partial record ClearanceType
{
    #region POCO Properties

    public int ClearanceTypeNo { get; set; }

    public string ClearanceTypeName { get; set; } = null!;

    public string ClearanceTypeAbbr { get; set; } = null!;

    public int SortNo { get; set; }

    public string? Notes { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdateDate { get; set; }

    #endregion POCO Properties

    //#region Public Properties

    //[DataObjectField(true, true, false, 2)]
    //[DisplayName("Clearance Type No.")]
    //[Column("CLEARANCETYPENO", TypeName = "NUMBER")]
    ////[Key]
    ////[Precision(2)]
    //public int ClearanceTypeNo { get; set; }

    //[DataObjectField(false, true, false, 40)]
    //[DisplayName("Clearance Type")]
    //[Column("CLEARANCETYPENAME", TypeName = "VARCHAR2")]
    ////[StringLength(40)]
    ////[Unicode(false)]
    //public string ClearanceTypeName { get; set; } = null!;

    //[DataObjectField(false, true, false, 5)]
    //[DisplayName("Clearance Type Abbr")]
    //[Column("CLEARANCETYPEABBR", TypeName = "VARCHAR2")]
    ////[StringLength(5)]
    ////[Unicode(false)]
    //public string ClearanceTypeAbbr { get; set; } = null!;

    //[DataObjectField(false, false, false, 2)]
    //[DisplayName("Sort No.")]
    //[Column("SortNo", TypeName = "NUMBER")]
    ////[Precision(2)]
    //public int SortNo { get; set; }

    //[DataObjectField(false, false, true, 400)]
    //[DisplayName("Notes")]
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
