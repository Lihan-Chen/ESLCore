
using ESL.Core.Models.ComplexTypes;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ESL.Core.Models
{
    /// <summary>
    /// The Employee class represents a user that exists in a <see cref="User">Entra ID</see>.
    /// </summary>
    [DebuggerDisplay("User: {Employee, nq}")]
    [PrimaryKey(nameof(UserInfo.EmployeeNo))]
    [Table("ESL_Users")]
    public partial record User : UserInfo
    {
        #region Public Properties

        public User() { }

        public UserInfo UserInfo { get; set; } = new UserInfo();

        [DataObjectField(false, true, false, 50)]
        [DisplayName("Entra ID")]
        [Column(nameof(UserGuid))]
        public Guid UserGuid { get; set; }

        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";

        #endregion
    }
}