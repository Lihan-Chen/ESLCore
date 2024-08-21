using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ESL.Web.Models.BusinessEntities.ValueObjects
{
    public class BaseOperator: Employee
    {
        ///// <summary>
        ///// Gets or sets the operatorID of the FlowChange.
        ///// </summary>
        //[DataObjectField(false, false, false, 7)]
        //[DisplayName("Operator")]
        //[Required(ErrorMessage = "Need to select a name from pull-down list.  Please try again.")]
        //public int OperatorID { get; set; }

        /// <summary>
        /// Gets or sets the operatorType of the FlowChange.
        /// </summary>
        [DataObjectField(false, false, true, 15)]
        [DisplayName("Operator Type (Optional)")]
        public string OperatorType { get; set; } = null!;

        /// <summary>
        /// Gets or sets the shiftNo of the FlowChange.
        /// </summary>
        [DataObjectField(false, false, true, 2)]
        [DisplayName("Shift No")]
        public int? ShiftNo { get; set; }

        public virtual Employee Operator { get; set; } = new Employee();

    }
}
