//using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ESL.Core.Models.BusinessEntities;

//[Keyless]
public partial class AllEventRelatedTo
{
    [Column("FACILNO", TypeName = "NUMBER")]
    public int FacilNo { get; set; }

    [Column("FACILNAME", TypeName = "VARCHAR2")]
    public string FacilName { get; set; } = null!;

    [Column("FACILABBR", TypeName = "VARCHAR2")]
    public string FacilAbbr { get; set; } = null!;

    [Column("LOGTYPENO", TypeName = "NUMBER")]
    public int LogTypeNo { get; set; }

    [Column("LOGTYPENAME", TypeName = "VARCHAR2")]
    public string LogTypeName { get; set; } = null!;

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

    [Column("OPERATORTYPE", TypeName = "VARCHAR2")]
    public string? OperatorType { get; set; }

    [Column("UPDATEBY", TypeName = "VARCHAR2")]
    public string? UpdatedBy { get; set; }

    [Column("UPDATEDATE", TypeName = "VARCHAR2")]
    public string? UpdateDate { get; set; }

    [Column("CLEARANCEID", TypeName = "VARCHAR2")]
    public string? ClearanceID { get; set; }
}
