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
        [DataObjectFieldAttribute(true, true, false, 3)]
        [DisplayName("Facility No.")]
        [Column(nameof(FacilNo))]
        public int FacilNo { get; set; }

        [DataObjectFieldAttribute(false, true, false, 5)]
        [DisplayName("Facility Type")]
        public string FacilType { get; set; } = null!;

        [DataObjectFieldAttribute(true, true, false, 3)]
        [DisplayName("Equipment No.")]
        [Column(nameof(EquipNo))]
        public int EquipNo { get; set; }

        [DataObjectFieldAttribute(false, true, false, 100)]
        [DisplayName("Equipment")]
        [Column(nameof(EquipName))]
        public string EquipName { get; set; } = null!;

        [DataObjectFieldAttribute(false, false, true, 400)]
        [DisplayName("Notes")]
        [Column(nameof(Notes))]
        public string? Notes { get; set; }

        [DataObjectFieldAttribute(false, false, true, 30)]
        [DisplayName("Disable?")]
        [Column(nameof(Disable))]
        public string? Disable { get; set; }

        public Update Update { get; set; } = new Update();

    }
}