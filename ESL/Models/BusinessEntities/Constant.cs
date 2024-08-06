using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using PocketBook.Models.Collections;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations.Schema;

namespace PocketBook.Models
{
    [PrimaryKey(nameof(FacilNo), nameof(ConstantName), nameof(StartDate))]
    [Table("ESL_Constants")]
    public class Constant
    {

        [DataObjectField(true, true, false, 2)]
        [DisplayName("Facility No.")]
        [Column(nameof(FacilNo))]
        public int FacilNo { get; set; }

        [DataObjectField(true, true, false, 20)]
        [DisplayName("Constant")]
        [Column(nameof(ConstantName))]
        public string ConstantName { get; set; } = string.Empty;

        [DataObjectField(true, true, false)]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name = "Start")]
        [Column(nameof(StartDate))]
        public DateTime StartDate { get; set; }
        
        //ENDDATE       DATE
        [DataObjectField(false, false, true)]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name = "End")]
        [Column(nameof(EndDate))]
        public DateTime? EndDate { get; set; }

        [DataObjectField(false, false, true)]
        [DisplayName("Value")]
        [Column(nameof(Value))]
        public int? Value { get; set; }

        [DataObjectField(false, false, true, 400)]
        [DisplayName("Comment")]
        [Column(nameof(Notes))]
        public string? Notes { get; set; }

        [DataObjectField(false, false, true, 60)]
        [DisplayName("Updated By")]
        [Column(nameof(UpdatedBy))]
        public string? UpdatedBy { get; set; } 

        [DataObjectField(false, false, true)]
        [DisplayName("Update Date")]
        public DateTime? UpdateDate { get; set; }
    }
}