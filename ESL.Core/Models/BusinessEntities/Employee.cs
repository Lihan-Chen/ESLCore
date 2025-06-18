namespace ESL.Core.Models.BusinessEntities;

//[Table("ESL_EMPLOYEES", Schema = "ESL")]
public partial record Employee
{
    public Employee()
    {
    }

    public Employee(int? createdBy)
    {
        CreatedBy = createdBy;
    }
    #region POCO Properties

    public int EmployeeNo { get; set; }

    public string? LastName { get; set; }

    public string? FirstName { get; set; }

    public string? Company { get; set; }

    public string? GroupName { get; set; }

    public byte? FacilNo { get; set; }

    public string? JobTitle { get; set; }

    public string? Notes { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdateDate { get; set; }

    public string? Disable { get; set; }

    #endregion POCO Properties

    public string EmployeeID => this.EmployeeNo.ToString().Length == 4 ? $"U0{EmployeeNo}" : $"U{EmployeeNo}";

    public int? CreatedBy { get; }

    //#region Public Properties

    //[DataObjectField(true, true, false, 8)]
    //[DisplayName("Employee No.")]
    //[Column("EMPLOYEENO", TypeName = "NUMBER")]
    ////[Key]
    ////[Precision(8)]
    //public int EmployeeNo { get; set; }

    //[DataObjectField(false, false, false, 50)]
    //[DisplayName("Last Name")]
    //[Column("LASTNAME", TypeName = "NVARCHAR2")]
    ////[StringLength(50)]
    ////[Unicode(false)]
    //public string? LastName { get; set; }

    //[DataObjectField(false, false, false, 50)]
    //[DisplayName("First Name")]
    //[Column("FIRSTNAME", TypeName = "NVARCHAR2")]
    ////[StringLength(50)]
    ////[Unicode(false)]
    //public string? FirstName { get; set; }

    //[DataObjectField(false, false, false, 100)]
    //[StringLength(100)]
    //[Unicode(false)]
    //public string? Company { get; set; }

    //[DataObjectField(false, false, false, 100)]
    //[DisplayName("Group Name")]
    //[Column("GROUPNAME", TypeName = "NVARCHAR2")]
    ////[StringLength(100)]
    ////[Unicode(false)]
    //public string? GroupName { get; set; }

    //[DataObjectField(false, false, false, 3)]
    //[DisplayName("Facility No.")]
    //[Column("FACILNO", TypeName = "NUMBER")]
    ////[Precision(3)]
    //public int? FacilNo { get; set; }

    //[DataObjectField(false, false, false, 100)]
    //[DisplayName("Job Title")]
    //[Column("JOBTITLE", TypeName = "NVARCHAR2")]
    ////[StringLength(100)]
    ////[Unicode(false)]
    //public string? JobTitle { get; set; }

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
    //[DataObjectField(false, false, false)]
    //[DisplayName("Updated on")]
    //[Column("UPDATEDATE", TypeName = "DATE")]
    ////[Column(TypeName = "DATE")]
    //public DateTime? UpdateDate { get; set; }

    //[DataObjectField(false, false, true, 30)]
    //[DisplayName("Disable")]
    //[Column("DISABLE", TypeName = "VARCHAR2")]
    ////[StringLength(30)]
    ////[Unicode(false)]
    //public string? Disable { get; set; }

    //#endregion Public Properties
}
