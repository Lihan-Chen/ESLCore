namespace ESL.Mvc.Models.BusinessEntities
{
    public record UserSession
    {
        //u0xxxx
        public string UserID;

        // User FullName
        public string UserName = string.Empty;

        // 1, 2
        public int ShiftNo;

        public string ShiftName => ShiftNo == 1 ? "Day" : ShiftNo == 2 ? "Night" : string.Empty;

        public string OperatorType = string.Empty;

        public bool IsAdmin;

        public bool IsSuperAdmin;

        public int FacilNo;

        public string FacilName = string.Empty;

        public bool UserLoggedIn;
    }
}
