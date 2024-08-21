using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System;

namespace ESL.Web.Models.BusinessEntities.ValueObjects
{
    public class BaseUpdate // : BaseOperator
    {
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

        /// <summary>
        /// Gets or sets the Notes [VARCHAR2(400)] of the Employee.
        /// </summary>
        [DataObjectField(false, false, true, 400)]
        [DisplayName("Notes")]
        public string? Notes { get; set; }

        /// <summary>
        /// Gets or sets the updatedBy of the FlowChange.
        /// </summary>
        [DataObjectField(false, false, false, 60)]
        [DisplayName("Updated By")]
        public string UpdatedBy { get; set; } = null!;

        /// <summary>
        /// Gets or sets the updateDate of the FlowChange.
        /// </summary>
        [DataObjectField(false, false, false)]
        public DateTimeOffset UpdateDate { get; set; }
    }
}
