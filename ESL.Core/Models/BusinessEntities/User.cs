using ESL.Core.Models.ComplexTypes;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ESL.Core.Models.BusinessEntities
{
    /// <summary>
    /// The User class represents an ESL user that exists in a <see cref="User">Entra ID</see>.
    /// </summary>
    [DebuggerDisplay("User: {Employee, nq}")]
    [PrimaryKey("EMPLOYEENO")]
    [Table("ESL_USERS")]
    public partial record User : UserInfo
    {
        #region Public Properties

        public UserInfo UserInfo { get; set; } = new UserInfo();

        /// <summary>
        /// Gets or sets the Facility No [NUMBER(3)] of the Facility.
        ///// [DataObjectField(key, identity, isNullable, length]
        ///// </summary>
        [DataObjectField(false, false, true, 3)]
        [DisplayName("Facility No.")]
        [Column("FACILONO")]
        public int? FacilNo { get; set; }

        [DataObjectField(false, true, false, 50)]
        [DisplayName("Entra ID")]
        [Column("USERGUID")]
        public Guid UserGuid { get; set; }

        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";

        [NotMapped]
        public string UserRole { get; }

        #endregion
    }
}