﻿using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using ESL.Core.Models.Validation;

namespace ESL.Core.Models
{

    [PrimaryKey(nameof(FacilNo),nameof(LogTypeNo),nameof(EventID),nameof(RelatedTo_Subject))]    
    [Table("ESL_RelatedTo")]
        public class RelatedTo
    {
        [DataObjectField(true, true, false)]
        [DisplayName("Facility No.")]
        public int FacilNo { get; set; }

        [DataObjectField(true, true, false)]
        [DisplayName("Log Type No.")]
        public int LogTypeNo { get; set; }

        //CONSTANTNAME  VARCHAR2(20 BYTE)
        [DataObjectField(true, true, false)]
        public string EventID { get; set; } = null!;

        [DataObjectField(true, true, false)]
        public string RelatedTo_Subject { get; set; } = null!;

        [DataObjectField(false, false, true)]
        [DisplayName("Notes")]
        public string? Notes { get; set; }

        [DataObjectField(false, false, true)]
        public string? UpdatedBy { get; set; }

        [DataObjectField(false, false, true)]
        public DateTime? UpdateDate { get; set; }


    }
}