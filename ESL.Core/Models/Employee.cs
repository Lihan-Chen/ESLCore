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
    public class Employee : User
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the Company Name [VARCHAR2(100)] of the Employee.
        /// </summary>
        [DataObjectField(false, false, true, 100)]
        [DisplayName("Company")]
        [Column(nameof(Company))]
        public string Company { get; set; } = string.Empty;


        /// <summary>
        /// Gets or sets the Group Name [VARCHAR2(100)] of the Employee.
        /// </summary>
        [DataObjectField(false, false, true, 100)]
        [DisplayName("Group Name")]
        [Column(nameof(GroupName))]
        public string GroupName { get; set; } = string.Empty;


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
        /// Gets or sets the Updated By [VARCHAR2(60)] of the Facility.  UpdatedBy defaults to user
        /// </summary>
        [DataObjectField(false, false, true, 60)]
        [DisplayName("Updated By")]
        [Column(nameof(UpdatedBy))]
        public string? UpdatedBy { get; set; }

        /// <summary>
        /// Gets or sets the Update Date [DATE] of the Facility. UpdateTime is default to sysdate
        /// </summary>
        [DataObjectField(false, false, true)]
        [DisplayName("Update Date")]
        [Column(nameof(UpdateDate))]
        public DateTimeOffset UpdateDate { get; set; }

        /// <summary>
        /// Gets or sets the Disable [VARCHAR2(15)] of the Facility.
        /// </summary>
        [DataObjectField(false, false, true, 30)]
        [DisplayName("Disabled?")]
        [Column(nameof(Disable))]
        public string? Disable { get; set; }

        public Facility Facility { get; set; }  = new Facility();
    }
