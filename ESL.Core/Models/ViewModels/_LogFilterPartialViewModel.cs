using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESL.Core.Models.ViewModels
{
    public partial class _LogFilterPartialViewModel
    {
        [Required]
        [Display(Name = "Facility")]
        public int? FacilNo { get; set; }

        [Display(Name = "Log Type")]
        public int? LogTypeNo { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name = "Start Date")]
        public DateTime? StartDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name = "End Date")]
        public DateTime? EndDate { get; set; }

        [Display(Name = "Primary Operator?")]
        public Boolean OperatorType { get; set; }

        [Display(Name = "Keyword")]
        [RegularExpression("([a-zA-Z0-9_]+)", ErrorMessage = "Enter only alphabets and numbers of Keywords")]  //[a-zA-Z0-9_] or "\w"
        public string CurrentFilter { get; set; }

        public required SelectList FacilNos { get; set; }

        public required SelectList LogTypeNos { get; set; } 

    }
}
