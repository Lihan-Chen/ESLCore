using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
//using ESL.Core.Models.Collections;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using ESL.Core.Models.ComplexTypes;

namespace ESL.Core.Models
{
    //[PrimaryKey(nameof(FacilType),nameof(ZoneNo))]
    //[Table("ESL_Zones")]
    [NotMapped]
    public partial record Zone
    {
        [DataObjectField(false, true, false, 3)]
        [DisplayName("Facility No.")]
        public int FacilNo { get; set; }

        [DataObjectField(true, true, false, 5)]
        public string FacilType { get; set; }  = string.Empty;

        [DataObjectField(true, true, false, 3)]
        [DisplayName("Zone No.")]
        public int ZoneNo { get; set; }

        [DataObjectField(false, true, false, 200)]
        public string ZoneDescription { get; set; } = string.Empty;

        [DataObjectField(false, false, true, 400)]
        [DisplayName("Notes")]
        public string? Notes { get; set; }

        [DataObjectField(false, false, true, 2)]
        public int SortNo { get; set; }

        [DataObjectField(false, false, true, 30)]
        [DisplayName("Disable?")]
        public string? Disable { get; set; }

        //public Update Update { get; set; } = new Update();

        /// <summary>
        /// Gets or sets the UID of the record.
        /// </summary>
        [DataObjectField(false, false, false, 60)]
        [DisplayName("Updated By")]
        public string UpdatedBy { get; set; } = null!;

        /// <summary>
        /// Gets or sets the UpdateDate of the record.
        /// </summary>
        [DataObjectField(false, false, false)]
        [DisplayName("Updated on")]
        public DateTimeOffset UpdateDate { get; set; }

    }
}