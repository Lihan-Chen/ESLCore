namespace ESL.Core.Models.BusinessEntities;

//[Keyless]
//[Table("ESL_CONSTANTS")]
//[Index("FacilNo", "ConstantName", "StartDate", AllDescending = false, IsUnique = true, Name = "ESL_CONSTANTS_PK")]
public partial record EslConstant
{
    #region POCO Properties
    
    public int FacilNo { get; set; }

    public DateTime StartDate { get; set; }

    public string ConstantName { get; set; } = null!;

    public decimal? Value { get; set; }

    public DateTime? EndDate { get; set; }

    public string? Notes { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdateDate { get; set; }

    #endregion

    //#region Public Properties

    //[DataObjectField(true, true, false, 2)]
    //[DisplayName("Facility No.")]
    //[Column("FACILNO", TypeName = "NUMBER")]
    ////[Precision(2)]
    //public int FacilNo { get; set; }

    //[DataObjectField(true, true, false)]
    //[DataType(DataType.Date)]
    //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
    //[Display(Name = "Start")]
    //[Column("STARTDATE", TypeName = "DATE")]
    //public DateTime StartDate { get; set; }

    //[DataObjectField(true, true, false, 20)]
    //[DisplayName("Constant")]
    //[Column("CONSTANTNAME", TypeName = "VARCHAR2")]
    ////[StringLength(20)]
    ////[Unicode(false)]
    //public string ConstantName { get; set; } = null!;

    //[DataObjectField(false, false, true)]
    //[DisplayName("Value")]
    //[Column("VALUE", TypeName = "NUMBER")]
    //public decimal? Value { get; set; }

    //[DataObjectField(false, false, true)]
    //[DataType(DataType.Date)]
    //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
    //[Display(Name = "End")]
    //[Column("ENDDATE", TypeName = "DATE")]
    //public DateTime? EndDate { get; set; }

    //[DataObjectField(false, false, true, 400)]
    //[DisplayName("Comment")]
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
    //public string UpdatedBy { get; set; } = null!;

    ///// <summary>
    ///// Gets or sets the UpdateDate of the record.
    ///// </summary>
    //[DataObjectField(false, false, false)]
    //[DisplayName("Updated on")]
    //[Column("UPDATEDATE", TypeName = "DATE")]
    ////[Column(TypeName = "DATE")]
    //public DateTime UpdateDate { get; set; }

    //#endregion Public Properties
}
