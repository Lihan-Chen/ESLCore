using ESL.Core.Models.BusinessEntities;
using ESL.Core.Models.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESL.Core.Models.ViewModels
{
    internal class AccountModels
    {

    }


    public class UserSessionViewModel
    {
        [Required]
        [Display(Name = "User ID")]
        public string UserID { get; set; }

        [Required]
        //[DataType(DataType.Password)]
        [Display(Name = "Plant")]
        public string Plant { get; set; }

        [Required]
        [Display(Name = "Operator Type")]
        public OperatorType OpType { get; set; }

        [Required]
        [Display(Name = "Shift: Day/Night")]
        public Shift Shft { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }

        public IEnumerable<SelectListItem> optionOpType { get; set; }

        public IEnumerable<SelectListItem> optionShift { get; set; }

        // Consider using ViewComponent or PlantService
        // public SelectList Plants { get; set; }
    }
}