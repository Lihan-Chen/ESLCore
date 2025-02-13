using ESL.Core.Models.BusinessEntities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using X.PagedList;

namespace ESL.Mvc.ViewModels
{
    public class AllEventsViewModel
    {
        // includes _LogFilterPartialViewModel

        [Display(Name = "Facility")]
        public int FacilNo { get; set; }

        [Display(Name = "Log Type")]
        public int LogTypeNo { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Primary? Check for Yes.")]
        public Boolean OperatorType { get; set; }

        public SelectList facilNos { get; set; }
        public SelectList logTypeNos { get; set; }

        public int Count { get; set; }

        public List<AllEvent> AllEventList { get; set; }

        public IPagedList<AllEvent> AllEventsPagedList { get; set; }

        public AllEventDetails AllEventDetails { get; set; }
    }
}
