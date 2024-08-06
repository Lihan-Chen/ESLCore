using System;
using System.ComponentModel;
using System.Diagnostics;
using PocketBook.Models.Validation;

namespace PocketBook.Models
{
    public class Search_RelatedToDTO
    {
        [DisplayName("Facility No.")]
        public int FacilNo { get; set; }

        [DisplayName("Facility")]
        public string FacilName { get; set; } = string.Empty;

        [DisplayName("Log Type No.")]
        public int LogTypeNo { get; set; }

        [DisplayName("Log Type")]
        public string LogTypeName { get; set; } = string.Empty;

        [DisplayName("Event")]
        public string EventID { get; set; } = string.Empty;

        [DisplayName("Event Date")]
        public DateTime EventDate { get; set; }

        [DisplayName("Event Time")]
        public string EventTime { get; set; } = string.Empty;

        [DisplayName("Subject")]
        public string Subject { get; set; } = string.Empty;

        [DisplayName("Details")]
        public string Details { get; set; } = string.Empty;

        [DisplayName("Operator Type")]
        public string OperatorType { get; set; } = string.Empty;

        [DisplayName("Updated By")]
        public string? UpdatedBy { get; set; }

        [DisplayName("Updated On")]
        public string? UpdateDate { get; set; }

        [DisplayName("ClearanceID")]
        public string? ClearanceID { get; set; }
    }
}