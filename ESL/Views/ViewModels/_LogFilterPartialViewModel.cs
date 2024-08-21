using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ESL.Web.Views.ViewModels
{
    public partial class _LogFilterPartialViewModel
    {

        [Required]
        [DisplayName("Facility")]
        public int? FacilNo { get; set; }

        [DisplayName("Log Type")]
        public int? LogTypeNo { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [DisplayName("Start Date")]
        public DateTime? StartDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [DisplayName("End Date")]
        public DateTime? EndDate { get; set; }

        [DisplayName("Primary Operator?")]
        public Boolean OperatorType { get; set; }

        [DisplayName("Keyword")]
        [RegularExpression("([a-zA-Z0-9_]+)", ErrorMessage = "Enter only alphabets and numbers of Keywords")]  //[a-zA-Z0-9_] or "\w"
        public string CurrentFilter { get; set; }

        public SelectList FacilNos { get; set; } = null!;
        public SelectList LogTypeNos { get; set; } = null!;

    }
}
