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
        [DataObjectFieldAttribute(true, true, false, 3)]
        [DisplayName("Facility No.")]
        [ForeignKey(nameof(Subject))]
        [Column(nameof(FacilNo))]
        public int FacilNo { get; set; }

        [DataObjectFieldAttribute(true, true, false, 3)]
        [DisplayName("Details No.")]
        [Column(nameof(DetailsNo))]
        public int DetailsNo { get; set; }
        
        [DataObjectFieldAttribute(false, true, false, 100)]
        [DisplayName("Detail Name")]
        [Column(nameof(DetailsName))]
        public string DetailsName { get; set; } = null!;

        [DataObjectFieldAttribute(false, true, false, 5)]
        [Column(nameof(FacilType))]
        public string FacilType { get; set; } = null!;

        [DataObjectFieldAttribute(false, false, true, 2)]
        [Column(nameof(SortNo))]
        public int? SortNo { get; set; }

        [DataObjectFieldAttribute(false, false, true, 400)]
        [DisplayName("Notes")]
        [Column(nameof(Notes))]
        public string? Notes { get; set; }

        [DataObjectFieldAttribute(false, false, true, 2)]
        [ForeignKey(nameof(Subject))]
        [Column("SubjNo")]
        public int? SubjectRefNo { get; set; }

        [DataObjectFieldAttribute(false, false, true)]
        [DisplayName("Subject")]
        [NotMapped]
        public string SubjectName { get; set; } = null!;

        [DataObjectFieldAttribute(false, false, true, 30)]
        [Column(nameof(Disable))]
        public string? Disable { get; set; }

        public Update Update { get; set; } = new Update();

        public virtual Subject Subject { get; set; } = new Subject();
    }
}