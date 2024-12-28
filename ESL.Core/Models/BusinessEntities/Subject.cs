using ESL.Core.Models.ComplexTypes;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ESL.Core.Models.BusinessEntities
{

    [PrimaryKey(nameof(FacilNo), nameof(SubjectNo))]
    [Table("ESL_SUBJECTS", Schema = "ESL")]
    public partial record Subject
    {
        [DataObjectField(true, true, false, 2)]
        [DisplayName("Facility No.")]
        [Column("FACILNO", TypeName = "NUMBER")]
        public int FacilNo { get; set; }

        [DataObjectField(true, true, false, 3)]
        [DisplayName("subject No.")]
        [Column("SUBJNO")]
        public int SubjectNo { get; set; }

        [DataObjectField(false, true, false, 100)]
        [DisplayName("subject")]
        [Column("SUBNAME")]
        public string SubjectName { get; set; } = null!;

        [DataObjectField(false, true, false, 5)]
        [DisplayName("Facility Type")]
        [Column("FACILTYPE")]
        public string FacilType { get; set; } = null!;

        [DataObjectField(false, false, true, 2)]
        [DisplayName("Sort No.")]
        [Column("SORTNO")]
        public int? SortNo { get; set; }

        [DataObjectField(false, false, true, 400)]
        [DisplayName("Notes")]
        [Column("NOTES", TypeName = "VARCHAR2")]
        public string? Notes { get; set; }

        [DataObjectField(false, false, true, 30)]
        [DisplayName(nameof(Disable))]
        [Column("DISABLE")]
        public string? Disable { get; set; }

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

        [NotMapped]
        //[ForeignKey(nameof(FacilNo), nameof(Details.SubjectNo))]
        public virtual ICollection<Details> DetailsList { get; set; } = [];
    }
}