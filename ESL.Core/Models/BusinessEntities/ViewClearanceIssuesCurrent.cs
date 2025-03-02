using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace ESL.Core.Models.BusinessEntities;

[Keyless]
public partial class ViewClearanceIssuesCurrent
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

    public int IssedTo { get; set; }

    public int IssedBy { get; set; }

    public DateTime IssedDate { get; set; }

    public string IssedTime { get; set; } = null!;

    public string? ModifyFlag { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string Yr { get; set; } = null!;

    public string FacilAbbr { get; set; } = null!;

    public int SeqNo { get; set; }

    public string ClearanceType { get; set; } = null!;

    public string ClearanceZone { get; set; } = null!;

    public string? Location { get; set; }

    public string? WorkToBePerformed { get; set; }

    public string? EquipmentInvolved { get; set; }

    public string? WorkOrders { get; set; }

    public string? RelatedTo { get; set; }

    public string? Notes { get; set; }

    public string? NotifiedFacil { get; set; }

    public int? NotifiedPerson { get; set; }

    public int? ShiftNo { get; set; }

    public int? ReleasedTo { get; set; }

    public int? ReleasedBy { get; set; }

    public DateTime? ReleasedDate { get; set; }

    public string? ReleasedTime { get; set; }

    public string? ReleaseType { get; set; }

    public string? TagsRemoved { get; set; }

    public string? OperatorType { get; set; }

    public string UpdatedBy { get; set; } = null!;

    public DateTime UpdateDate { get; set; }

    public string? ClearanceID { get; set; }
}
