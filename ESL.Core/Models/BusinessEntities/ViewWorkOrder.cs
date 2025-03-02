using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace ESL.Core.Models.BusinessEntities;

[Keyless]

public partial class ViewWorkOrder
{
    public int FacilNo { get; set; }

    public int LogTypeNo { get; set; }

    public string EventID { get; set; } = null!;

    public string Wo_No { get; set; } = null!;

    public string? Notes { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdateDate { get; set; }
}
