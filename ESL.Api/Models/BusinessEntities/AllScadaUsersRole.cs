using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
namespace ESL.Api.Models.BusinessEntities
{
    [Keyless]
    [Index(nameof(FacilNo), nameof(UserID), AllDescending = false, IsDescending = [false, false], IsUnique = false, Name = "ESL_ALLSCADAUSERS_USERID_IDX")]
    [Table("ESL_ALLSCADAUSERS_ROLE", Schema = "ESL")]
    public partial record AllScadaUsersRole
    {
        /// <summary>
        /// Gets or sets the FacilNo of the Facility.
        /// </summary>
        [DataObjectField(true, true, false, 2)]
        [DisplayName("Facil. No.")]
        [Column("FACILNO", TypeName = "NUMBER")]
        public int FacilNo { get; set; }

        /// <summary>
        /// Gets or sets the Employee No [NUMBER(8)] of the Facility.
        /// [DataObjectField(key, identity, isNullable]
        /// </summary>
        [DataObjectField(true, true, false, 8)]
        [DisplayName("MWD User ID")]
        [Column("USERID", TypeName = "VARCHAR2")]
        public string? UserID { get; set; }

        [Column("ROLE", TypeName = "VARCHAR2")]
        public string? Role { get; set; }

        [Column("ADMIN_OPTION", TypeName = "VARCHAR2")]
        public string? AdminOption { get; set; }

        [Column("DEFAULT_ROLE", TypeName = "VARCHAR2")]
        public string? DefaultRole { get; set; }

        [Column("UPDATEDATE", TypeName = "DATE")]
        public DateTime? UpdateDate { get; set; } = default;

        [Column("UPDATEDBY", TypeName = "VARCHAR2")]
        public string? UpdatedBy { get; set; }
    }
}
