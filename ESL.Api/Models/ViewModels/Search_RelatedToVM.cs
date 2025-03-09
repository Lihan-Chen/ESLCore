using System.ComponentModel;

namespace ESL.Api.Models.ViewModels
{
    public record Search_RelatedToVM
    {
        [DisplayName("Facility No.")]
        public int FacilNo { get; set; }

        [DisplayName("Facility")]
        public string FacilName { get; set; }

        [DisplayName("Log Type No.")]
        public int LogTypeNo { get; set; }

        [DisplayName("Log Type")]
        public string LogTypeName { get; set; }

        [DisplayName("Event")]
        public string EventID { get; set; }

        [DisplayName("Event Date")]
        public DateTime EventDate { get; set; }

        [DisplayName("Event Time")]
        public string EventTime { get; set; }

        [DisplayName("Subject")]
        public string Subject { get; set; }

        [DisplayName("Details")]
        public string Details { get; set; }

        [DisplayName("Operator Type")]
        public string OperatorType { get; set; }

        [DisplayName("Updated By")]
        public string UpdatedBy { get; set; }

        [DisplayName("Updated On")]
        public string UpdateDate { get; set; }

        [DisplayName("ClearanceID")]
        public string ClearanceID { get; set; }
    }
}
