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
    [PrimaryKey(nameof(ClearanceTypeNo))]
    [Table("ESL_ClearanceTypes")]
    public class ClearanceType
    {
        [DataObjectField(true, true, false, 2)]
        public int ClearanceTypeNo { get; set; }

        [DataObjectField(false, true, false, 40)]
        public string ClearanceTypeName { get; set; } = null!;

        [DataObjectField(false, true, false, 5)]
        public string ClearanceTypeAbbr { get; set; } = null!;

        [DataObjectField(false, false, true, 2)]
        public int SortNo { get; set; }

        [DataObjectField(false, false, true, 400)]
        [DisplayName("Notes")]
        public string? Notes { get; set; }

        [DataObjectField(false, false, true, 60)]
        public string? UpdatedBy { get; set; }

        [DataObjectField(false, false, true)]
        public DateTime? UpdateDate { get; set; }
    }
}