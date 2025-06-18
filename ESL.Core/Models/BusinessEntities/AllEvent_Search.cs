//using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ESL.Core.Models.BusinessEntities;

//[Keyless]
public partial class AllEvent_Search
{
    [Column("FACILNO", TypeName = "NUMBER")]
    public int FacilNo { get; set; }

    [Column("LOGTYPENO", TypeName = "NUMBER")]
    public int LogTypeNo { get; set; }

    [Column("EVENTID", TypeName = "VARCHAR2")]
    public string EventID { get; set; } = null!;

    [Column("EVENTDATE", TypeName = "DATE")]
    public DateTime? EventDate { get; set; }

    [Column("EVENTTIME", TypeName = "VARCHAR2")]
    public string? EventTime { get; set; }

    [Column("SUBJECT", TypeName = "VARCHAR2")]
    public string? Subject { get; set; }

    [Column("DETAILS", TypeName = "VARCHAR2")]
    public string? Details { get; set; }

    [Column("LOGTYPENAME", TypeName = "VARCHAR2")]
    public string LogTypeName { get; set; } = null!;

    [Column("UPDATEBY", TypeName = "VARCHAR2")]
    public string? UpdatedBy { get; set; }

    [Column("UPDATEDATE", TypeName = "VARCHAR2")]
    public string? UpdateDate { get; set; }

    [Column("EVENTID_REVNO", TypeName = "NUMBER")]
    public int EventID_RevNo { get; set; }

    [Column("OPERATORTYPE", TypeName = "VARCHAR2")]
    public string? OperatorType { get; set; }

    [Column("CLEARANCEID", TypeName = "VARCHAR2")]
    public string? ClearanceID { get; set; }
}
