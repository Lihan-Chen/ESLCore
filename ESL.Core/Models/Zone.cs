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
        [DataObjectFieldAttribute(false, true, false, 3)]
        [DisplayName("Facility No.")]
        public int FacilNo { get; set; }

        [DataObjectFieldAttribute(true, true, false, 5)]
        public string FacilType { get; set; }  = string.Empty;

        [DataObjectFieldAttribute(true, true, false, 3)]
        [DisplayName("Zone No.")]
        public int ZoneNo { get; set; }

        [DataObjectFieldAttribute(false, true, false, 200)]
        public string ZoneDescription { get; set; } = string.Empty;

        [DataObjectFieldAttribute(false, false, true, 400)]
        [DisplayName("Notes")]
        public string? Notes { get; set; }

        [DataObjectFieldAttribute(false, false, true, 2)]
        public int SortNo { get; set; }

        [DataObjectFieldAttribute(false, false, true, 30)]
        [DisplayName("Disable?")]
        public string? Disable { get; set; }

        public Update Update { get; set; } = new Update();


    }
}