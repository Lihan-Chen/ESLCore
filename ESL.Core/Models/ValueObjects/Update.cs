using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESL.Core.Models.ValueObjects
{
    public record Update
    {
        public string UPDATEDBY { get; set; } = null!;

        public DateTime UPDATEDATE { get; set; } = DateTime.UtcNow;
    }
}
