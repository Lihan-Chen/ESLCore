using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;
using System.Xml.Linq;

namespace ESL.Api.Models.BusinessEntities
{
    //[PrimaryKey(nameof(SessionID))]
    //[Index("UserID", AllDescending = false, IsUnique = false, Name = "UserID")]
    
    [Keyless]
    public partial record UserSession
    {
        public Guid SessionID { get; set; }

        public string? UserName { get; set; }

        public string? UserID { get; set; }

        public bool IsAuthenticated { get; set; } = false;

        public string[] UserRole { get; set; } = null!;
         
        public int? ShiftNo { get; set; } //= System.Web.HttpContext.Current.Session["ShiftNo"].ToString();

        public string? OperatorType { get; set; }

        public int FacilNo { get; set; } = 1;

        public DateTimeOffset SessionStart { get; set; } = DateTimeOffset.Now;

        public DateTimeOffset? SessionEnd { get; set; }
    }
}
