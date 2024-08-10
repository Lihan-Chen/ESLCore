using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESL.Core.Models.ComplexTypes;

namespace ESL.Core.Models
{
    public partial class LogType
    {
        public int LogTypeNo { get; set; }

        public string LogTypeName { get; set; } = null!;

        public string? Notes { get; set; }

        public Update Update { get; set; } = new Update();

    }
}
