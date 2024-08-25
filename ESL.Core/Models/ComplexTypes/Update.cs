using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ESL.Core.Models.ComplexTypes;

[ComplexType]
public record Update
{
    /// <summary>
    /// Gets or sets the UID of the record.
    /// </summary>
    [DataObjectField(false, false, false, 60)]
    [DisplayName("Updated By")]
    public string UpdatedBy { get; set; } = null!;

    /// <summary>
    /// Gets or sets the UpdateDate of the record.
    /// </summary>
    [DataObjectField(false, false, false)]
    public DateTimeOffset UpdateDate { get; set; }
}
