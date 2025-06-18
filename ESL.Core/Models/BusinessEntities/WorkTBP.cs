namespace ESL.Core.Models.BusinessEntities;

//[PrimaryKey("FacilType", "WorkNo")]
//[Table("ESL_WORKTOBEPERFORMED", Schema ="ESL")]
public partial record WorkTBP
{
    #region POCO Properties

    public string FacilType { get; set; } = null!;

    public int WorkNo { get; set; }

    public string WorkDescription { get; set; } = null!;

    public string? Notes { get; set; }

    public byte? SortNo { get; set; }

    public string? Disable { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdateDate { get; set; }

    #endregion POCO Properties

    //#region Public Properties

    //[DataObjectField(true, true, false, 5)]
    //[DisplayName("Facility Type")]
    //[Column("FACILTYPE", TypeName = "VARCHAR2")]
    ////[Key]
    ////[StringLength(5)]
    //[Unicode(false)]
    //public string FacilType { get; set; } = null!;

    //[DataObjectField(true, true, false, 3)]
    //[DisplayName("Work No.")]
    //[Column("WORKNO", TypeName = "NUMBER")]
    ////[Key]
    ////[Precision(3)]
    //public int WorkNo { get; set; }

    //[DataObjectField(false, true, false, 200)]
    //[DisplayName("Work Description")]
    //[Column("WORKDESCRIPTION", TypeName = "VARCHAR2")]
    ////[StringLength(200)]
    ////[Unicode(false)]
    //public string WorkDescription { get; set; } = null!;

    ///// <summary>
    ///// Gets or sets the Notes [VARCHAR2(400)] of the Facility.
    ///// </summary>
    //[DataObjectField(false, false, true, 400)]
    //[DisplayName("Notes")]
    //[Column("NOTES", TypeName = "VARCHAR2")]
    ////[StringLength(400)]
    ////[Unicode(false)]
    //public string? Notes { get; set; }

    ///// <summary>
    ///// Gets or sets the Sort Order [NUMBER(2)] of the Facility.
    ///// </summary>
    //[DataObjectField(false, false, true, 2)]
    //[DisplayName("Sort Order")]
    //[Column("SORTNO", TypeName = "NUMBER")]
    ////[Precision(2)]
    //public int? SortNo { get; set; }

    ///// <summary>
    ///// Gets or sets the Disable [VARCHAR2(15)] of the Facility.
    ///// </summary>
    //[DataObjectField(false, false, true, 15)]
    //[DisplayName("Disabled?")]
    //[Column("DISABLE", TypeName = "VARCHAR2")]
    ////[StringLength(15)]
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

    //#endregion Public Properties
}
