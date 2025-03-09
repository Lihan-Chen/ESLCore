using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESL.Api.Models.BusinessEntities
{
    [Keyless]
    public partial record ViewAlleventsLogType
    {
        [Column("LOGTYPENO", TypeName = "NUMBER")]
        public int LogTypeNo { get; set; }

        [Column("LOGTYPENAME", TypeName = "VARCHAR2")]
        public string LogTypeName { get; set; } = null!;
    }
}
