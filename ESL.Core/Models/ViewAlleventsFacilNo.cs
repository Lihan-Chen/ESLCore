using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ESL.Core.Models;

[Keyless]
public partial class ViewAlleventsFacilNo
{
    [Column("FACILNO", TypeName ="NUMBER")]
    public int FacilNo { get; set; }

    [Column("FacilName", TypeName = "VARCHAR2")]
    public string FacilName { get; set; } = null!;

    [Column("FacilAbbr", TypeName = "VARCHAR2")]
    public string FacilAbbr { get; set; } = null!;
}
