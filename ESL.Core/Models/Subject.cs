using ESL.Core.Models.ComplexTypes;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace ESL.Core.Models
{
    [PrimaryKey(nameof(FacilNo), nameof(SubjectNo))]
    [Table("ESL_Subjects")]
    public partial record Subject
    {
        [DataObjectFieldAttribute(true, true, false, 2)]
        [DisplayName("Facility No.")]
        [Column(nameof(FacilNo))]
        public int FacilNo { get; set; }

        [DataObjectFieldAttribute(true, true, false, 3)]
        [DisplayName("subject No.")]
        [Column("SubjNo")]
        public int SubjectNo { get; set; }

        [DataObjectFieldAttribute(false, true, false, 100)]
        [DisplayName("subject")]
        [Column("SubjName")]
        public string SubjectName { get; set; } = null!;

        [DataObjectFieldAttribute(false, true, false, 5)]
        [DisplayName("Facility Type")]
        [Column(nameof(FacilType))]
        public string FacilType { get; set; } = null!;

        [DataObjectFieldAttribute(false, false, true, 2)]
        [DisplayName("Sort No.")]
        [Column(nameof(SortNo))]
        public int? SortNo { get; set; }

        [DataObjectFieldAttribute(false, false, true, 400)]
        [DisplayName("Notes")]
        [Column(nameof(Notes))]
        public string? Notes { get; set; }

        [DataObjectFieldAttribute(false, false, true, 30)]
        [DisplayName(nameof(Disable))]
        [Column(nameof(Disable))]
        public string? Disable { get; set; }

        public Update Update { get; set; } = new Update();

        //[ForeignKey(nameof(FacilNo), nameof(Details.SubjectNo))]
        public virtual ICollection<Details> DetailsList { get; set; } = new List<Details>();
    }
}