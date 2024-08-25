using ESL.Core.Models.ComplexTypes;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace ESL.Core.Models
{
    [PrimaryKey(nameof(FacilType),nameof(ZoneNo))]
    [Table($"ESL_CLEARANCEZONES", Schema ="ESL")]
    public partial record ClearanceZone
    {
        [DataObjectField(true, true, false, 5)]
        [DisplayName("Facil. Type")]
        [Column("FACILTYPE", TypeName = "VARCHAR2")]
        public string FacilType { get; set; } = null!;

        [DataObjectField(true, true, false, 3)]
        [DisplayName("Zone No.")]
        [Column("ZONENO", TypeName = "NUMBER")]
        public int ZoneNo { get; set; }

        [DataObjectField(false, false, true, 200)]
        [DisplayName("Zone Description")]
        [Column("ZONEDESCRIPTION", TypeName = "VARCHAR2")] 
        public string? ZoneDescription { get; set; }

        [DataObjectField(false, false, false, 30)]
        [DisplayName("Diabled?")]
        [Column("DISABLE", TypeName = "VARCHAR2")] 
        public string? Disable { get; set; }

        [DataObjectField(false, false, false, 2)]
        [DisplayName("Sort No.")]
        [Column("SORTNO", TypeName = "NUMBER")] 
        public int? SortNo { get; set; }

        [DataObjectField(false, false, false, 400)]
        [DisplayName("Notes")]
        [Column("NOTES", TypeName = "VARCHAR2")]
        public string? Notes { get; set; }

        //// <summary>
        /// Gets or sets the UID of the record.
        /// </summary>
        [DataObjectField(false, false, false, 60)]
        [DisplayName("Updated By")]
        [Column("UPDATEDBY", TypeName = "VARCHAR2")]
        public string? UpdatedBy { get; set; }

        /// <summary>
        /// Gets or sets the UpdateDate of the record.
        /// </summary>
        [DataObjectField(false, false, false)]
        [DisplayName("Updated on")]
        [Column("UPDATEDATE", TypeName = "DATE")]
        public DateTime? UpdateDate { get; set; }

        /// <summary>
        /// Gets or sets the FacilNo of the Facility.
        /// </summary>
        [DataObjectField(true, true, false, 2)]
        [DisplayName("Facil. No.")]
        [ForeignKey(nameof(Facility))]
        [Column("FACILNO", TypeName = "NUMBER")]
        public int? FacilNo { get; set; }
    }
}
