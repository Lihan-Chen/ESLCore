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
    public class Subj
    {
        [DataObjectField(true, true, false, 2)]
        [DisplayName("Facility No.")]
        public int FacilNo { get; set; }

        [DataObjectField(true, true, false, 3)]
        public int SubjectNo { get; set; }

        [DataObjectField(false, true, false, 100)]
        public string SubjectName { get; set; } = null!;

        [DataObjectField(false, false, false, 5)]
        public string FacilType { get; set; } = null!;
    }
}