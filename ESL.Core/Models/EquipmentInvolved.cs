using ESL.Core.Models.ComplexTypes;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace ESL.Core.Models
{
    [PrimaryKey(nameof(FacilNo), nameof(EquipNo))]
    [Table("ESL_EquipmentInvolved")]
    public partial record EquipmentInvolved
    {
        [DataObjectField(true, true, false, 3)]
        [DisplayName("Facility No.")]
        [Column(nameof(FacilNo))]
        public int FacilNo { get; set; }

        [DataObjectField(false, true, false, 5)]
        [DisplayName("Facility Type")]
        public string FacilType { get; set; } = null!;

        [DataObjectField(true, true, false, 3)]
        [DisplayName("Equipment No.")]
        [Column(nameof(EquipNo))]
        public int EquipNo { get; set; }

        [DataObjectField(false, true, false, 100)]
        [DisplayName("Equipment")]
        [Column(nameof(EquipName))]
        public string EquipName { get; set; } = null!;

        [DataObjectField(false, false, true, 400)]
        [DisplayName("Notes")]
        [Column(nameof(Notes))]
        public string? Notes { get; set; }

        [DataObjectField(false, false, true, 30)]
        [DisplayName("Disable?")]
        [Column(nameof(Disable))]
        public string? Disable { get; set; }

        /// <summary>
        /// Gets or sets the UID of the record.
        /// </summary>
        [DataObjectField(false, false, false, 60)]
        [DisplayName("Updated By")]
        public string UpdatedBy { get; set; } = null!;

        /// <summary>
        /// Gets or sets the updateDate of the record.
        /// </summary>
        [DataObjectField(false, false, false)]
        [DisplayName("Updated on")]
        public DateTimeOffset UpdateDate { get; set; }

    }
}