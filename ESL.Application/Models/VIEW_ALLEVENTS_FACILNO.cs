using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ESL.Application.Models;

[Keyless]
public partial class VIEW_ALLEVENTS_FACILNO
{
    [Precision(2)]
    public byte FACILNO { get; set; }

    [StringLength(40)]
    [Unicode(false)]
    public string FACILNAME { get; set; } = null!;

    [StringLength(5)]
    [Unicode(false)]
    public string FACILABBR { get; set; } = null!;
}
