using ESL.Core.Models.ComplexTypes;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace ESL.Core.Models
{
    [PrimaryKey(nameof(FacilNo),nameof(ShiftNo))]
    [Table(nameof(PlantShift))]
    public partial record PlantShift
    {
        [DataObjectFieldAttribute(true, true, false, 2)]
        [DisplayName("Facility No.")]
        public int FacilNo { get; set; }

        [DataObjectFieldAttribute(true, true, false, 2)]
        [DisplayName("Shift No.")]
        public int ShiftNo { get; set; }

        [DataObjectFieldAttribute(false, false, true, 20)]
        public string? ShiftName { get; set; }

        [DataObjectFieldAttribute(false, true, false, 5)]
        public string ShiftStart { get; set; } = string.Empty;

        [DataObjectFieldAttribute(false, true, false, 5)]
        public string ShiftEnd { get; set; } = string.Empty;

        [DataObjectFieldAttribute(false, false, true, 400)]
        [DisplayName("Notes")]
        public string? Notes { get; set; }

        public Update Update { get; set; } = new Update();


    }
}