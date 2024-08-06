using System;
using System.ComponentModel;
using System.Diagnostics;
using PocketBook.Models.Validation;

namespace PocketBook.Models
{
  /// <summary>
  /// The Search class represents an Search that belongs to a <see cref="Search"> Search</see>.
  /// </summary>
    [DebuggerDisplay("Search: {FacilName, nq} {LogTypeName, nq} {EventID, nq} - {EventID_RevNo, nq})")] // ({Type, nq})
    public class SearchDTO //: BusinessBase
    {

        #region Private Variables

        private string _CrLf = "<br />"; // System.Environment.NewLine;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the facilName of the Search.
        /// </summary>
        [DataObjectField(true, true, false)]
        public int FacilNo { get; set; }
        
        /// <summary>
    /// Gets or sets the facilName of the AllEvents.
    /// </summary>
    /// 
        [DataObjectField(false, false, false)]
        public string FacilName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the logTypeName of the Search.
        /// </summary>
        [DataObjectField(true, true, false)]
        public int LogTypeNo  { get; set; }
        
        /// <summary>
        /// Gets or sets the logTypeName of the AllEvents.
        /// </summary>
        /// 
        [DataObjectField(false, false, false)]
        public string LogTypeName {get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the eventID of the Search.
        /// </summary>
        [DataObjectField(true, true, false)]
        public string EventID  { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the eventID_RevNo of the Search.
        /// </summary>
        [DataObjectField(true, true, false)]
        public int EventID_RevNo { get; set; }
        
        /// <summary>
        /// Gets or sets the eventDate of the Search.
        /// </summary>
        [DataObjectField(false, false, false)]
        public DateTime EventDate  { get; set; }
        
        /// <summary>
        /// Gets or sets the eventTime of the Search.
        /// </summary>
        [DataObjectField(false, false, false)]
        public string EventTime  { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the subject of the Search.
        /// </summary>
        [DataObjectField(false, false, false)]
        public string Subject  { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the details of the Search.
        /// </summary>
        [DataObjectField(false, false, false)]
        //[NotNullOrEmpty(Key = "DetailsNotEmpty")]
        public string Details { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the operatorType of the Search.
        /// </summary>
        [DataObjectField(false, false, false)]
        //[NotNullOrEmpty(Key = "DetailsNotEmpty")]
        public string OperatorType { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the updatedBy of the Search.
        /// </summary>
        [DataObjectField(false, false, false)]
        public string UpdatedBy { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the updateDate of the Search.
        /// </summary>
        [DataObjectField(false, false, false)]
        public string UpdateDate { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the clearanceID of the Search.
        /// </summary>
        [DataObjectField(false, false, false)]
        //[NotNullOrEmpty(Key = "DetailsNotEmpty")]
        public string ClearanceID { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the eventIdentifier of the Search.
        /// </summary>
        [DataObjectField(false, false, false)]
        //[NotNullOrEmpty(Key = "DetailsNotEmpty")]
        public string EventIdentifier => $"{EventID} / {Convert.ToString(EventID_RevNo)}";

        /// <summary>
        /// Gets or sets the eventHighlight of the Search.
        /// </summary>
        [DataObjectField(false, false, false)]
        //[NotNullOrEmpty(Key = "DetailsNotEmpty")]
        public string EventHighlight => $"{Subject}{_CrLf}{Details}{_CrLf}Updated By: {UpdatedBy} on {UpdateDate}";

        #endregion
    }

}
