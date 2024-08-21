using ESL.Core.Models.ComplexTypes;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace ESL.Core.Models
{
    /// <summary>
    /// The Employee class represents an Employee that belongs to a <see cref="Facility">Employee</see>.
    /// Added Email property for querying from the User class
    /// </summary>
    [DebuggerDisplay("Employee: {Employee, nq}")]
    [PrimaryKey(nameof(EmployeeNo))]
    [Table("ESL_Employees")]
    public partial record Employee // : User
    {
        #region Public Properties

        public Employee() { }

        /// <summary>
        /// Gets or sets the Employee No [NUMBER(8)] of the Facility.
        /// [DataObjectField(key, identity, isNullable]
        /// </summary>
        [DataObjectField(true, true, false, 8)]
        [DisplayName("MWD Employee ID")]
        [Column("EmployeeNo")]
        public int EmployeeNo { get; set; }

        /// <summary>
        /// Gets or sets the Last Name [VARCHAR2(50)] of the Employee.
        /// </summary>
        [DataObjectField(false, false, true, 50)]
        [DisplayName("Last Name")]
        [Column(nameof(LastName))]
        public string LastName { get; set; } = null!;

        /// <summary>
        /// Gets or sets the First Name [VARCHAR2(50)] of the Employee.
        /// </summary>
        [DataObjectField(false, false, true, 50)]
        [DisplayName("First Name")]
        [Column(nameof(FirstName))]
        public string FirstName { get; set; } = null!;

        /// <summary>
        /// Gets or sets the Company Name [VARCHAR2(100)] of the Employee.
        /// </summary>
        [DataObjectField(false, false, true, 100)]
        [DisplayName("Company")]
        [Column(nameof(Company))]
        public string Company { get; set; } = null!;

        /// <summary>
        /// Gets or sets the Group Name [VARCHAR2(100)] of the Employee.
        /// </summary>
        [DataObjectField(false, false, true, 100)]
        [DisplayName("Group Name")]
        [Column(nameof(GroupName))]
        public string GroupName { get; set; } = null!;

        /// <summary>
        /// Gets or sets the Facility No [NUMBER(3)] of the Facility.
        /// [DataObjectField(key, identity, isNullable, length]
        /// </summary>
        [DataObjectField(false, false, true, 3)]
        [DisplayName("Facility No.")]
        [Column(nameof(FacilNo))]
        public int? FacilNo { get; set; }

        /// <summary>
        /// Gets or sets the Job Title [VARCHAR2(100)] of the Employee.
        /// </summary>
        [DataObjectField(false, false, true, 100)]
        [DisplayName("Job Title")]
        [Column(nameof(JobTitle))]
        public string? JobTitle { get; set; }

        /// <summary>
        /// Gets or sets the Notes [VARCHAR2(400)] of the Employee.
        /// </summary>
        [DataObjectField(false, false, true, 400)]
        [DataType(DataType.MultilineText)]
        [DisplayName("Notes")]
        [Column(nameof(Notes))]
        public string? Notes { get; set; }

        /// <summary>
        /// Gets or sets the UID of the record.
        /// </summary>
        [DataObjectField(false, false, false, 60)]
        [DisplayName("Updated By")]
        public string UpdatedBy { get; set; } = null!;

        /// <summary>
        /// Gets or sets the updateDate of the record.
        /// </summary>
        [DataObjectField(false, false, false)]
        [DisplayName("Updated on")]
        public DateTimeOffset UpdateDate { get; set; }

        /// <summary>
        /// Gets or sets the Disable [VARCHAR2(15)] of the Facility.
        /// </summary>
        [DataObjectField(false, false, true, 30)]
        [DisplayName("Disabled?")]
        [Column(nameof(Disable))]
        public string? Disable { get; set; }

        [NotMapped]
        public Facility Facility { get; set; } = new Facility();

        [NotMapped]
        public string UID => EmployeeNo.ToString().Length > 4 ? $"U{EmployeeNo.ToString()}" : $"U0{EmployeeNo.ToString()}";

        public string FullName => $"{this.FirstName} {this.FullName}";

        #endregion
    }
}
