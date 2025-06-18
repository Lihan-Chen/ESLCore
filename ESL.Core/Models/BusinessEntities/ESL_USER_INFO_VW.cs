using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ESL.Core.Models.BusinessEntities;

/// <summary>
/// ESL_USER_INFO_VW entity class that maps to ESL_USER_INFO_VW view in ESL schema
/// The view is created from ps_m_ee_genl_data@pro2.world;
/// The object is not altered from scaffolded code.
/// </summary>
[Keyless]
public partial record ESL_USER_INFO_VW
{
    [StringLength(11)]
    [Unicode(false)]
    public string EMPLID { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string FULL_NAME { get; set; } = null!;

    [StringLength(30)]
    [Unicode(false)]
    public string FIRST_NAME { get; set; } = null!;

    [StringLength(30)]
    [Unicode(false)]
    public string LAST_NAME { get; set; } = null!;

    [StringLength(24)]
    [Unicode(false)]
    public string WORK_PHONE { get; set; } = null!;

    [StringLength(30)]
    [Unicode(false)]
    public string JOBTITLE { get; set; } = null!;

    [StringLength(30)]
    [Unicode(false)]
    public string DEPTNAME { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string MAIL_DROP { get; set; } = null!;

    [StringLength(30)]
    [Unicode(false)]
    public string M_DIVISION_DESC { get; set; } = null!;

    [StringLength(30)]
    [Unicode(false)]
    public string M_BRANCH_DESC { get; set; } = null!;

    [StringLength(30)]
    [Unicode(false)]
    public string M_SECTION_DESC { get; set; } = null!;

    [StringLength(30)]
    [Unicode(false)]
    public string M_UNIT_DESC { get; set; } = null!;

    [StringLength(41)]
    [Unicode(false)]
    public string? INTERNET_ID { get; set; }
}
