using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System;

namespace ESL.Models.BusinessEntities.ValueObjects
{
    public class BaseUpdate // : BaseOperator
    {
        /// <summary>
        /// Gets or sets the modifyFlag of the FlowChange.
        /// </summary>
        [DataObjectField(false, false, true, 100)]
        [Display(Name = "Modify Flag")]
        public string? ModifyFlag { get; set; }

        /// <summary>
        /// Gets or sets the modifiedBy of the FlowChange.
        /// </summary>
        [DataObjectField(false, false, true, 7)]
        [Display(Name = "Modified By")]
        public int? ModifiedBy { get; set; }

        /// <summary>
        /// Gets or sets the modifyDate of the FlowChange.
        /// </summary>
        [DataObjectField(false, false, true)]
        [Display(Name = "Date Modified")]
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
        [Display(Name = "Updated By")]
        public string UpdatedBy { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the updateDate of the FlowChange.
        /// </summary>
        [DataObjectField(false, false, false)]
        public DateTimeOffset UpdateDate { get; set; }
    }
}
