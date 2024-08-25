using ESL.Core.Models.ComplexTypes;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ESL.Core.Models
{
    [PrimaryKey(nameof(FacilNo), nameof(SubjectNo))]
    [Table("ESL_Subjects")]
    public partial record Subject
    {
        [DataObjectField(true, true, false, 2)]
        [DisplayName("Facility No.")]
        [Column(nameof(FacilNo))]
        public int FacilNo { get; set; }

        [DataObjectField(true, true, false, 3)]
        [DisplayName("subject No.")]
        [Column("SubjNo")]
        public int SubjectNo { get; set; }

        [DataObjectField(false, true, false, 100)]
        [DisplayName("subject")]
        [Column("SubjName")]
        public string SubjectName { get; set; } = null!;

        [DataObjectField(false, true, false, 5)]
        [DisplayName("Facility Type")]
        [Column(nameof(FacilType))]
        public string FacilType { get; set; } = null!;

        [DataObjectField(false, false, true, 2)]
        [DisplayName("Sort No.")]
        [Column(nameof(SortNo))]
        public int? SortNo { get; set; }

        [DataObjectField(false, false, true, 400)]
        [DisplayName("Notes")]
        [Column("NOTES", TypeName = "VARCHAR2")]
        public string? Notes { get; set; }

        [DataObjectField(false, false, true, 30)]
        [DisplayName(nameof(Disable))]
        [Column(nameof(Disable))]
        public string? Disable { get; set; }

        /// <summary>
        /// Gets or sets the UID of the record.
        /// </summary>
        [DataObjectField(false, false, false, 60)]
        [DisplayName("Updated By")]
        public string? UpdatedBy { get; set; } = null!;

        /// <summary>
        /// Gets or sets the UpdateDate of the record.
        /// </summary>
        [DataObjectField(false, false, false)]
        [DisplayName("Updated on")]
        public DateTime? UpdateDate { get; set; }

        [NotMapped]
        //[ForeignKey(nameof(FacilNo), nameof(Details.SubjectNo))]
        public virtual ICollection<Details> DetailsList { get; set; } = new List<Details>();
    }
}