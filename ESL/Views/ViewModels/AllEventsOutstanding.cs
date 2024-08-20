using ESL.Core.Models;
using X.PagedList;
namespace ESL.Web.Views.ViewModels
{
    public class AllEventsOutstanding
    {
        public _LogFilterPartialViewModel logFilterPartial { get; set; }
        public IPagedList<AllEvent> AllEventsPagedList { get; set; } = null!;
        public int count { get; set; }
        //public AllEventDetails AllEventDetails { get; set; }
        //public RealTime realtime { get; set; }
        public UserSession UserSession { get; set; } = new UserSession();
    }
}
