using ESL.Core.Models.ComplexTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
//using ESL.Core.Models.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ESL.Core.Models
{
    [Table($"ESL_{nameof(ScanDoc)}s")]
    public partial record ScanDoc
    {
        /// <summary>
        /// Gets or sets the Facility No [NUMBER(3)] of the Facility.
        /// [DataObjectFieldAttribute(key, identity, isNullable]
        /// </summary>
        [DataObjectFieldAttribute(true, true, false)]
        [DisplayName("Facility No.")]
        public int FacilNo { get; set; }

        [DataObjectFieldAttribute(true, true, false)]
        public int LogTypeNo { get; set; }

        [DataObjectFieldAttribute(true, true, false)]
        public string EventID { get; set; } = string.Empty;

        [DataObjectFieldAttribute(true, true, false)]
        [DisplayName("Scanned Document No.")]
        public int? ScanNo { get; set; }

        [DataObjectFieldAttribute(false, false, false)]
        [DisplayName("Scan File Name")]
        public string ScanFileName { get; set; } = string.Empty;
        
        [DataObjectFieldAttribute(false, false, true)]
        [DisplayName("Notes")]
        public string? Notes { get; set; }

        public Update Update { get; set; } = new Update();

        public ICollection<AllEvent> AllEvents { get; set; } = new List<AllEvent>();
    }
}