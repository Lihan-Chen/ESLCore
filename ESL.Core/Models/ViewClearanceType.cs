using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace ESL.Core.Models;

[Keyless]

public partial class ViewClearanceType
{
    public string ClearanceType { get; set; } = null!;

    public int ClearanceTypeno { get; set; }

    public string ClearanceTypename { get; set; } = null!;
}
