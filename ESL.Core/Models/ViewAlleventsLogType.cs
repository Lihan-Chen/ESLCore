using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace ESL.Core.Models;

[Keyless]
public partial class ViewAlleventsLogType
{
    public int LogTypeNo { get; set; }

    public string LogTypeName { get; set; } = null!;
}
