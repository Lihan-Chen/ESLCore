namespace ESL.Api.Models.BusinessEntities
{
    public record Announcement
    {
        public Guid ID { get; set; }

        public string Subject { get; set;}  = string.Empty;

        public string Details { get; set;} = string.Empty;
        public string[] RelatedApplications {  get; set; } = [];

        // Facility, App, or District Level
        public string Scope { get; set; } = string.Empty;

        // ImpactLevel corresponds to the color code (alert, information, etc.)
        public int? ImpactLevel {  get; set; }

        public DateRange? EffectiveDateRange { get; set; }

        public Employee AnnouncedBy { get; set; } = null!;

        public Employee UpdatedBy { get; set; } = null!;

        public DateTime UpdatedDate { get; set; }

    }
}
