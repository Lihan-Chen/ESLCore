using ESL.Core.Models.ComplexTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
    [Table("ESL_EMPLOYEES",Schema ="ESL")]
    public partial record Employee // : User
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the Employee No [NUMBER(8)] of the Facility.
        /// [DataObjectField(key, identity, isNullable]
        /// </summary>
        [DataObjectField(true, true, false, 8)]
        [DisplayName("MWD Employee ID")]
        [Column("EMPLOYEENO", TypeName="NUMBER")]
        public int EmployeeNo { get; set; }

        /// <summary>
        /// Gets or sets the Last Name [VARCHAR2(50)] of the Employee.
        /// </summary>
        [DataObjectField(false, false, true, 50)]
        [DisplayName("Last Name")]
        [Column("LASTNAME", TypeName = "VARCHAR2")]
        public string? LastName { get; set; } = null!;

        /// <summary>
        /// Gets or sets the First Name [VARCHAR2(50)] of the Employee.
        /// </summary>
        [DataObjectField(false, false, true, 50)]
        [DisplayName("First Name")]
        [Column("FIRSTNAME", TypeName = "VARCHAR2")]
        public string? FirstName { get; set; } = null!;

        /// <summary>
        /// Gets or sets the Company Name [VARCHAR2(100)] of the Employee.
        /// </summary>
        [DataObjectField(false, false, true, 100)]
        [DisplayName("Company")]
        [Column("COMPANY", TypeName = "VARCHAR2")]
        public string? Company { get; set; } = null!;

        /// <summary>
        /// Gets or sets the Group Name [VARCHAR2(100)] of the Employee.
        /// </summary>
        [DataObjectField(false, false, true, 100)]
        [DisplayName("Group Name")]
        [Column("GROUPNAME", TypeName = "VARCHAR2")]
        public string? GroupName { get; set; } = null!;

        /// <summary>
        /// Gets or sets the Facility No [NUMBER(3)] of the Facility.
        /// [DataObjectField(key, identity, isNullable, length]
        /// </summary>
        [DataObjectField(false, false, true, 3)]
        [DisplayName("Facility No.")]
        [Column("FACILNO", TypeName = "NUMBER")]
        public int? FacilNo { get; set; }

        /// <summary>
        /// Gets or sets the Job Title [VARCHAR2(100)] of the Employee.
        /// </summary>
        [DataObjectField(false, false, true, 100)]
        [DisplayName("Job Title")]
        [Column("JOBTITLE", TypeName = "VARCHAR2")]
        public string? JobTitle { get; set; }

        /// <summary>
        /// Gets or sets the Notes [VARCHAR2(400)] of the Employee.
        /// </summary>
        [DataObjectField(false, false, true, 400)]
        [DataType(DataType.MultilineText)]
        [DisplayName("Notes")]
        [Column("NOTES", TypeName = "VARCHAR2")]
        public string? Notes { get; set; }

        /// <summary>
        /// Gets or sets the UID of the record.
        /// </summary>
        [DataObjectField(false, false, false, 60)]
        [DisplayName("Updated By")]
        [Column("UPDATEDBY", TypeName = "VARCHAR2")]
        public string? UpdatedBy { get; set; }

        /// <summary>
        /// Gets or sets the UpdateDate of the record.
        /// </summary>
        [DataObjectField(false, false, false)]
        [DisplayName("Updated on")]
        [Column("UPDATEDATE", TypeName = "DATE")]
        public DateTime? UpdateDate { get; set; }

        /// <summary>
        /// Gets or sets the Disable [VARCHAR2(15)] of the Facility.
        /// </summary>
        [DataObjectField(false, false, true, 30)]
        [DisplayName("Disabled?")]
        [Column("DISABLE", TypeName = "VARCHAR2")]
        public string? Disable { get; set; }

        [NotMapped]
        public Facility Facility { get; set; } = new Facility();

        [NotMapped]
        public string UID => EmployeeNo.ToString().Length > 4 ? $"U{EmployeeNo.ToString()}" : $"U0{EmployeeNo.ToString()}";

        public string FullName => $"{this.FirstName} {this.FullName}";

        #endregion
    }
}
