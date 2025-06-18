namespace ESL.Core.Models.BusinessEntities;

//[PrimaryKey("FacilNo", "EquipNo")]
//[Table("ESL_EQUIPMENTINVOLVED", Schema = "ESL")]
//[Index("FacilNo", "FacilType", "EquipName", Name = "ESL_EQUIPMENTINVOLVED_UNQ", IsUnique = true)]
public partial record Equipment
{
    #region POCO Properties

    public int FacilNo { get; set; }

    public string FacilType { get; set; } = null!;

    public int EquipNo { get; set; }

    public string EquipName { get; set; } = null!;

    public string? Notes { get; set; }

    public string? Disable { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdateDate { get; set; }

    #endregion POCO Properties

    //#region Public Properties

    //[DataObjectField(true, true, false, 3)]
    //[DisplayName("Facility No.")]
    //[Column("FACILNO", TypeName = "NUMBER")]
    ////[Key]
    ////[Precision(3)]
    //public int FacilNo { get; set; }

    //[DataObjectField(false, true, false, 5)]
    //[DisplayName("Facility Type")]
    //[Column("FACILTYPE", TypeName = "VARCHAR2")]
    ////[StringLength(5)]
    ////[Unicode(false)]
    //public string FacilType { get; set; } = null!;

    //[DataObjectField(true, true, false, 3)]
    //[DisplayName("Equipment No.")]
    //[Column("EQUIPNO", TypeName = "NUMBER")]
    ////[Key]
    ////[Precision(3)]
    //public int EquipNo { get; set; }

    //[DataObjectField(false, false, false, 100)]
    //[DisplayName("Equipment Name")]
    //[Column("EQUIPNAME", TypeName = "VARCHAR2")]
    ////[StringLength(100)]
    ////[Unicode(false)]
    //public string EquipName { get; set; } = null!;

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
    //[DataObjectField(false, false, false, 60)]
    //[DisplayName("Updated By")]
    //[Column("UPDATEDBY", TypeName = "VARCHAR2")]
    ////[StringLength(60)]
    ////[Unicode(false)]
    //public string? UpdatedBy { get; set; }

    ///// <summary>
    ///// Gets or sets the UpdateDate of the record.
    ///// </summary>
    //[DataObjectField(false, false, false)]
    //[DisplayName("Updated on")]
    //[Column("UPDATEDATE", TypeName = "DATE")]
    ////[Column(TypeName = "DATE")]
    //public DateTime? UpdateDate { get; set; }

    //#endregion Public Properties
}
