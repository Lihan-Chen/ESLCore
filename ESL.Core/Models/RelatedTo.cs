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
        [DataObjectFieldAttribute(true, true, false)]
        [DisplayName("Facility No.")]
        public int FacilNo { get; set; }

        [DataObjectFieldAttribute(true, true, false)]
        [DisplayName("Log Type No.")]
        public int LogTypeNo { get; set; }

        //CONSTANTNAME  VARCHAR2(20 BYTE)
        [DataObjectFieldAttribute(true, true, false)]
        public string EventID { get; set; } = null!;

        [DataObjectFieldAttribute(true, true, false)]
        public string RelatedTo_Subject { get; set; } = null!;

        [DataObjectFieldAttribute(false, false, true)]
        [DisplayName("Notes")]
        public string? Notes { get; set; }

        public Update Update { get; set; } = new Update();


    }
}