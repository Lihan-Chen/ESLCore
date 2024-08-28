using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESL.Api.Models.ComplexTypes
{
    /// <summary>
    /// The Employee class represents a user that exists in a <see cref="UserInfo">Entra ID</see>.
    /// </summary>
    [DebuggerDisplay("User: {Employee, nq}")]
    //[PrimaryKey(nameof(EmployeeNo))]
    [ComplexType]
    public partial record UserInfo
    {
        //public UserInfo(int employeeNo, string surname, string givenName, string userPrincipalName)
        //{
        //}
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
        public string LastName { get; set; } = null!;

        /// <summary>
        /// Gets or sets the First Name [VARCHAR2(50)] of the Employee.
        /// </summary>
        [DataObjectField(false, false, true, 50)]
        [DisplayName("First Name")]
        [Column(nameof(FirstName))]
        public string FirstName { get; set; } = null!;


        /// <summary>
        /// Gets or sets the Email/PrincipalName [VARCHAR2(50)] of the User.
        /// </summary>
        [EmailAddress]
        [DataObjectField(false, false, true, 50)]
        [DisplayName("Principle Name")]
        [Column(nameof(PrincipalName))]
        public string PrincipalName { get; set; } = null!;

        #endregion
    }
}
