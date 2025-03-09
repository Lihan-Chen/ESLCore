using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ESL.Core.Models.BusinessEntities;

[Keyless]
public partial record AllEventLogType
{
    [Column("LOGTYPENO", TypeName = "NUMBER")]
    public int LogTypeNo { get; set; }


    [Column("LOGTYPENAME", TypeName = "VARCHAR2")]
    public string LogTypeName { get; set; } = null!;
}
