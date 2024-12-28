using System.ComponentModel.DataAnnotations;

namespace ESL.Core.Models.BusinessEntities
{
    public partial record LogsStatus
    {
        [Key]
        public decimal LogStatusNo { get; set; }

        public string Status { get; set; } = null!;

        public string? Note { get; set; }
    }
}
