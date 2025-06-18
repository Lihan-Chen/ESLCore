using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ESL.Core.Models.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace ESL.Application.Models;

[Keyless]
public partial class Outstanding_General // VIEW_GENERAL_OUTSTANDING
{
    [Precision(2)]
    public byte? ModifyFlag { get; set; }
    [StringLength(2000)]
    [Unicode(false)]
    public string? Notes { get; set; }
    [Precision(2)]
    public byte? ClearanceID { get; set; }

    [Precision(2)]
    public int FacilNo { get; set; }

    [Precision(2)]
    public int LogTypeNo { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string EventID { get; set; } = null!;

    [Precision(2)]
    public byte EventID_RevNo { get; set; }

    [Column(TypeName = "DATE")]
    public DateTime? EventDate { get; set; }

    [StringLength(5)]
    [Unicode(false)]
    public string? EventTime { get; set; }

    [StringLength(300)]
    [Unicode(false)]
    public string? Subject { get; set; }

    [StringLength(2000)]
    [Unicode(false)]
    public string? Details { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string LogTypeName { get; set; } = null!;

    [StringLength(40)]
    [Unicode(false)]
    public string FacilName { get; set; } = null!;

    public Update Update { get; set; } = new Update();

    [StringLength(15)]
    [Unicode(false)]
    public string? OperatorType { get; set; }

    [Column(TypeName = "NUMBER")]
    public decimal? ScanDocsNo { get; set; }
}
