using System;
using System.ComponentModel;
using System.Diagnostics;
using ESL.Core.Models.Validation;

namespace ESL.Core.Models
{
    public class Search_RelatedToDTO
    {
        [DisplayName("Facility No.")]
        public int FacilNo { get; set; }

        [DisplayName("Facility")]
        public string FacilName { get; set; } = null!;

        [DisplayName("Log Type No.")]
        public int LogTypeNo { get; set; }

        [DisplayName("Log Type")]
        public string LogTypeName { get; set; } = null!;

        [DisplayName("Event")]
        public string EventID { get; set; } = null!;

        [DisplayName("Event Date")]
        public DateTime EventDate { get; set; }

        [DisplayName("Event Time")]
        public string EventTime { get; set; } = null!;

        [DisplayName("Subject")]
        public string Subject { get; set; } = null!;

        [DisplayName("Details")]
        public string Details { get; set; } = null!;

        [DisplayName("Operator Type")]
        public string OperatorType { get; set; } = null!;

        [DisplayName("Updated By")]
        public string? UpdatedBy { get; set; }

        [DisplayName("Updated On")]
        public string? UpdateDate { get; set; }

        [DisplayName("ClearanceID")]
        public string? ClearanceID { get; set; }
    }
}