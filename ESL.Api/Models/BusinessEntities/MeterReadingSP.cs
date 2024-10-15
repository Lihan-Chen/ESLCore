using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ESL.Api.Models.BusinessEntities
{
    public partial record MeterReadingSP
    {
        /// <summary>
        /// Gets or sets the MeterID of the FlowChange.
        /// </summary>
        [DataObjectField(false, false, false, 30)]
        [Required(ErrorMessage = "Meter ID is missing.  Please select fromt the pull-down.")]
        [DisplayName("Meter ID")]
        [Column("METERID", TypeName = "VARCHAR2")]
        public string MeterID { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the NewValue of the FlowChange.
        /// </summary>
        [DataObjectField(false, false, true, 10)]
        //[Required(ErrorMessage = "New Value must be equal to the sum of Old and Change Values.")]  // ^[+]?([.]\d+|\d+([.]\d+)?)$
        [DisplayName("New Flow")]
        [RegularExpression(@"[0-9]*\.?[0-9]+", ErrorMessage = "New value must be a valid positive number in digital format.")]  // "@^(?:[1-9][0-9]*|0)$@"
        [Range(typeof(Decimal), "0", "9999", ErrorMessage = "Value must be a decimal/number between {1} and {2}.")]
        [Column("NEWVALUE", TypeName = "NUMBER")]
        public int? NewValue { get; set; }

        /// <summary>
        /// Gets or sets the unit of the FlowChange.
        /// </summary>
        [DataObjectField(false, false, true, 10)]
        //[Required(ErrorMessage = "All unit must be consistent.")]
        [DisplayName("New Unit")]
        [Column("UNIT", TypeName = "VARCHAR2")]
        public string? Unit { get; set; }

        /// <summary>
        /// Gets or sets the EventDate of the FlowChange.
        /// </summary>
        [DataObjectField(false, false, false)]
        [DisplayName("Effective Date")]
        [Required(ErrorMessage = "Event Date is Required.")]
        //[UIHint("Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Column("EVENTDATE", TypeName = "DATE")]
        public DateTime EventDate { get; set; }

        /// <summary>
        /// Gets or sets the EventTime of the FlowChange.
        /// </summary>
        [DataObjectField(false, false, false, 5)]
        [Display(Name = "Effective Time", Prompt = "hh:mm")]
        [RegularExpression("([01]?[0-9]|2[0-3]):[0-5][0-9]", ErrorMessage = "Time must be a valid 24 hour time in HH:MM format")]
        //[RegularExpression("^2[0-3]|[01][0-9]:[0-5][0-9]$")]  // "([01]?[0-9]|2[0-3]):[0-5][0-9]"
        //[RegularExpression("^([0-1]?\d|2[0-3]):([0-5]\d)$")]
        [Column("EVENTTIME", TypeName = "VARCHAR2")]
        public string EventTime { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the UpdateDate of the record.
        /// </summary>
        [DataObjectField(false, false, true)]
        [DisplayName("Updated on")]
        [Column("UPDATEDATE", TypeName = "DATE")]
        public DateTime? UpdateDate { get; set; }

        /// <summary>
        /// Gets or sets the EventID_RevNo of the Event.
        /// </summary>
        [DataObjectField(true, true, false, 2)]
        [DisplayName("Revision No.")]
        [Column("EVENTID_REVNO", TypeName = "NUMBER")]
        public int EventID_RevNo { get; set; }
    }
}
