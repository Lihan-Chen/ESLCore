using System.ComponentModel;
using System.Diagnostics;

namespace ESL.Models.BusinessEntities
{
    /// <summary>
    /// The AllEvent record is an immutable class for readonly  represents an AllEvents that belongs to a <see cref="AllEvent"> AllEvent</see>.
    /// In EF Core, AllEvents records query should be set to notracking based on CQRS
    /// </summary>
    [DebuggerDisplay("AllEvent: {FacilName, nq} {LogTypeName, nq} {EventID, nq} - {EventID_RevNo, nq})")] // ({Type, nq})
    public record AllEvent //: BusinessBase
    {

        #region Private Variables

        // constants have all being moved into the constants namespace and decorated as public static readonly 
        private static string _CrLf = "<br />"; // System.Environment.NewLine;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the facilName of the AllEvents.
        /// </summary>
        [DataObjectFieldAttribute(true, true, false, 2)]
        public int FacilNo { get; set; }

        /// <summary>
        /// Gets or sets the facilName of the AllEvents.
        /// </summary>
        /// 
        [DataObjectFieldAttribute(false, false, false, 40)]
        public string FacilName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the facilAbbr of the AllEvents.
        /// </summary>
        /// 
        [DataObjectFieldAttribute(false, false, false, 5)]
        public string FacilAbbr { get; set; } = string.Empty;


        /// <summary>
        /// Gets or sets the logTypeNo of the AllEvents.
        /// </summary>
        [DataObjectFieldAttribute(true, true, false, 2)]
        public int LogTypeNo { get; set; }

        /// <summary>
        /// Gets or sets the logTypeName of the AllEvents.
        /// </summary>
        /// 
        [DataObjectFieldAttribute(false, false, false, 100)]
        public string LogTypeName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the eventID of the AllEvents.
        /// </summary>
        [DataObjectFieldAttribute(true, true, false, 20)]
        public string EventID { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the eventID_RevNo of the AllEvents.
        /// </summary>
        [DataObjectFieldAttribute(true, true, false, 2)]
        public int EventID_RevNo { get; set; }

        /// <summary>
        /// Gets or sets the eventDate of the AllEvents.
        /// </summary>
        [DataObjectFieldAttribute(false, false, false)]
        public DateTime? EventDate { get; set; }

        /// <summary>
        /// Gets or sets the eventTime of the AllEvents.
        /// </summary>
        [DataObjectFieldAttribute(false, false, false, 5)]
        public string EventTime { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the subject of the AllEvents.
        /// </summary>
        [DataObjectFieldAttribute(false, false, false, 300)]
        public string Subject { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the details of the AllEvents.
        /// </summary>
        [DataObjectFieldAttribute(false, false, false, 2000)]
        //[NotNullOrEmpty(Key = "DetailsNotEmpty")]
        public string Details { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the modifyFlag of the FlowChange.
        /// </summary>
        [DataObjectFieldAttribute(false, false, true, 100)]
        public string? ModifyFlag { get; set; }

        /// <summary>
        /// Gets or sets the notes of the FlowChange.
        /// </summary>
        [DataObjectFieldAttribute(false, false, true, 400)]
        public string? Notes { get; set; }

        /// <summary>
        /// Gets or sets the operatorType of the AllEvents.
        /// </summary>
        [DataObjectFieldAttribute(false, false, false, 15)]
        //[NotNullOrEmpty(Key = "DetailsNotEmpty")]
        public string? OperatorType { get; set; }

        /// <summary>
        /// Gets or sets the updatedBy uID of the AllEvents.
        /// </summary>
        [DataObjectFieldAttribute(false, false, false, 60)]
        public string UpdatedBy { get; set; } = string.Empty;

        ///// <summary>
        ///// Gets or sets the updatedBy of the AllEvents.
        ///// </summary>
        //[DataObjectFieldAttribute(false, false, false)]
        //public string UpdatedByName { get; set; }

        /// <summary>
        /// Gets or sets the updateDate of the AllEvents.
        /// </summary>
        [DataObjectFieldAttribute(false, false, false)]
        public string UpdateDate { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the clearanceID of the AllEvents.
        /// </summary>
        [DataObjectFieldAttribute(false, false, false, 20)]
        //[NotNullOrEmpty(Key = "DetailsNotEmpty")]
        public string ClearanceID { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the ScanDocsNo of the AllEvents.
        /// </summary>
        [DataObjectFieldAttribute(false, false, true, 2)]
        public int ScanDocsNo { get; set; }

        /// <summary>
        /// Gets or sets the eventIdentifier of the AllEvents.
        /// </summary>
        //[DataObjectFieldAttribute(false, false, false)]
        //[NotNullOrEmpty(Key = "DetailsNotEmpty")]
        public string EventIdentifier => $"{EventID}/{EventID_RevNo.ToString()}";

        /// <summary>
        /// Gets or sets the eventHighlight of the AllEvents.
        /// </summary>
        //[DataObjectFieldAttribute(false, false, false)]
        //[NotNullOrEmpty(Key = "DetailsNotEmpty")]
        public string EventHighlight => Subject ?? Subject + _CrLf + ( Details ?? Details +  _CrLf + "Updated By: " + UpdatedBy + " on " + UpdateDate);
        
        // Navigation to be implemented with EF virtural
        public virtual ScanDoc? scandoc { get; set; }

        #endregion
    }
}
