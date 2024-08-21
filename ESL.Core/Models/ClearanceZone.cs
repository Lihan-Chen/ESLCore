using ESL.Core.Models.ComplexTypes;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace ESL.Core.Models
{
    [PrimaryKey(nameof(FacilType),nameof(ZoneNo))]
    [Table($"ESL_{nameof(ClearanceZone)}s")]
    public partial record ClearanceZone
    {
        [DataObjectField(true, true, false, 5)]
        [DisplayName("Facil. Type")]
        public string FacilType { get; set; } = null!;

        [DataObjectField(true, true, false, 3)]
        [DisplayName("Zone No.")]
        public int ZoneNo { get; set; }

        [DataObjectField(false, false, true, 200)]
        [DisplayName("Zone Description")]
        public string? ZoneDescription { get; set; }

        [DataObjectField(false, false, false, 30)]
        [DisplayName("Diabled?")]
        public string? Disable { get; set; }

        [DataObjectField(false, false, false, 2)]
        [DisplayName("Sort No.")]
        public int? SortNo { get; set; }

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
