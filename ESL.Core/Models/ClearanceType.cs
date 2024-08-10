using ESL.Core.Models.ComplexTypes;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace ESL.Core.Models
{
    [PrimaryKey(nameof(ClearanceTypeNo))]
    [Table($"ESL_{nameof(ClearanceType)}s" )]
    public partial record ClearanceType
    {
        public int ClearanceTypeNo { get; set; }

        public string ClearanceTypeName { get; set; } = null!;

        public string ClearanceTypeAbbr { get; set; } = null!;

        public int SortNo { get; set; }

        public string? Notes { get; set; }

        public Update Update { get; set; } = new Update();

    }
}
