using ESL.Core.Models.ComplexTypes;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace ESL.Core.Models
{
    [PrimaryKey(nameof(FacilNo),nameof(ConstantName),nameof(StartDate))]
    [Table($"ESL_{nameof(Constant)}s")]
    public partial record Constant
    {
        public int FacilNo { get; set; }

        public string ConstantName { get; set; } = null!;

        public string StartDate { get; set; } = null!;

        public string? EndDate { get; set; }

        public int? Value { get; set; }

        public string? Notes { get; set; }

        public Update Update { get; set; } = new Update();

    }
}
