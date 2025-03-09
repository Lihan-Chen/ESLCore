using ESL.Core.Models.ComplexTypes;
using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace ESL.Core.Models.BusinessEntities
{
    [PrimaryKey(nameof(FacilNo), nameof(MeterID))]
    [Table("ESL_METERS", Schema = "ESL")]
    public partial record Meter
    {
        [DataObjectField(true, true, false, 2)]
        [DisplayName("Facility No.")]
        [Column("FACILNO")]
        public int FacilNo { get; set; }

        [DataObjectField(true, true, false, 20)]
        [DisplayName("Meter ID.")]
        [Column("METERID", TypeName = "VARCHAR2")]
        public string MeterID { get; set; } = null!;

        [DataObjectField(false, false, true, 20)]
        [DisplayName("Meter Type")]
        [Column("METERTYPE", TypeName = "VARCHAR2")]
        public string? MeterType { get; set; }

        [DataObjectField(false, false, true, 2)]
        [Column("SORTNO", TypeName = "NUMBER")]
        public int? SortNo { get; set; }

        [DataObjectField(false, false, true, 400)]
        [DisplayName("Notes")]
        [Column("NOTES", TypeName = "VARCHAR2")]
        public string? Notes { get; set; }

        [DataObjectField(false, false, true, 30)]
        [Column("DISABLE", TypeName = "VARCHAR2")]
        public string? Disable { get; set; }

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
