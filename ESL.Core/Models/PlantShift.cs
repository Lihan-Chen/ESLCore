using ESL.Core.Models.ComplexTypes;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace ESL.Core.Models
{
    [PrimaryKey(nameof(FacilNo),nameof(ShiftNo))]
    [Table($"ESL_{nameof(PlantShift)}s")]
    public partial record PlantShift
    {
        [DataObjectField(true, true, false, 2)]
        [DisplayName("Facility No.")]
        public int FacilNo { get; set; }

        [DataObjectField(true, true, false, 2)]
        [DisplayName("Shift No.")]
        public int ShiftNo { get; set; }

        [DataObjectField(false, false, true, 20)]
        public string? ShiftName { get; set; }

        [DataObjectField(false, true, false, 5)]
        public string ShiftStart { get; set; } = null!;

        [DataObjectField(false, true, false, 5)]
        public string ShiftEnd { get; set; } = null!;

        [DataObjectField(false, false, true, 400)]
        [DisplayName("Notes")]
        public string? Notes { get; set; }

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