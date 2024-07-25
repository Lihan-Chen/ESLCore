using System.ComponentModel;

namespace ESL.Models.BusinessEntities
{
    public class LogType: IEntity
    {
        /// <summary>
        /// Gets or sets the logTypeNo of the LogTypes.
        /// </summary>
        [DataObjectFieldAttribute(true, true, false, 2)]
        [DisplayName("Log Type No.")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the logTypeName of the LogTypes.
        /// </summary>
        [DataObjectFieldAttribute(false, true, false, 100)]
        [DisplayName("Log Type Name")]
        public string LogTypeName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the Notes [VARCHAR2(400)] of the Employee.
        /// </summary>
        [DataObjectFieldAttribute(false, false, true, 400)]
        [DisplayName("Notes")]
        public string? Notes { get; set; }

    }
}
