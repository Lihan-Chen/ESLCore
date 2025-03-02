using ESL.Core.Models.ComplexTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
//using ESL.Core.Models.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ESL.Core.Models.BusinessEntities
{
    [PrimaryKey(nameof(FacilNo), nameof(LogTypeNo), nameof(EventID), nameof(ScanNo))]

    [Table($"ESL_SCANDOCS", Schema = "ESL")]
    public partial record ScanDoc
    {
        /// <summary>
        /// Gets or sets the FacilNo of the Facility.
        /// </summary>
        [DataObjectField(true, true, false, 2)]
        [DisplayName("Facil. No.")]
        [Column("FACILNO", TypeName = "NUMBER")]
        public int FacilNo { get; set; }

        /// <summary>
        /// Gets or sets the LogTypeNo of the Log Type.
        /// </summary>
        [DataObjectField(true, true, false, 2)]
        [DisplayName("Log Type No.")]
        [Column("LOGTYPENO", TypeName = "NUMBER")]
        public int LogTypeNo { get; set; }

        /// <summary>
        /// Gets or sets the EventID of the Event.
        /// </summary>
        [DataObjectField(true, true, false, 20)]
        [DisplayName("Event ID")]
        [Column("EVENTID", TypeName = "VARCHAR2")]
        public string EventID { get; set; } = null!;

        [DataObjectField(true, true, false, 2)]
        [DisplayName("Scanned Document No.")]
        [Column("SCANNO", TypeName = "NUMBER")]
        public int ScanNo { get; set; }

        [DataObjectField(false, false, false, 100)]
        [DisplayName("Scan File Name")]
        [Column("SCANFILENAME", TypeName = "VARCHAR2")]
        public string ScanFileName { get; set; } = null!;

        /// <summary>
        /// Gets or sets the notes of the FlowChange.
        /// </summary>
        [DataObjectField(false, false, true, 400)]
        [Column("NOTES", TypeName = "VARCHAR2")]
        public string? Notes { get; set; }

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

        // not supported
        //public ICollection<AllEvent> AllEvents { get; set; } = new List<AllEvent>();
    }
}
