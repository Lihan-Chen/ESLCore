using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace ESL.Core.Models.BusinessEntities.ValueObjects
{
    [ComplexType]
    public class BaseEventID // :BaseUpdate   
    {     
        ///// <summary>
        ///// Gets or sets the facilNo of the Facility.
        ///// </summary>
        //[DataObjectField(true, true, false, 2)]
        //[Display(Name = "Facil. No.")]
        //public int FacilNo { get; set; }
        ///// <summary>
        ///// Gets or sets the logTypeNo of the Log Type.
        ///// </summary>
        //[DataObjectField(true, true, false, 2)]
        //[Display(Name = "Log Type No.")]
        //public int LogTypeNo { get; set; }

        ///// <summary>
        ///// Gets or sets the eventID of the Event.
        ///// </summary>
        //[DataObjectField(true, true, false, 20)]
        //[Display(Name = "Event ID")]
        //public string EventID { get; set; } = null!;
        ///// <summary>
        ///// Gets or sets the eventID_RevNo of the Event.
        ///// </summary>
        //[DataObjectField(true, true, false, 2)]
        //[Display(Name = "Revision No.")]
        //public int EventID_RevNo { get; set; }

        public virtual Facility Facility { get; set; } = new Facility();

        public virtual LogType LogType { get; set; } = new LogType();

    }
}
