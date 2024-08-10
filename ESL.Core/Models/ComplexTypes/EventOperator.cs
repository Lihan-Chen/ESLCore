using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESL.Core.Models.ComplexTypes
{
    [ComplexType]
    public partial record EventOperator : Employee
    {
        ///// <summary>
        ///// Gets or sets the operatorID of the FlowChange.
        ///// </summary>
        //[DataObjectField(false, false, false, 7)]
        //[Display(Name = "Operator")]
        //[Required(ErrorMessage = "Need to select a name from pull-down list.  Please try again.")]
        //public int OperatorID { get; set; }

        /// <summary>
        /// Gets or sets the operatorType of the FlowChange.
        /// </summary>
        [DataObjectField(false, false, true, 15)]
        [Display(Name = "Operator Type (Optional)")]
        public string? OperatorType { get; set; }

        /// <summary>
        /// Gets or sets the shiftNo of the FlowChange.
        /// </summary>
        [DataObjectField(false, false, true, 2)]
        [Display(Name = "Shift No")]
        public int? ShiftNo { get; set; }

        public virtual Employee Operator { get; set; } = new Employee();

    }
}
