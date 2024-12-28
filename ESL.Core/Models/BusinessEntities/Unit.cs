using ESL.Core.Models.ComplexTypes;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ESL.Core.Models.BusinessEntities
{

    [PrimaryKey(nameof(UnitNo))]
    [Table("ESL_UNITS", Schema ="ESL")]
    public partial record Unit
    {
        /// <summary>
        /// Gets or sets the Facility No [NUMBER(3)] of the Facility.
        /// [DataObjectField(key, identity, isNullable]
        /// </summary>
        [DataObjectField(true, true, false, 2)]
        [DisplayName("Unit No.")]
        [Column(nameof(UnitNo))]
        public int UnitNo { get; set; }

        [DataObjectField(false, false, true, 20)]
        [Column(nameof(UnitName))]
        public string? UnitName { get; set; }

        [DataObjectField(false, false, true, 200)]
        [Column(nameof(UnitDesc))]
        public string? UnitDesc { get; set; }

        [DataObjectField(false, false, true, 200)]
        [DisplayName("Notes")]
        [Column("NOTES", TypeName = "VARCHAR2")]
        public string? Notes { get; set; }

        /// <summary>
        /// Gets or sets the UID of the record.
        /// </summary>
        [DataObjectField(false, false, false, 60)]
        [DisplayName("Updated By")]
        [Column("UPDATEDBY", TypeName = "VARCHAR2")]
        public string? UpdatedBy { get; set; } = null!;

        /// <summary>
        /// Gets or sets the UpdateDate of the record.
        /// </summary>
        [DataObjectField(false, false, false)]
        [DisplayName("Updated on")]
        [Column("UPDATEDATE", TypeName = "DATE")]
        public DateTime? UpdateDate { get; set; }
    }
}