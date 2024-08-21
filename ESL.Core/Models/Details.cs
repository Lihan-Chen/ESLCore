using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ESL.Core.Models.Validation;
using ESL.Core.Models.ComplexTypes;

namespace ESL.Core.Models
{

    [PrimaryKey(nameof(FacilNo), nameof(DetailsNo))]
    [Table($"ESL_{nameof(Details)}")]
    public partial class Details
    {
        [DataObjectField(true, true, false, 3)]
        [DisplayName("Facility No.")]
        //[ForeignKey(nameof(FacilNo)), Column(nameof(FacilNo),Order = 0)]
        //[Column(nameof(FacilNo))]
        public int FacilNo { get; set; }

        [DataObjectField(true, true, false, 3)]
        [DisplayName("Details No.")]
        //[ForeignKey(nameof(SubjectNo)), Column(nameof(DetailsNo),Order = 1)]
        //[Column(nameof(DetailsNo))]
        public int DetailsNo { get; set; }

        [DataObjectField(false, true, false, 100)]
        [DisplayName("Detail Name")]
        [Column(nameof(DetailsName))]
        public string DetailsName { get; set; } = null!;

        [DataObjectField(false, false, false, 5)]
        [DisplayName("Faclity Type")]
        [Column(nameof(FacilType))]
        public string FacilType { get; set; } = null!;

        [DataObjectField(false, false, true, 2)]
        [Column(nameof(SortNo))]
        public int? SortNo { get; set; }

        [DataObjectField(false, false, true, 400)]
        [DisplayName("Notes")]
        [Column(nameof(Notes))]
        public string? Notes { get; set; }

        [DataObjectField(false, false, true, 2)]
        [DisplayName("Subject No.")]
        [Column("SubjNo")]
        public int? SubjectNo { get; set; }

        [DataObjectField(false, false, true)]
        [DisplayName("Subject")]
        [NotMapped]
        public string SubjectName { get; set; } = null!;

        [DataObjectField(false, false, true, 30)]
        [Column($"{nameof(Disable)}d?")]
        public string? Disable { get; set; }

        /// <summary>
        /// Gets or sets the UID of the record.
        /// </summary>
        [DataObjectField(false, false, true, 60)]
        [DisplayName("Updated By")]
        public string? UpdatedBy { get; set; } 

        /// <summary>
        /// Gets or sets the updateDate of the record.
        /// </summary>
        [DataObjectField(false, false, true)]
        [DisplayName("Updated on")]
        public DateTimeOffset UpdateDate { get; set; }

        //[ForeignKey(nameof(FacilNo)), Column(Order = 0))]
        //[ForeignKey(nameof(SubjectNo)), Column(Order = 1))]
        //[NotMapped]
        public virtual Subject Subject { get; set; } = new Subject();
    }
}