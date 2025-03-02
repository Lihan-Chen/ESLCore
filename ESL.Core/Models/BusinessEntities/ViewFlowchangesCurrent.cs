using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace ESL.Core.Models.BusinessEntities;

[Keyless]

public partial class ViewFlowchangesCurrent
{
    public int FacilNo { get; set; }

    public string FacilName { get; set; } = null!;

    public int LogTypeNo { get; set; }

    public string LogTypeName { get; set; } = null!;

    public string EventID { get; set; } = null!;

    public int EventID_RevNo { get; set; }

    public int OperatorID { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int Requestedby { get; set; }

    public int Requestedto { get; set; }

    public DateTime RequestedDate { get; set; }

    public string RequestedTime { get; set; } = null!;

    public DateTime EventDate { get; set; }

    public string EventTime { get; set; } = null!;

    public string? Offtime { get; set; }

    public string MeterID { get; set; } = null!;

    public string? ChangeBy { get; set; }

    public int? NewValue { get; set; }

    public string? Unit { get; set; }

    public int? OldValue { get; set; }

    public string? OldUnit { get; set; }

    public string? ChangeByUnit { get; set; }

    public string? Accepted { get; set; }

    public string? ModifyFlag { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? Notes { get; set; }

    public string? NotifiedFacil { get; set; }

    public int? NotifiedPerson { get; set; }

    public int? ShiftNo { get; set; }

    public string Yr { get; set; } = null!;

    public int SeqNo { get; set; }

    public string UpdatedBy { get; set; } = null!;

    public DateTime UpdateDate { get; set; }

    public string? WorkOrders { get; set; }

    public string? RelatedTo { get; set; }

    public string? OperatorType { get; set; }
}
