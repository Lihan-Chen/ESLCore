using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ESL.Core.Models.ComplexTypes
{
    [ComplexType]
    public record EventUpdate
    {
        // public EventOperator EventOperator { get; set; } = new EventOperator();
        
        /// <summary>
        /// Gets or sets the modifyFlag of the FlowChange.
        /// </summary>
        [DataObjectField(false, false, true, 100)]
        [DisplayName("Modify Flag")]
        public string? ModifyFlag { get; set; }

        /// <summary>
        /// Gets or sets the modifiedBy of the FlowChange.
        /// </summary>
        [DataObjectField(false, false, true, 7)]
        [DisplayName("Modified By")]
        public int? ModifiedBy { get; set; }

        /// <summary>
        /// Gets or sets the modifyDate of the FlowChange.
        /// </summary>
        [DataObjectField(false, false, true)]
        [DisplayName("Date Modified")]
        public DateTimeOffset? ModifiedDate { get; set; }

        public Update Update { get; set; } = new Update();

        ///// <summary>
        ///// Gets or sets the Notes [VARCHAR2(400)] of the Employee.
        ///// </summary>
        //[DataObjectField(false, false, true, 400)]
        //[DisplayName("Notes")]
        //public string? Notes { get; set; }

    }
}
