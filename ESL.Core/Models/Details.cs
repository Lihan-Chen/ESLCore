using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace ESL.Core.Models
{

    [PrimaryKey(nameof(FacilNo), nameof(DetailsNo))]
    [Table($"ESL_DETAILS")]
    public partial class Details
    {
        [DataObjectField(true, true, false, 3)]
        [DisplayName("Facility No.")]
        //[ForeignKey(nameof(FacilNo)), Column(nameof(FacilNo), Order = 0)]
        [Column("FACILNO", TypeName = "NUMBER")]
        public int FacilNo { get; set; }

        [DataObjectField(true, true, false, 3)]
        [DisplayName("Details No.")]
        //[ForeignKey(nameof(SubjectNo)), Column(nameof(DetailsNo), Order = 1)]
        [Column("DETAILSNO", TypeName = "NUMBER")]
        public int DetailsNo { get; set; }

        [DataObjectField(false, true, false, 100)]
        [DisplayName("Detail Name")]
        [Column("DETAILSNAME", TypeName = "VARCHAR2")]
        public string DetailsName { get; set; } = null!;

        [DataObjectField(false, false, false, 5)]
        [DisplayName("Faclity Type")]
        [Column("FACILTYPE", TypeName = "VARCHAR2")]
        public string FacilType { get; set; } = null!;

        [DataObjectField(false, false, true, 2)]
        [Column("SORTNO", TypeName = "NUMBER")] 
        public int? SortNo { get; set; }

        [DataObjectField(false, false, true, 400)]
        [DisplayName("Notes")]
        [Column("NOTES", TypeName = "VARCHAR2")]
        public string? Notes { get; set; }

        [DataObjectField(false, false, true, 30)]
        [Column("DISABLE", TypeName = "VARCHAR2")]
        public string? Disable { get; set; }       

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

        [DataObjectField(false, false, true, 2)]
        [DisplayName("Subject No.")]
        [Column("SUBJNO", TypeName = "NUMBER")]
        public int? SubjectNo { get; set; }

        //[DataObjectField(false, false, true)]
        //[DisplayName("Subject")]
        //[NotMapped]
        //public string SubjectName { get; set; } = null!;

        //[ForeignKey(nameof(FacilNo)), Column(Order = 0))]
        //[ForeignKey(nameof(SubjectNo)), Column(Order = 1))]
        //[NotMapped]
        //public virtual Subject Subject { get; set; } = new Subject();
    }
}