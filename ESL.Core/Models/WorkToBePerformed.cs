using ESL.Core.Models.ComplexTypes;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
//using ESL.Core.Models.Collections;
using System.ComponentModel.DataAnnotations.Schema;

namespace ESL.Core.Models
{
    [PrimaryKey(nameof(FacilType),nameof(WorkNo))]
    [Index(nameof(FacilType), nameof(WorkNo), IsDescending = [false,false], IsUnique=true, Name = "WORKTOBEPERMED_PX")]
    [Table("ESL_WorkToBePerformed", Schema ="ESL")]
    public partial record WorkToBePerformed
    {
        ///// <summary>
        ///// Gets or sets the Facility No [NUMBER(3)] of the Facility.
        ///// [DataObjectField(key, identity, isNullable]
        ///// </summary>
        //[DataObjectField(true, true, false)]
        //[DisplayName("Facility No.")]
        //public int FacilNo { get; set; }

        [DataObjectField(false, true, false, 5)]
        [DisplayName("Facility Type")]
        [Column("FACILTYPE", TypeName = "VARCHAR2")]
        public string FacilType { get; set; } = null!;

        [DataObjectField(true, true, false, 3)]
        [DisplayName("Work No.")]
        [Column("WORKNO", TypeName ="NUMBER")]
        public int WorkNo { get; set; }
        
        [DataObjectField(false, true, false, 200)]
        [Column("WORKDESCRIPTION", TypeName = "VARCHAR2")]
        public string WorkDescription { get; set; } = null!;

        /// <summary>
        /// Gets or sets the notes of the FlowChange.
        /// </summary>
        [DataObjectField(false, false, true, 400)]
        [Column("NOTES", TypeName = "VARCHAR2")]
        public string? Notes { get; set; }

        [DataObjectField(false, false, true, 2)]
        [DisplayName("Sort No.")]
        [Column("SORTNO", TypeName ="NUMBER")]
        public int? SortNo { get; set; }

        [DataObjectField(false, false, true, 30)]
        [DisplayName(nameof(Disable))]
        [Column("DISABLE", TypeName ="VARCHAR2")]
        public string? Disable { get; set; }

        /// <summary>
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