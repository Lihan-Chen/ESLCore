using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using ESL.Core.Models.Validation;
using ESL.Core.Models.ComplexTypes;

namespace ESL.Core.Models
{

    [PrimaryKey(nameof(FacilNo),nameof(LogTypeNo),nameof(EventID),nameof(RelatedTo_Subject))]    
    [Table("ESL_RelatedTo")]
        public partial record RelatedTo
    {
        [DataObjectField(true, true, false, 2)]
        [DisplayName("Facility No.")]
        public int FacilNo { get; set; }

        [DataObjectField(true, true, false, 2)]
        [DisplayName("Log Type No.")]
        public int LogTypeNo { get; set; }

        //CONSTANTNAME  VARCHAR2(20 BYTE)
        [DataObjectField(true, true, false, 20)]
        public string EventID { get; set; } = null!;

        [DataObjectField(true, true, false, 120)]
        public string RelatedTo_Subject { get; set; } = null!;

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


    }
}