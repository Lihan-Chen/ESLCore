using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using ESL.Core.Models.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ESL.Core.Models
{
    [NotMapped]
    public class Location
    {
        // ONLY FOR FACILNO >= 50
        [DataObjectField(true, true, false)]
        [Range(50, 300)]
        [DisplayName("Facility No.")]
        public int FacilNo { get; set; }

        [DataObjectField(false, true, false)]
        [DisplayName("Facility")]
        public string FacilName { get; set; } = null!;

        [DataObjectField(false, true, false)]
        [DisplayName("Abreviation")]
        public string FacilAbbr { get; set; } = null!;

        [DataObjectField(false, false, true)]
        [DisplayName("Notes")]
        public string? Notes { get; set; }

        [DataObjectField(false, false, true)]
        [DisplayName("Updated By")]
        public string? UpdatedBy { get; set; }

        [DataObjectField(false, false, true)]
        [DisplayName("Update Date")]
        public DateTime? UpdateDate { get; set; }

        [DataObjectField(false, false, true)]
        [DisplayName("Disable?")]
        public string? Disable { get; set; }
    }
}