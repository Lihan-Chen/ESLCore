using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using ESL.Core.Models.Collections;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ESL.Core.Models
{
    [PrimaryKey(nameof(FacilNo), nameof(EquipNo))]
    [Table("ESL_EquipmentInvolved")]
    public class EquipmentInvolved
    {
        [DataObjectField(true, true, false, 3)]
        [DisplayName("Facility No.")]
        [Column(nameof(FacilNo))]
        public int FacilNo { get; set; }

        [DataObjectField(false, true, false, 5)]
        [DisplayName("Facility Type")]
        public string FacilType { get; set; } = null!;

        [DataObjectField(true, true, false, 3)]
        [DisplayName("Equipment No.")]
        [Column(nameof(EquipNo))]
        public int EquipNo { get; set; }

        [DataObjectField(false, true, false, 100)]
        [DisplayName("Equipment")]
        [Column(nameof(EquipName))]
        public string EquipName { get; set; } = null!;

        [DataObjectField(false, false, true, 400)]
        [DisplayName("Notes")]
        [Column(nameof(Notes))]
        public string? Notes { get; set; }

        [DataObjectField(false, false, true, 30)]
        [DisplayName("Disable?")]
        [Column(nameof(Disable))]
        public string? Disable { get; set; }

        [DataObjectField(false, false, true, 60)]
        [DisplayName("Updated By")]
        [Column(nameof(UpdatedBy))]
        public string? UpdatedBy { get; set; }

        [DataObjectField(false, false, true)]
        [DisplayName("Update Date")]
        [Column(nameof(UpdateDate))]
        public DateTime? UpdateDate { get; set; }

    }
}