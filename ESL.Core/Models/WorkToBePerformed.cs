using ESL.Core.Models.ComplexTypes;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
//using ESL.Core.Models.Collections;
using System.ComponentModel.DataAnnotations.Schema;

namespace ESL.Core.Models
{
    [PrimaryKey(nameof(FacilType),nameof(WorkNo))]
    [Table("ESL_WorkToBePerformed")]
    public partial record WorkToBePerformed
    {
        ///// <summary>
        ///// Gets or sets the Facility No [NUMBER(3)] of the Facility.
        ///// [DataObjectFieldAttribute(key, identity, isNullable]
        ///// </summary>
        //[DataObjectFieldAttribute(true, true, false)]
        //[DisplayName("Facility No.")]
        //public int FacilNo { get; set; }

        [DataObjectFieldAttribute(false, true, false, 5)]
        [DisplayName("Facility Type")]
        [Column(nameof(FacilType))]
        public string FacilType { get; set; } = null!;

        [DataObjectFieldAttribute(true, true, false, 3)]
        [DisplayName("Work No.")]
        [Column(nameof(WorkNo))]
        public int WorkNo { get; set; }
        
        [DataObjectFieldAttribute(false, true, false, 200)]
        [Column(nameof(WorkDescription))]
        public string WorkDescription { get; set; } = null!;
       
        [DataObjectFieldAttribute(false, false, true, 400)]
        [DisplayName("Notes")]
        [Column(nameof(Notes))]
        public string? Notes { get; set; }

        [DataObjectFieldAttribute(false, false, true, 2)]
        [DisplayName("Sort No.")]
        [Column(nameof(SortNo))]
        public int? SortNo { get; set; }

        [DataObjectFieldAttribute(false, false, true, 30)]
        [DisplayName(nameof(Disable))]
        [Column(nameof(Disable))]
        public string? Disable { get; set; }

        public Update Update { get; set; } = new Update();

    }
}