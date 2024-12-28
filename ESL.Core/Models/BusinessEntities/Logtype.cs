using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace ESL.Core.Models.BusinessEntities
{
    [PrimaryKey(nameof(LogTypeNo))]
    [Index(nameof(LogTypeNo), nameof(LogTypeName), IsUnique = true, IsDescending = [false, false], Name = "ESL_LOGTYPES_UNQ")]
    [Table("ESL_LOGTYPES", Schema = "ESL")]
    public partial record LogType
    {
        /// <summary>
        /// Gets or sets the LogTypeNo of the Log Type.
        /// </summary>
        [DataObjectField(true, true, false, 2)]
        [DisplayName("Log Type No.")]
        //[ForeignKey("LogTypeNo")]
        [Column("LOGTYPENO", TypeName = "NUMBER")]
        public int LogTypeNo { get; set; }

        [DataObjectField(false, true, false, 100)]
        [DisplayName("Log Type")]
        [Column("LOGTYPENAME", TypeName = "VARCHAR2")]
        public string LogTypeName { get; set; } = null!;

        [DataObjectField(false, false, true, 400)]
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
    }
}
