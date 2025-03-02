using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESL.Core.Models.BusinessEntities
{
    public record RealTime
    {
        #region Public Properties

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
        public string EventID { get; set; }

        /// <summary>
        /// Gets or sets the eventID_RevNo of the AllEvents.
        /// </summary>
        [DataObjectField(true, true, false, 2)]
        public int EventID_RevNo { get; set; }

        /// <summary>
        /// Gets or sets the eventDate of the AllEvents.
        /// </summary>
        [DataObjectField(false, false, false)]
        public DateTime EventDateTime { get; set; }

        /// <summary>
        /// Gets or sets the subject of the AllEvents.
        /// </summary>
        [DataObjectField(false, false, false, 300)]
        public string Subject { get; set; } = string.Empty;

        #endregion
    }
}
