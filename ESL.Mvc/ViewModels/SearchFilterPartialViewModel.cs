﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace ESL.Mvc.ViewModels
{
    public class SearchFilterPartialViewModel
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

        [Display(Name = "AND or OR")]
        public string? OptionAll { get; set; }

        [Display(Name = "Search Key Word(s)")]
        public string? SearchValues { get; set; }

        public SelectList FacilNoSelectList { get; set; }
        public SelectList LogTypeNoSelectList { get; set; }
        //public SelectList optionAllTypes { get; set; }

        [Display(Name = "Search Option: OR : AND")]
        public IEnumerable<SelectListItem> OptionAllTypes { get; set; }
    }
}
