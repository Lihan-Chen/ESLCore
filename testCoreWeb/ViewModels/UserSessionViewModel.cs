namespace testCoreWeb.ViewModels
{
    public record UserSessionViewModel
    {
        public string SessionID { get; set; } = new Guid().ToString();

        public DateTimeOffset DateTimeOffset { get; set; } = DateTimeOffset.UtcNow;

        public string UserID { get; set; } = string.Empty;

        public string UserName { get; set; } = string.Empty;
        
        public int?  FacilNo {  get; set; }

        public string? FacilName { get; set; }

        public RoleEnum UserRole { get; set; } = RoleEnum.None;

        public ShiftEnum Shift { get; set; } = ShiftEnum.Day;

        public OperatorTypeEnum OperatorType {  get; set; } = OperatorTypeEnum.Primary;

        public string? UserIP { get; set; }

        public string? UserAgent { get; set; }

        public string? LastSessionID { get; set; }
    }
}
