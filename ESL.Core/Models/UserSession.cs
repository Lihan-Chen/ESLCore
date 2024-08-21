using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESL.Core.Models
{
    public partial record UserSession
    {
        public UserSession()
        {
            
        }
        public string SessionID;

        public string userID;

        public string userName;

        public int shiftNo;

        public string shiftName;

        public string operatorType;

        public bool isAdmin;

        public bool isSuperAdmin;

        public int facilNo;

        public string facilName;

        public bool userLoggedIn;


        //public string SessionID { get; set; } = null!;

        //public string UserID { get; set; } = null!;

        //public string UserRole { get; set; } = null!;

        //public string UserName { get; set; } = null!;

        //public DateTimeOffset SessionStartsAt { get; set; } = DateTimeOffset.Now;

        //public TimeSpan TimeToLive { get; set; } = TimeSpan.FromHours(12);

        //public bool IsAuthenticated { get; set; } = false;




    }
}
