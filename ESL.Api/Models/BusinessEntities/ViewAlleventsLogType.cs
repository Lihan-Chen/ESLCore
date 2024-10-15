using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESL.Api.Models.BusinessEntities
{
    [Keyless]
    public partial record ViewAlleventsLogType
    {
        public int LogTypeNo { get; set; }

        public string LogTypeName { get; set; } = null!;
    }
}
