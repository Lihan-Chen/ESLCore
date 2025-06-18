using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ESL.Core.Models.BusinessEntities;

//[Keyless]
//[Table("ESL_RELATEDTO", Schema = "ESL")]
//[Index("FacilNo", "LogTypeNo", "EventID", "RelatedTo_Subject", Name = "ESL_RELATEDTO_PK", IsUnique = true)]
public partial record RelatedTo
{
    #region POCO Properties

    public int FacilNo { get; set; }

    public int LogTypeNo { get; set; }

    public string EventID { get; set; } = null!;

    public string RelatedTo_Subject { get; set; } = null!;

    public string? Notes { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdateDate { get; set; }

    #endregion POCO Properties

    //#region Public Properties

    //[DataObjectField(true, true, false, 2)]
    //[DisplayName("Facility No.")]
    //[Column("FACILNO", TypeName = "NUMBER")]
    ////[Precision(2)]
    //public int FacilNo { get; set; }

    //[DataObjectField(true, true, false, 2)]
    //[DisplayName("Log Type No.")]
    ////[ForeignKey("LOGTYPENO")]
    //[Column("LOGTYPENO", TypeName = "NUMBER")]
    ////[Key]
    ////[Precision(2)]
    //public int LogTypeNo { get; set; }

    //[DataObjectField(true, true, false, 20)]
    //[DisplayName("Event ID")]
    //[Column("EVENTID", TypeName = "VARCHAR2")]
    ////[StringLength(20)]
    ////[Unicode(false)]
    //public string EventID { get; set; } = null!;

    //[DataObjectField(true, true, false, 120)]
    //[DisplayName("Related Subject")]
    //[Column("RELATEDTO_SUBJECT", TypeName = "VARCHAR2")]
    //[StringLength(120)]
    //[Unicode(false)]
    //public string RelatedTo_Subject { get; set; } = null!;

    //[DataObjectField(false, false, true, 400)]
    //[DisplayName("Notes")]
    //[Column("NOTES", TypeName = "VARCHAR2")]
    ////[StringLength(400)]
    ////[Unicode(false)]
    //public string? Notes { get; set; }

    ///// <summary>
    ///// Gets or sets the UID of the record.
    ///// </summary>
    //[DataObjectField(false, false, true, 60)]
    //[DisplayName("Updated By")]
    //[Column("UPDATEDBY", TypeName = "VARCHAR2")]
    ////[StringLength(60)]
    ////[Unicode(false)]
    //public string? UpdatedBy { get; set; }

    ///// <summary>
    ///// Gets or sets the UpdateDate of the record.
    ///// </summary>
    //[DataObjectField(false, false, true)]
    //[DisplayName("Updated on")]
    //[Column("UPDATEDATE", TypeName = "DATE")]
    ////[Column(TypeName = "DATE")]
    //public DateTime? UpdateDate { get; set; }

    //#endregion Public Properties
}
