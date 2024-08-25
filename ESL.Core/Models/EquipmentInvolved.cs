using ESL.Core.Models.ComplexTypes;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace ESL.Core.Models
{
    [PrimaryKey(nameof(FacilNo), nameof(EquipNo))]
    [Table("ESL_EQUIPMENTINVOLVED")]
    public partial record EquipmentInvolved
    {
        [DataObjectField(true, true, false, 3)]
        [DisplayName("Facility No.")]
        [Column("FACILNO", TypeName = "NUMBER")]
        public int FacilNo { get; set; }

        [DataObjectField(false, true, false, 5)]
        [DisplayName("Facility Type")]
        [Column("FACILTYPE", TypeName = "VARCHAR2")] 
        public string FacilType { get; set; } = null!;

        [DataObjectField(true, true, false, 3)]
        [DisplayName("Equipment No.")]
        [Column("EQUIPNO", TypeName = "NUMBER")]
        public int EquipNo { get; set; }

        [DataObjectField(false, true, false, 100)]
        [DisplayName("Equipment")]
        [Column("EQUIPNAME", TypeName = "VARCHAR2")]
        public string EquipName { get; set; } = null!;

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