using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ESL.Api.Models.ComplexTypes
{

    [Owned]
    public partial record Update
    { 
    /// <summary>
    /// Gets or sets the UID of the record.
    /// </summary>
    [DataObjectField(false, false, true, 60)]
    [DisplayName("Updated By")]
    [Column("UPDATEDBY", TypeName = "VARCHAR2")]
    public string? UpdatedBy { get; set; }

    /// <summary>
    /// Gets or sets the UpdateDate of the record.
    /// </summary>
    [DataObjectField(false, false, true)]
    [DisplayName("Updated on")]
    [Column("UPDATEDATE", TypeName = "DATE")]
    public DateTime? UpdateDate { get; set; }

    }
}