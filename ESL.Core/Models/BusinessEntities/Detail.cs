namespace ESL.Core.Models.BusinessEntities;

//[Keyless]
//[Table("ESL_DETAILS", Schema = "ESL")]
//[Index("FacilNo", "DetailsNo", Name = "ESL_DETAILS_PK", IsUnique = true)]
public partial record Detail
{
    #region POCO Properties

    public int FacilNo { get; set; }

    public int DetailsNo { get; set; }

    public string DetailsName { get; set; } = null!;

    public string FacilType { get; set; } = null!;

    public int? SortNo { get; set; }

    public string? Notes { get; set; }

    public string? Disable { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdateDate { get; set; }

    public byte? SubjNo { get; set; }

    #endregion POCO Properties

    //#region Public Properties

    //[DataObjectField(false, false, false, 3)]
    //[DisplayName("Facility No.")]
    //[Column("FACILNO", TypeName = "NUMBER")]
    ////[Precision(3)]
    //public int FacilNo { get; set; }

    //[DataObjectField(false, false, false, 3)]
    //[DisplayName("Details No.")]
    //[Column("DETAILSNO", TypeName = "NUMBER")]
    ////[Precision(3)]
    //public int DetailsNo { get; set; }

    //[DataObjectField(false, false, false, 100)]
    //[DisplayName("Details Name")]
    //[Column("DETAILSNAME", TypeName = "VARCHAR2")]
    ////[StringLength(100)]
    ////[Unicode(false)]
    //public string DetailsName { get; set; } = null!;

    //[DataObjectField(false, false, false, 5)]
    //[DisplayName("Facility Type")]
    //[Column("FACILTYPE", TypeName = "VARCHAR2")]
    ////[StringLength(5)]
    ////[Unicode(false)]
    //public string FacilType { get; set; } = null!;

    //[DataObjectField(false, false, true, 2)]
    //[DisplayName("Sort No.")]
    //[Column("SORTNO", TypeName = "NUMBER")]
    ////[Precision(2)]
    //public int? SortNo { get; set; }

    //[DataObjectField(false, false, true, 400)]
    //[DisplayName("Notes")]
    //[Column("NOTES", TypeName = "VARCHAR2")]
    ////[StringLength(400)]
    ////[Unicode(false)]
    //public string? Notes { get; set; }

    //[DataObjectField(false, false, true, 30)]
    //[DisplayName("Disable")]
    //[Column("DISABLE", TypeName = "VARCHAR2")]
    ////[StringLength(30)]
    ////[Unicode(false)]
    //public string? Disable { get; set; }

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

    //[DataObjectField(false, false, true, 2)]
    //[DisplayName("Subject No.")]
    //[Column("SUBJNO", TypeName = "NUMBER")]
    ////[Precision(2)]
    //public int? SUBJNO { get; set; }

    //#endregion Public Properties
}
