using ESL.Core.Models.ComplexTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
//using ESL.Core.Models.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ESL.Core.Models
{ 
    [PrimaryKey(nameof(FacilNo), nameof(LogTypeNo), nameof(EventID), nameof(ScanNo))]

    [Table($"ESL_{nameof(ScanDoc)}s")]
    public partial record ScanDoc
    {
        /// <summary>
        /// Gets or sets the Facility No [NUMBER(3)] of the Facility.
        /// [DataObjectField(key, identity, isNullable]
        /// </summary>
        [DataObjectField(true, true, false, 2)]
        [DisplayName("Facility No.")]
        public int FacilNo { get; set; }

        [DataObjectField(true, true, false, 2)]
        public int LogTypeNo { get; set; }

        [DataObjectField(true, true, false, 20)]
        public string EventID { get; set; } = string.Empty;

        [DataObjectField(true, true, false, 2)]
        [DisplayName("Scanned Document No.")]
        public int? ScanNo { get; set; }

        [DataObjectField(false, false, false, 100)]
        [DisplayName("Scan File Name")]
        public string ScanFileName { get; set; } = string.Empty;
        
        [DataObjectField(false, false, true, 400)]
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

        // not supported
        //public ICollection<AllEvent> AllEvents { get; set; } = new List<AllEvent>();
    }
}
