using ESL.Core.Models.ComplexTypes;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace ESL.Core.Models
{
    [PrimaryKey(nameof(FacilType),nameof(ZoneNo))]
    [Table($"ESL_{nameof(ClearanceZone)}s")]
    public partial record ClearanceZone
    {
        public string FacilType { get; set; } = null!;

        public int ZoneNo { get; set; }

        public string? ZoneDescription { get; set; }

        public string? Disable { get; set; }

        public int? SortNo { get; set; }

        public string? Notes { get; set; }

        public Update Update { get; set; } = new Update();
    }
}
