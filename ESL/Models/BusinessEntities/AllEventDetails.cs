using System.ComponentModel;

namespace ESL.API.Models.BusinessEntities
{
    public class AllEventDetails
    {
        /// <summary>
        /// Gets or sets the facilName of the AllEvents.
        /// </summary>
        [DataObjectField(true, true, false, 2)]
        public int FacilNo { get; set; }

        /// <summary>
        /// Gets or sets the logTypeNo of the AllEvents.
        /// </summary>
        [DataObjectField(true, true, false, 2)]
        public int LogTypeNo { get; set; }

        /// <summary>
        /// Gets or sets the eventID of the AllEvents.
        /// </summary>
        [DataObjectField(true, true, false, 20)]
        public string EventID { get; set; } =null!;

        /// <summary>
        /// Gets or sets the eventID_RevNo of the AllEvents.
        /// </summary>
        [DataObjectField(true, true, false, 2)]
        public int EventID_RevNo { get; set; }

        /// <summary>
        /// Gets or sets the eventHighlight of the AllEvents.
        /// </summary>
        [DataObjectField(false, false, false, 400)]
        public string EventHighlight { get; set; } = null!;

        /// <summary>
        /// Gets or sets the eventHighlight of the AllEvents.
        /// </summary>
        [DataObjectField(false, false, false, 400)]
        public string EventTrail { get; set; } = null!;

        public virtual AllEvent AllEvent { get; set; } = new AllEvent();
    }
}
