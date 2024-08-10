using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using ESL.Core.Models.Collections;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations.Schema;

namespace ESL.Core.Models
{
    [PrimaryKey(nameof(FacilType), nameof(ZoneNo))]
    [Table("ESL_ClearanceZones")]
    public class ClearanceZone
    {

        [DataObjectField(true, true, false, 5)]
        [DisplayName("Facility Type")]
        public string FacilType { get; set; } = null!;

        [DataObjectField(true, true, false, 3)]
        [DisplayName("Zone No.")]
        public int ZoneNo { get; set; }

        [DataObjectField(false, false, true, 200)]
        [Display(Name = "Zone Description")]
        public string? ZoneDescription { get; set; }

        [DataObjectField(false, false, true, 30)]
        [Display(Name = "Disable?")]
        public string? Disable { get; set; }

        [DataObjectField(false, false, true, 2)]
        public int? SortNo { get; set; }

        [DataObjectField(false, false, true, 400)]
        [DisplayName("Notes")]
        public string? Notes { get; set; }

        [DataObjectField(false, false, true, 60)]
        [DisplayName("Updated By")]
        public string? UpdatedBy { get; set; }

        [DataObjectField(false, false, true)]
        [DataType(DataType.Date)]
        [DisplayName("Update Date")]
        public DateTime? UpdateDate { get; set; }
    }
}