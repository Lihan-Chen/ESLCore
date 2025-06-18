namespace ESL.Core.Models.BusinessEntities;

/// <summary>
/// UserRole entity class that maps to ESL_USER_ROLE table (formerly ESL_ALLSCADAUSERS_ROLE) in ESL schema
/// </summary>
//[Keyless]
////[PrimaryKey("FacilNo", "UserID", "Role")]
//[Table("ESL_ALLSCADAUSERS_ROLE", Schema ="ESL")]
//[Index("FacilNo", "UserID", Name = "ESL_ALLSCADAUSERS_USERID_IDX")]
public partial record UserRole
{
    #region POCO Properties

    public int? FacilNo { get; set; }

    public string? UserID { get; set; }

    public string? Role { get; set; }

    public string? AdminOption { get; set; }

    public string? DefaultRole { get; set; }

    public DateTime? UpdateDate { get; set; }

    public string? UpdatedBy { get; set; }

    #endregion POCO Properties

    //#region Public Properties

    //[DataObjectField(false, true, true)]
    //[DisplayName("Facility No.")]
    //[Column("FACILNO",TypeName = "NUMBER")]
    //public int? FacilNo { get; set; }

    //[DataObjectField(false, true, true, 30)]
    //[DisplayName("User ID")]
    //[Column("USERID", TypeName = "VARCHAR2")]
    ////[StringLength(30)]
    ////[Unicode(false)]
    //public string? UserID { get; set; }

    //[DataObjectField(false, false, false, 30)]
    //[DisplayName("Role")]
    //[Column("ROLE", TypeName = "VARCHAR2")]
    ////[StringLength(30)]
    ////[Unicode(false)]
    //public string? Role { get; set; }

    //[DataObjectField(false, false, true, 3)]
    //[DisplayName("Admin Option")]
    //[Column("ADMIN_OPTION", TypeName = "VARCHAR2")]
    //// NO YES
    ////[StringLength(3)]
    ////[Unicode(false)]
    //public string? Admin_Option { get; set; }

    //[DataObjectField(false, false, true, 3)]
    //[DisplayName("Default Role")]
    //[Column("DEFAULT_ROLE", TypeName = "VARCHAR2")]
    //// NO YES
    //[StringLength(3)]
    //[Unicode(false)]
    //public string? Default_Role { get; set; }

    ///// <summary>
    ///// Gets or sets the UpdateDate of the record.
    ///// </summary>
    //[DataObjectField(false, false, true)]
    //[DisplayName("Updated on")]
    //[Column("UPDATEDATE", TypeName = "DATE")]
    ////[Column(TypeName = "DATE")]
    //public DateTime? UpdateDate { get; set; }
    
    ///// <summary>
    ///// Gets or sets the UID of the record.
    ///// </summary>
    //[DataObjectField(false, false, true, 20)]
    //[DisplayName("Updated By")]
    //[Column("UPDATEDBY", TypeName = "VARCHAR2")]
    ////[StringLength(20)]
    ////[Unicode(false)]
    //public string? UpdatedBy { get; set; }

    //#endregion
}
