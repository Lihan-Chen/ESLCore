using System.ComponentModel;

namespace ESL.Web.Models.BusinessEntities
{
    public class ScanDoc
    {
        /// <summary>
        /// Gets or sets the Facility No [NUMBER(3)] of the Facility.
        /// [DataObjectField(key, identity, isNullable]
        /// </summary>
        [DataObjectField(true, true, false)]
        [DisplayName("Facility No.")]
        public int FacilNo { get; set; }

        [DataObjectField(true, true, false)]
        public int LogTypeNo { get; set; }

        [DataObjectField(true, true, false)]
        public string EventID { get; set; }

        [DataObjectField(true, true, false)]
        [DisplayName("Scanned Document No.")]
        public int? ScanNo { get; set; }

        [DataObjectField(false, false, false)]
        [DisplayName("Scan File Name")]
        public string ScanFileName { get; set; } = null!;

        [DataObjectField(false, false, true)]
        [DisplayName("Notes")]
        public string Notes { get; set; }

        [DataObjectField(false, false, true)]
        [DisplayName("Updated By")]
        public string UpdatedBy { get; set; } = null!;

        [DataObjectField(false, false, true)]
        [DisplayName("Update Date")]
        public DateTime? UpdateDate { get; set; }

        //public ICollection<AllEvent> allEvents { get; set; } = new List<AllEvent>();
    }
}
