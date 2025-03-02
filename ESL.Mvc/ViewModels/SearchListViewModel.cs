using ESL.Core.Models.BusinessEntities;
using Microsoft.Graph.SecurityNamespace;
using X.PagedList;

namespace ESL.Mvc.ViewModels
{
    public class SearchListViewModel
    {
        public SearchFilterPartialViewModel SearchFilterPartial { get; set; }
        public IPagedList<SearchDTO> SearchPagedList { get; set; } = new PagedList<SearchDTO>(new SearchDTO[] { }, 1, 1);
        public int count { get; set; }
        public IEnumerable<SearchDTO> SearchResultList { get; set; } = Enumerable.Empty<SearchDTO>();

        //public AllEventDetails AllEventDetails { get; set; }

        // includes _LogFilterPartialViewModel

        //[Display(Name = "Facility")]
        //public int? FacilNo { get; set; }

        //[Display(Name = "Log Type")]
        //public int? LogTypeNo { get; set; }

        //[DataType(DataType.Date)]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        //[Display(Name = "Start Date")]
        //public DateTime? StartDate { get; set; }

        //[DataType(DataType.Date)]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        //[Display(Name = "End Date")]
        //public DateTime? EndDate { get; set; }

        //[Display(Name = "Primary Operator?")]
        //public Boolean OperatorType { get; set; }

        //[Display(Name = "Option: AND or OR")]
        //public String OptionAll { get; set; }

        //[Display(Name = "Search Key Word(s)")]
        //[RegularExpression("([a-zA-Z0-9_]+)", ErrorMessage = "Enter only alphabets and numbers of First Name")]  //[a-zA-Z0-9_] or "\w"
        //public String SearchKeyWords { get; set; }

        //// public SelectList facilNos { get; set; }
        //public SelectList logTypeNos { get; set; }

        //[Display(Name = "Search Option: OR : AND")]
        //public IEnumerable<SelectListItem> optionAllType { get; set; }

        //public int? Count { get; set; }

        //public IEnumerable<Search> searchList { get; set; }
    }
}
