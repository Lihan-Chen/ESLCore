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
        public string MeterType { get; set; } = null!;

        [DataObjectField(false, false, true, 2)]
        [DisplayName("Sort No.")]
        [Column(nameof(SortNo))]
        public int? SortNo { get; set; }

        [DataObjectField(false, false, true, 400)]
        [DisplayName("Notes")]
        [Column(nameof(Notes))]
        public string? Notes { get; set; }

        [DataObjectField(false, false, true, 30)]
        [DisplayName("Disable?")]
        [Column(nameof(Disable))]
        public string? Disable { get; set; }

        public Update Update { get; set; } = new Update();
    }
}
