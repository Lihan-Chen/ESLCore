using ESL.Core.Models.BusinessEntities;
using ESL.Core.Models.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESL.Application.Models
{
    public record class AllEventModel : AllEvent
    {
        private string _CrLf = System.Environment.NewLine;

        #region Public Extended Properties

        public string FacilName { get; set; } = null!;

        public string LogTypeName { get; set; } = null!;

        /// <summary>
        /// Gets or sets the ScanDocsNo of the AllEvents.
        /// </summary>
        [NotMapped]
        public int ScanDocsNo { get; set; }

        /// <summary>
        /// Gets or sets the EventIDentifier of the AllEvents.
        /// </summary>
        [NotMapped]
        public string EventIDentifier => $"{EventID}/{EventID_RevNo}";

        /// <summary>
        /// Gets or sets the eventHighlight of the AllEvents.
        /// </summary>
        [NotMapped]
        public string EventHighlight => string.IsNullOrEmpty(Subject) ? string.Empty : $"{Subject}{_CrLf}" + (string.IsNullOrEmpty(Details) ? string.Empty : $"{Details}{_CrLf}") + $"Updated By: {UpdatedBy} on {UpdateDate}";

        #endregion Public Extended Properties
    }
}
