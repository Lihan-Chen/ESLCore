﻿using ESL.Core.Models.BusinessEntities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace ESL.Core.Models
{
    [DebuggerDisplay("AllEvent: {FacilName, nq} {LogTypeName, nq} {EventID, nq} - {EventID_RevNo, nq})")] // ({Type, nq})
    
    public record BaseEventID : BaseEntity<object>
    {
        #region Private Variables

        // constants have all being moved into the constants namespace and decorated as public static readonly 
        private static string _CrLf = "<br />"; // System.Environment.NewLine;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the FacilNo of the Facility.
        /// </summary>
        [ForeignKey("Facility")]
        public int FacilNo { get; set; }
        /// <summary>
        /// Gets or sets the LogTypeNo of the Log Type.
        /// </summary>
        [ForeignKey("LogType")]
        public int LogTypeNo { get; set; }

        /// <summary>
        /// Gets or sets the EventID of the Event.
        /// </summary>
        public string EventID { get; set; } = null!;
        /// <summary>
        /// Gets or sets the EventID_RevNo of the Event.
        /// </summary>
        public int EventID_RevNo { get; set; }

        public override object[] GetKeys()
        {
            return new object[] { FacilNo, LogTypeNo, EventID, EventID_RevNo };
        }

        [NotMapped] public virtual Facility Facility { get; set; } = new Facility();

        [NotMapped] public virtual LogType LogType { get; set; } = new LogType();

        #endregion
    }
}