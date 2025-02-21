﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace ESL.Core.Models.BusinessEntities;

[Keyless]
public partial class ViewAlleventsRelatedTo
{
    public int FacilNo { get; set; }

    public string FacilName { get; set; } = null!;

    public string FacilAbbr { get; set; } = null!;

    public int LogTypeNo { get; set; }

    public string LogTypeName { get; set; } = null!;

    public string EventID { get; set; } = null!;

    public DateTime? EventDate { get; set; }

    public string? EventTime { get; set; }

    public string? Subject { get; set; }

    public string? Details { get; set; }

    public string? OperatorType { get; set; }

    public string? UpdatedBy { get; set; }

    public string? UpdateDate { get; set; }

    public string? ClearanceID { get; set; }
}
