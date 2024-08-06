using ESL.Core.IConfiguration;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace ESL.Core.Models
{
    /// <summary>
    /// The Employee class represents a user that exists in a <see cref="User">Entra ID</see>.
    /// </summary>
    [DebuggerDisplay("User: {Employee, nq}")]
    [PrimaryKey(nameof(EmployeeNo))]
    [Table("ESL_Users")]
    public abstract class User // : IEntity
    {
        #region Public Properties

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
        public string LastName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the First Name [VARCHAR2(50)] of the Employee.
        /// </summary>
        [DataObjectField(false, false, true, 50)]
        [DisplayName("First Name")]
        [Column(nameof(FirstName))]
        public string FirstName { get; set; } = string.Empty;


        /// <summary>
        /// Gets or sets the Email/PrincipleName [VARCHAR2(50)] of the User.
        /// </summary>
        [EmailAddress]
        [DataObjectField(false, false, true, 50)]
        [DisplayName("Principle Name")]
        [Column(nameof(PrincipleName))]
        public string PrincipleName { get; set; } = string.Empty;
    }
}
