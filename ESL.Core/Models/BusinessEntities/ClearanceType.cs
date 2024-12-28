using ESL.Core.Models.ComplexTypes;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace ESL.Core.Models.BusinessEntities
{
    [PrimaryKey(nameof(ClearanceTypeNo))]
    [Table("ESL_CLEARANCETYPES", Schema = "ESL")]
    public partial record ClearanceType
    {
        [DataObjectField(true, true, false, 2)]
        [DisplayName("Clearance Type No.")]
        [Column("CLEARANCETYPENO", TypeName = "NUMBER")]
        public int ClearanceTypeNo { get; set; }

        [DataObjectField(false, false, false, 40)]
        [DisplayName("Clearance Type")]
        [Column("CLEARANCETYPENAME", TypeName = "VARCHAR2")]
        public string ClearanceTypeName { get; set; } = null!;

        [DataObjectField(false, false, false, 5)]
        [DisplayName("Clearance Type Abbreviation")]

        [Column("CLEARANCETYPEABBR", TypeName = "VARCHAR2")]
        public string ClearanceTypeAbbr { get; set; } = null!;

        [DataObjectField(false, false, false, 2)]
        [DisplayName("Sort No.")]
        [Column("SORTNO", TypeName = "NUMBER")]
        public int SortNo { get; set; }

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
    }
}
