using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace ESL.Core.Models.BusinessEntities.ValueObjects
{
    [ComplexType]
    public class BaseEventID // :BaseUpdate   
    {     
        ///// <summary>
        ///// Gets or sets the FacilNo of the Facility.
        ///// </summary>
        //[DataObjectField(true, true, false, 2)]
        //[DisplayName("Facil. No.")]
        //public int FacilNo { get; set; }
        ///// <summary>
        ///// Gets or sets the LogTypeNo of the Log Type.
        ///// </summary>
        //[DataObjectField(true, true, false, 2)]
        //[DisplayName("Log Type No.")]
        //public int LogTypeNo { get; set; }

        ///// <summary>
        ///// Gets or sets the EventID of the Event.
        ///// </summary>
        //[DataObjectField(true, true, false, 20)]
        //[DisplayName("Event ID")]
        //public string EventID { get; set; } = null!;
        ///// <summary>
        ///// Gets or sets the EventID_RevNo of the Event.
        ///// </summary>
        //[DataObjectField(true, true, false, 2)]
        //[DisplayName("Revision No.")]
        //public int EventID_RevNo { get; set; }

        public virtual Facility Facility { get; set; } = new Facility();

        public virtual LogType LogType { get; set; } = new LogType();

    }
}
