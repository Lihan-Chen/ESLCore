using ESL.Core.Models.ComplexTypes;
using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace ESL.Core.Models
{
    [PrimaryKey(nameof(FacilNo), nameof(MeterID))]
    [Table($"ESL_{nameof(Meter)}s")]
    public partial record Meter
    {
        [DataObjectField(true, true, false, 2)]
        [DisplayName("Facility No.")]
        [Column(nameof(FacilNo))]
        public int FacilNo { get; set; } 
        
        [DataObjectField(true, true, false, 20)]
        [DisplayName("Meter ID.")]
        [Column(nameof(MeterID))]
        public string MeterID { get; set; } = null!;    

        [DataObjectField(false, false, true, 20)]
        [DisplayName("Meter Type")]
        [Column(nameof(MeterType))]
        public string? MeterType { get; set; }

        [DataObjectField(false, false, true, 2)]
        [DisplayName("Sort No.")]
        [Column(nameof(SortNo))]
        public int? SortNo { get; set; }

        [DataObjectField(false, false, true, 400)]
        [DisplayName("Notes")]
        [Column("NOTES", TypeName = "VARCHAR2")]
        public string? Notes { get; set; }

        [DataObjectField(false, false, true, 30)]
        [DisplayName("Disable?")]
        [Column($"{nameof(Disable)}d?")]
        public string? Disable { get; set; }

        /// <summary>
        /// Gets or sets the UID of the record.
        /// </summary>
        [DataObjectField(false, false, false, 60)]
        [DisplayName("Updated By")]
        public string? UpdatedBy { get; set; }

        /// <summary>
        /// Gets or sets the UpdateDate of the record.
        /// </summary>
        [DataObjectField(false, false, false)]
        [DisplayName("Updated on")]
        public DateTime? UpdateDate { get; set; }
    }
}
