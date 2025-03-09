using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ESL.Core.Models.BusinessEntities;

[Keyless]
// This may be redundant as it just select * from the workorder table
public partial class ViewWorkOrder
{
    [Column("FACILNO", TypeName = "NUMBER")]
    public int FacilNo { get; set; }

    [Column("LOGTYPENO", TypeName = "NUMBER")]
    public int LogTypeNo { get; set; }

    [Column("EVENTID", TypeName = "VARCHAR2")]
    public string EventID { get; set; } = null!;

    [Column("WO_NO", TypeName = "VARCHAR2")]
    public string Wo_No { get; set; } = null!;

    [Column("NOTES", TypeName = "VARCHAR2")]
    public string? Notes { get; set; }

    [Column("UPDATEBY", TypeName = "VARCHAR2")]
    public string? UpdatedBy { get; set; }

    [Column("UPDATEDATE", TypeName = "VARCHAR2")]
    public string? UpdateDate { get; set; }
}
