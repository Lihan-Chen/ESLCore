namespace ESL.Core.Models.BusinessEntities;

/// <summary>
/// The Facility class represents a Facility that belongs to a <see cref="Facility"> Facilility</see>.
/// </summary>
//[DebuggerDisplay("Facility: {Facility, nq}")]
//[PrimaryKey(nameof(FacilNo))]
//[Table("ESL_FACILITIES", Schema = "ESL")]
//[Index("FacilNo", Name = "ESL_FACILITIES_PK", IsUnique = true)]
//[Keyless]
//[Table("ESL_FACILITIES")]
//[Index("FACILNO", Name = "ESL_FACILITIES_PK", IsUnique = true)]
public partial record Facility
{
    #region POCO Properties

    public int FacilNo { get; set; }

    public string FacilName { get; set; } = null!;

    public string FacilAbbr { get; set; } = null!;

    public string FacilType { get; set; } = null!;

    public int? SortNo { get; set; }

    public string? Notes { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdateDate { get; set; }

    public string? Disable { get; set; }

    public string? VisibleTo { get; set; }

    public string? FacilFullName { get; set; }

    #endregion POCO Properties

    //#region Public Properties

    ///// <summary>
    ///// Gets or sets the Facility No [NUMBER(3)] of the Facility.
    ///// [DataObjectField(key, identity, isNullable]
    ///// </summary>
    //[DataObjectField(true, true, false, 3)]
    //[DisplayName("Facility No.")]
    //[Column("FACILNO", TypeName = "NUMBER")]
    ////[Precision(3)]
    //public int FacilNo { get; set; }

    ///// <summary>
    ///// Gets or sets the Facility Name [VARCHAR2(40)] of the Facility.
    ///// </summary>
    //[DataObjectField(false, true, false, 40)]
    //[DisplayName("Facility")]
    //[Column("FACILNAME", TypeName = "VARCHAR2")]
    ////[StringLength(40)]
    ////[Unicode(false)]
    //public string FacilName { get; set; } = null!;

    ///// <summary>
    ///// Gets or sets the Facility Abbreviation [VARCHAR2(5)] of the Facility.
    ///// </summary>
    //[DataObjectField(false, true, false, 6)]
    //[DisplayName("Abreviation")]
    //[Column("FACILABBR", TypeName = "VARCHAR2")]
    ////[StringLength(5)]
    ////[Unicode(false)]
    //public string FacilAbbr { get; set; } = null!;

    ///// <summary>
    ///// Gets or sets the Facility Type [VARCHAR2(30)] of the Facility.
    ///// </summary>
    //[DataObjectField(false, false, false, 30)]
    //[DisplayName("Facility Type")]
    //[Column("FACILTYPE", TypeName = "VARCHAR2")]
    ////[StringLength(30)]
    ////[Unicode(false)]
    //public string FacilType { get; set; } = null!;

    ///// <summary>
    ///// Gets or sets the Sort Order [NUMBER(2)] of the Facility.
    ///// </summary>
    //[DataObjectField(false, false, true, 2)]
    //[DisplayName("Sort Order")]
    //[Column("SORTNO", TypeName = "NUMBER")]
    ////[Precision(2)]
    //public int? SortNo { get; set; }

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
    ///// Gets or sets the Visible To [VARCHAR2(60)] of the Facility.
    ///// </summary>
    //[DataObjectField(false, false, true, 60)]
    //[DisplayName("Visible To")]
    //[Column("VISIBLETO", TypeName = "VARCHAR2")]
    ////[StringLength(60)]
    ////[Unicode(false)]
    //public string? VisibleTo { get; set; }

    ///// <summary>
    ///// Gets or sets the Facility Full Name [VARCHAR2(60)] of the Facility.
    ///// </summary>
    //[DataObjectField(false, false, true, 60)]
    //[DisplayName("Full Name")]
    //[Column("FACILFULLNAME", TypeName = "VARCHAR2")]
    ////[StringLength(60)]
    ////[Unicode(false)]
    //public string? FacilFullName { get; set; }

    //#endregion Public Properties
}
