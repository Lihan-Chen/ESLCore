using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESL.Core.IConfiguration
{
    public interface ILogEventEntity // : IEventIdentity
    {
        #region Internal Variables

        #endregion

        #region Public Properties

        ///// <summary>
        ///// Gets or sets the facilName of the event.
        ///// </summary>
        //public int FacilNo { get; set; }

        /// <summary>
        /// Gets or sets the facilName of the event.
        /// </summary>
        /// 
        public string FacilName { get; set; }

        ///// <summary>
        ///// Gets or sets the logTypeNo of the FlowChange.
        ///// </summary>
        //public int LogTypeNo { get; set; }

        /// <summary>
        /// Gets or sets the logTypeName of the FlowChange.
        /// </summary>
        public string LogTypeName { get; set; }

        ///// <summary>
        ///// Gets or sets the eventID of the FlowChange.
        ///// </summary>
        //public string EventID { get; set; }

        ///// <summary>
        ///// Gets or sets the eventID_RevNo of the FlowChange.
        ///// </summary>
        //public int EventID_RevNo { get; set; }

        /// <summary>
        /// Gets or sets the operatorID of the FlowChange.
        /// </summary>
        public int OperatorID { get; set; }

        /// <summary>
        /// Gets or sets the createdBy of the FlowChange.
        /// </summary>
        public int? CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the createdDate of the FlowChange.
        /// </summary>
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets the modifyFlag of the FlowChange.
        /// </summary>
        public string? ModifyFlag { get; set; }

        /// <summary>
        /// Gets or sets the modifiedBy of the FlowChange.
        /// </summary>
        public int? ModifiedBy { get; set; }

        /// <summary>
        /// Gets or sets the modifyDate of the FlowChange.
        /// </summary>
        public DateTime? ModifiedDate { get; set; }

        /// <summary>
        /// Gets or sets the notes of the FlowChange.
        /// </summary>
        public string? Notes { get; set; }

        /// <summary>
        /// Gets or sets the notifiedFacil of the FlowChange.
        /// </summary>
        public string? NotifiedFacil { get; set; }

        /// <summary>
        /// Gets or sets the notifiedPerson of the FlowChange.
        /// </summary>
        public int? NotifiedPerson { get; set; }

        /// <summary>
        /// Gets or sets the notifiedPerson of the FlowChange.
        /// </summary>
        public string? NotifiedPerson_Name { get; }

        /// <summary>
        /// Gets or sets the shiftNo of the FlowChange.
        /// </summary>
        public int? ShiftNo { get; set; }
        /// <summary>
        /// Gets or sets the yr of the FlowChange.
        /// </summary>
        public string Yr { get; set; }

        /// <summary>
        /// Gets or sets the seqNo of the FlowChange.
        /// </summary>
        public int SeqNo { get; set; }

        ///// <summary>
        ///// Gets or sets the updatedBy of the FlowChange.
        ///// </summary>
        //public string UpdatedBy { get; set; }

        ///// <summary>
        ///// Gets or sets the updateDate of the FlowChange.
        ///// </summary>
        //public DateTime UpdateDate { get; set; }

        /// <summary>
        /// Gets or sets the workOrders of the FlowChange.
        /// </summary>
        public string? WorkOrders { get; set; }

        /// <summary>
        /// Gets or sets the relatedTo of the FlowChange.
        /// </summary>
        public string? RelatedTo { get; set; }

        /// <summary>
        /// Gets or sets the operatorType of the FlowChange.
        /// </summary>
        public string? OperatorType { get; set; }


        /// <summary>
        /// Gets or sets the ScanDocsNo of the AllEvents.
        /// </summary>
        public int ScanDocsNo { get; set; }

        #endregion
    }
}

