using System.ComponentModel;
using ESL.Core.Models.BusinessEntities;

namespace ESL.Core.Models.ComplexTypes
{
    public partial record EventOperator : Employee
    {
        ///// <summary>
        ///// Gets or sets the OperatorID of the FlowChange.
        ///// </summary>
        //[DataObjectField(false, false, false, 7)]
        //[DisplayName("Operator")]
        //[Required(ErrorMessage = "Need to select a name from pull-down list.  Please try again.")]
        //public int OperatorID { get; set; }

        /// <summary>
        /// Gets or sets the OperatorType of the FlowChange.
        /// </summary>
        [DataObjectField(false, false, true, 15)]
        [DisplayName("Operator Type (Optional)")]
        public string? OperatorType { get; set; }

        /// <summary>
        /// Gets or sets the ShiftNo of the FlowChange.
        /// </summary>
        [DataObjectField(false, false, true, 2)]
        [DisplayName("Shift No")]
        public int? ShiftNo { get; set; }

        public virtual Employee Operator { get; set; } = new Employee();

    }
}
