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
    [PrimaryKey(nameof(FacilNo),nameof(LogTypeNo),nameof(EventID),nameof(WO_No))]
    [Table("ESL_WorkOrders")]
    public partial record WorkOrder
    {
        /// <summary>
        /// Gets or sets the Facility No [NUMBER(3)] of the Facility.
        /// [DataObjectField(key, identity, isNullable]
        /// </summary>
        [DataObjectField(true, true, false)]
        [DisplayName("Facility No.")]
        [Column(nameof(FacilNo))]
        public int FacilNo { get; set; }

        [DataObjectField(true, true, false)]
        [Column(nameof(LogTypeNo))]
        public int LogTypeNo { get; set; }

        [DataObjectField(true, true, false)]
        [Column(nameof(EventID))]
        public string EventID { get; set; } = null!;
    
        [DataObjectField(true, true, false)]
        [DisplayName("Work Order No.")]
        [Column(nameof(WO_No))]
        public string WO_No { get; set; } = null!;

        [DataObjectField(false, false, true)]
        [DisplayName("Notes")]
        [Column(nameof(Notes))]
        public string? Notes { get; set; }

        //public Update Update { get; set; } = new Update();

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
    }
}