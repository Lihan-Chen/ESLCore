using ESL.Core.Models.ComplexTypes;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace ESL.Core.Models
{
    [PrimaryKey(nameof(FacilNo),nameof(ConstantName),nameof(StartDate))]
    [Table($"ESL_{nameof(Constant)}s")]
    public partial record Constant
    {
        [DataObjectField(true, true, false, 2)]
        [DisplayName("Facil. No.")]
        public int FacilNo { get; set; }

        [DataObjectField(true, true, false)]
        [DisplayName("Start Date")]
        public DateTime StartDate { get; set; }

        [DataObjectField(true, true, false, 2)]
        [DisplayName("Constant")]
        public string ConstantName { get; set; } = null!;

        [DataObjectField(false, false, true, 2)]
        [DisplayName("Value")]
        public int? Value { get; set; }

        [DataObjectField(false, false, true)]
        [DisplayName("End Date?")]
        public DateTime? EndDate { get; set; }

        [DataObjectField(false, false, false, 400)]
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
