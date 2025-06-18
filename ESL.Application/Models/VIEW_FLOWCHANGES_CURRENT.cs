﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ESL.Application.Models;

[Keyless]
public partial class VIEW_FLOWCHANGES_CURRENT
{
    [Precision(2)]
    public int FACILNO { get; set; }

    [StringLength(40)]
    [Unicode(false)]
    public string FACILNAME { get; set; } = null!;

    [Precision(2)]
    public int LOGTYPENO { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string LOGTYPENAME { get; set; } = null!;

    [StringLength(20)]
    [Unicode(false)]
    public string EVENTID { get; set; } = null!;

    [Precision(2)]
    public int EVENTID_REVNO { get; set; }

    [Precision(7)]
    public int OPERATORID { get; set; }

    [Precision(7)]
    public int? CREATEDBY { get; set; }

    [Column(TypeName = "DATE")]
    public DateTime? CREATEDDATE { get; set; }

    [Precision(7)]
    public int REQUESTEDBY { get; set; }

    [Precision(7)]
    public int REQUESTEDTO { get; set; }

    [Column(TypeName = "DATE")]
    public DateTime REQUESTEDDATE { get; set; }

    [StringLength(5)]
    [Unicode(false)]
    public string REQUESTEDTIME { get; set; } = null!;

    [Column(TypeName = "DATE")]
    public DateTime EVENTDATE { get; set; }

    [StringLength(5)]
    [Unicode(false)]
    public string EVENTTIME { get; set; } = null!;

    [StringLength(5)]
    [Unicode(false)]
    public string? OFFTIME { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string METERID { get; set; } = null!;

    [StringLength(10)]
    [Unicode(false)]
    public string? CHANGEBY { get; set; }

    [Column(TypeName = "NUMBER(10,2)")]
    public decimal? NEWVALUE { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? UNIT { get; set; }

    [Column(TypeName = "NUMBER(10,2)")]
    public decimal? OLDVALUE { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? OLDUNIT { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? CHANGEBYUNIT { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? ACCEPTED { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? MODIFYFLAG { get; set; }

    [Precision(7)]
    public int? MODIFIEDBY { get; set; }

    [Column(TypeName = "DATE")]
    public DateTime? MODIFIEDDATE { get; set; }

    [StringLength(400)]
    [Unicode(false)]
    public string? NOTES { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string? NOTIFIEDFACIL { get; set; }

    [Precision(7)]
    public int? NOTIFIEDPERSON { get; set; }

    [Precision(2)]
    public byte? SHIFTNO { get; set; }

    [StringLength(2)]
    [Unicode(false)]
    public string YR { get; set; } = null!;

    [Precision(6)]
    public int SEQNO { get; set; }

    [StringLength(60)]
    [Unicode(false)]
    public string UPDATEDBY { get; set; } = null!;

    [Column(TypeName = "DATE")]
    public DateTime UPDATEDATE { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? WORKORDERS { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string? RELATEDTO { get; set; }

    [StringLength(15)]
    [Unicode(false)]
    public string? OPERATORTYPE { get; set; }
}
