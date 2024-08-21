using ESL.Core.Models.ComplexTypes;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace ESL.Core.Models
{
    [PrimaryKey(nameof(ClearanceTypeNo))]
    [Table($"ESL_{nameof(ClearanceType)}s")]
    public partial record ClearanceType
    {
        [DataObjectField(true, true, false, 2)]
        [DisplayName("Clearance Type No.")]
        public int ClearanceTypeNo { get; set; }

        [DataObjectField(false, false, false, 40)]
        [DisplayName("Clearance Type")]
        public string ClearanceTypeName { get; set; } = null!;

        [DataObjectField(false, false, false, 5)]
        [DisplayName("Clearance Type Abbreviation")]
        public string ClearanceTypeAbbr { get; set; } = null!;

        [DataObjectField(false, false, false, 2)]
        [DisplayName("Sort No.")]
        public int SortNo { get; set; }

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
