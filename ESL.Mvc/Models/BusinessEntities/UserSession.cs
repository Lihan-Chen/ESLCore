using ESL.Core.Models.Enums;

namespace ESL.Mvc.Models.BusinessEntities
{
    public record UserSession
    {
        //u0xxxx
        public required string UserID;

        // User FullName
        public string UserName = string.Empty;

        // 1, 2
        public int ShiftNo;

        public Shift Shift => ShiftNo == 1 ? Shift.Day : Shift.Night;

        public string OpType;

        public OperatorType OperatorType => OpType == "Primary" ? OperatorType.Primary : OperatorType.Secondary;

        public bool IsAdmin;

        public bool IsSuperAdmin;

        public int FacilNo;

        public string FacilName = string.Empty;

        public bool UserLoggedIn;
    }
}
