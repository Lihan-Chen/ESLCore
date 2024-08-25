using ESL.Core.Models.ComplexTypes;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace ESL.Core.Models
{
    [PrimaryKey(nameof(FacilNo),nameof(ConstantName),nameof(StartDate))]
    [Table($"ESL_CONSTANTS", Schema = "ESL")]
    public partial record Constant
    {
        [DataObjectField(true, true, false, 2)]
        [DisplayName("Facil. No.")]
        [Column("FACILNO", TypeName = "NUMBER")]
        public int FacilNo { get; set; }

        [DataObjectField(true, true, false)]
        [DisplayName("Start Date")]
        [Column("STARTDATE", TypeName = "DATE")]
        public DateTime StartDate { get; set; }

        [DataObjectField(true, true, false, 2)]
        [DisplayName("Constant")]
        [Column("CONSTANTNAME", TypeName = "VARCHAR2")]
        public string ConstantName { get; set; } = null!;

        [DataObjectField(false, false, true, 2)]
        [DisplayName("Value")]
        [Column("VALUE", TypeName = "NUMBER")]
        public int? Value { get; set; }

        [DataObjectField(false, false, true)]
        [DisplayName("End Date?")]
        [Column("ENDDATE", TypeName = "DATE")]
        public DateTime? EndDate { get; set; }

        [DataObjectField(false, false, true, 400)]
        [DisplayName("Notes")]
        [Column("NOTES", TypeName = "VARCHAR2")]
        public string? Notes { get; set; }

        /// <summary>
        /// Gets or sets the UID of the record.
        /// </summary>
        [DataObjectField(false, false, true, 60)]
        [DisplayName("Updated By")]
        [Column("UPDATEDBY", TypeName = "VARCHAR2")]
        public string? UpdatedBy { get; set; }

        /// <summary>
        /// Gets or sets the UpdateDate of the record.
        /// </summary>
        [DataObjectField(false, false, true)]
        [DisplayName("Updated on")]
        [Column("UPDATEDATE", TypeName = "DATE")]
        public DateTime? UpdateDate { get; set; }

    }
}
