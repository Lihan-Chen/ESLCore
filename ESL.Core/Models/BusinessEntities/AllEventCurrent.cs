using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ESL.Core.Models.BusinessEntities;

//[Table("VIEW_ALLEVENTS_CURRENT", Schema = "ESL")]
[Keyless]
public partial record AllEventCurrent
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

    [Column("EVENTID_REVNO", TypeName = "NUMBER")]
    public int EventID_RevNo { get; set; }

    [Column("EVENTDATE", TypeName = "DATE")]
    public DateTime? EventDate { get; set; }

    [Column("EVENTTIME", TypeName = "VARCHAR2")]
    public string? EventTime { get; set; }

    [Column("SUBJECT", TypeName = "VARCHAR2")]
    public string? Subject { get; set; }

    [Column("DETAILS", TypeName = "VARCHAR2")]
    public string? Details { get; set; }

    [Column("MODIFYFLAG", TypeName = "VARCHAR2")]
    public string? ModifyFlag { get; set; }

    [Column("NOTES", TypeName = "VARCHAR2")]
    public string? Notes { get; set; }

    [Column("OPERATORTYPE", TypeName = "VARCHAR2")]
    public string? OperatorType { get; set; }

    [Column("UPDATEBY", TypeName = "VARCHAR2")]
    public string? UpdatedBy { get; set; }

    [Column("UPDATEDATE", TypeName = "VARCHAR2")]
    public string? UpdateDate { get; set; }

    [Column("CLEARANCEID", TypeName = "VARCHAR2")]
    public string? ClearanceID { get; set; }

    [Column("SCANDOCSNO", TypeName = "NUMBER")]
    public int? ScanDocsNo { get; set; }

    [NotMapped]
    public string EventIDentifier => $"{EventID}/{EventID_RevNo}";

    [NotMapped]
    public virtual Facility Facility { get; set; } = new Facility();
    [NotMapped]
    public virtual LogType LogType { get; set; } = new LogType();

}
