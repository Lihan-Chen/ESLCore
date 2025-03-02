using ESL.Core.Models.BusinessEntities;
using X.PagedList;

namespace ESL.Mvc.ViewModels
{
    public record class AllEventOutstandingViewModel
    {
        public LogFilterPartialViewModel LogFilterPartial { get; set; } = new LogFilterPartialViewModel();
        public IPagedList<AllEvent> AllEventsPagedList { get; set; } = new PagedList<AllEvent>(new List<AllEvent>(), 1, 20);
        public int count { get; set; }
        public AllEventDetails AllEventDetails { get; set; } = new AllEventDetails();
        public RealTime realtime { get; set; } = new RealTime();
        public UserSession UserSession { get; set; } = new UserSession();

        // public AllEvents allEventList { get; set; }
        //public IEnumberable<AllEvent> allEventList { get; set; }
    }
}
