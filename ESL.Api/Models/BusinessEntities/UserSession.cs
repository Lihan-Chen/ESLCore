using System.ComponentModel.DataAnnotations.Schema;

namespace ESL.Api.Models.BusinessEntities
{
    //[PrimaryKey(nameof(SessionID))]
    //[Index("UserID", AllDescending = false, IsUnique = false, Name = "UserID")]
    
    public partial record UserSession
    {
        public Guid SessionID { get; set; }
      
        public string? UserID { get; set; }

        public DateTimeOffset SessionStart { get; set; } = DateTimeOffset.Now;

        public bool IsAuthenticated { get; set; } = false;

        public string[] UserRole { get; set; } = null!;
         
        public int? ShiftNo { get; set; } //= System.Web.HttpContext.Current.Session["ShiftNo"].ToString();

        // primary or secondary
        public string? OperatorType { get; set; }

        public int FacilNo { get; set; } = 1;       

        public DateTimeOffset? SessionEnd { get; set; }

        public Guid LastSessionID { get; set; }

        [ForeignKey("UserId")]
        public Employee User { get; set; } = null!;
    }
}
