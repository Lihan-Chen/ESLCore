using ESL.Core.Models.ComplexTypes;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace ESL.Core.Models.BusinessEntities
{
    [PrimaryKey(nameof(FacilNo), nameof(ShiftNo))]
    [Table("ESL_PLANTSHITS", Schema = "ESL")]
    public partial record PlantShift
    {
        [DataObjectField(true, true, false, 2)]
        [DisplayName("Facility No.")]
        [Column("FACILNO", TypeName = "NUMBER")]
        public int FacilNo { get; set; }

        [DataObjectField(true, true, false, 2)]
        [DisplayName("Shift No.")]
        [Column("SHIFTNO", TypeName = "NUMBER")]
        public int ShiftNo { get; set; }

        [DataObjectField(false, false, true, 20)]
        [Column("SHIFTNAME", TypeName = "VARCHAR2")]
        public string? ShiftName { get; set; }

        [DataObjectField(false, true, false, 5)]
        [Column("SHIFTSTART", TypeName = "VARCHAR2")]
        public string ShiftStart { get; set; } = null!;

        [DataObjectField(false, true, false, 5)]
        [Column("SHIFTEND", TypeName = "VARCHAR2")]
        public string ShiftEnd { get; set; } = null!;

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