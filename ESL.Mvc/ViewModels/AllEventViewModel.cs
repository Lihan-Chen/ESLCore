using ESL.Core.Models.BusinessEntities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using X.PagedList;

namespace ESL.Mvc.ViewModels
{
    public record AllEventsViewModel
    {
        // includes _LogFilterPartialViewModel

        [Display(Name = "Facility")]
        public int? FacilNo { get; set; }

        [Display(Name = "Log Type")]
        public int? LogTypeNo { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "Start Date")]
        public DateOnly? StartDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "End Date")]
        public DateOnly? EndDate { get; set; }

        [Display(Name = "Primary? Check for Yes.")]
        public Boolean OperatorType { get; set; }

        public SelectList FacilNos { get; set; } = new SelectList(new List<SelectListItem>());
        public SelectList LogTypeNos { get; set; } = new SelectList(new List<SelectListItem>());

        public int Count { get; set; }

        public List<AllEvent> AllEventList { get; set; }

        public IPagedList<AllEvent> AllEventsPagedList { get; set; } = new PagedList<AllEvent>(new List<AllEvent>(), 1, 40);

        public AllEventDetails AllEventDetails { get; set; } = new AllEventDetails();
    }
}
