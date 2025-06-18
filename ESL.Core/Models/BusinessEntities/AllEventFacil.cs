//using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ESL.Core.Models.BusinessEntities;

//[Keyless]
public partial record AllEventFacil
{
    [Column("FACILNO", TypeName = "NUMBER")]
    public int FacilNo { get; set; }

    [Column("FACILNAME", TypeName = "VARCHAR2")]
    public string FacilName { get; set; } = null!;

    [Column("FACILABBR", TypeName = "VARCHAR2")]
    public string FacilAbbr { get; set; } = null!;
}