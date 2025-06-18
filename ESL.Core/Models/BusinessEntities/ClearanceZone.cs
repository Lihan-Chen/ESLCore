namespace ESL.Core.Models.BusinessEntities;

//[PrimaryKey("FacilType", "ZoneNo")]
//[Table("ESL_CLEARANCEZONES", Schema = "ESL")]
public partial record ClearanceZone
{

    #region POCO Properties

    public string FacilType { get; set; } = null!;

    public int ZoneNo { get; set; }

    public string? ZoneDescription { get; set; }

    public string? Disable { get; set; }

    public int? SortNo { get; set; }

    public string? Notes { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdateDate { get; set; }

    public int? FacilNo { get; set; }

    #endregion POCO Properties

    //#region Public Properties

    //[DataObjectField(true, true, false, 5)]
    //[DisplayName("Facil Type")]
    //[Column("FACILTYPE", TypeName = "VARCHAR2")]
    ////[Key]
    ////[StringLength(5)]
    ////[Unicode(false)]
    //public string FacilType { get; set; } = null!;

    //[DataObjectField(true, true, false, 3)]
    //[DisplayName("Zone No.")]
    //[Column("ZONENO", TypeName = "NUMBER")]
    ////[Key]
    ////[Precision(3)]
    //public int ZoneNo { get; set; }

    //[DataObjectField(false, false, true, 200)]
    //[DisplayName("Zone Description")]
    //[Column("ZONEDESCRIPTION", TypeName = "VARCHAR2")]
    ////[StringLength(200)]
    ////[Unicode(false)]
    //public string? ZoneDescription { get; set; }

    //[DataObjectField(false, false, true, 30)]
    //[DisplayName("Disable")]
    //[Column("DISABLE", TypeName = "VARCHAR2")]
    ////[StringLength(30)]
    ////[Unicode(false)]
    //public string? Disable { get; set; }

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

    ///// <summary>
    ///// Gets or sets the UID of the record.
    ///// </summary>
    //[DataObjectField(false, false, false, 60)]
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

    //[DataObjectField(false, false, true, 3)]
    //[DisplayName("Facil No.")]
    //[Column("FACILNO", TypeName = "NUMBER")]
    ////[Precision(3)]
    //public int? FacilNo { get; set; }

    //#endregion Public Properties
}
