using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
//using ESL.Core.Models.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ESL.Core.Models
{
    [NotMapped]
    public partial record Location
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

        /// <summary>
        /// Gets or sets the UID of the record.
        /// </summary>
        [DataObjectField(false, false, false, 60)]
        [DisplayName("Updated By")]
        public string UpdatedBy { get; set; } = null!;

        /// <summary>
        /// Gets or sets the updateDate of the record.
        /// </summary>
        [DataObjectField(false, false, false)]
        [DisplayName("Updated on")]
        public DateTimeOffset UpdateDate { get; set; }

        [DataObjectField(false, false, true)]
        [DisplayName("Disable?")]
        public string? Disable { get; set; }
    }
}