using Microsoft.Extensions.Logging;
using static Azure.Core.HttpHeader;
using static Microsoft.Graph.CoreConstants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Diagnostics;

namespace ESL.Models.BusinessEntities
{
    /// <summary>
    /// The FlowChange class represents an FlowChange that belongs to a <see cref="FlowChange"> FlowChange</see>.
    /// </summary>
    [DebuggerDisplay("FlowChange: {FacilName, nq} {LogTypeName, nq} {EventID, nq} - {EventID_RevNo, nq})")] // ({Type, nq})
    public class FlowChange : BaseEvent
    {
        #region Private Variables

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the requestedBy of the FlowChange.
        /// </summary>
        [DataObjectFieldAttribute(false, false, true, 7)]
        // [Display(Name = "Requested By (optional)")]
        public int? RequestedById { get; set; }

        /// <summary>
        /// Gets or sets the requestedBy Name of the FlowChange.
        /// </summary>
        [DataObjectFieldAttribute(false, false, true, 80)]
        [Display(Name = "Requested By (optional)")]
        public string RequestedBy_Name => RequestedBy == null ? string.Empty : RequestedBy.ToString();
        //{
        //    get
        //    {
        //        return RequestBy(int id).ToString();
        //    }
        //}

        /// <summary>
        /// Gets or sets the requestedTo of the FlowChange.
        /// </summary>
        [DataObjectFieldAttribute(false, false, false, 7)]
        // [Display(Name = "Requested To")]
        [Required(ErrorMessage = "Need to select a name from pull-down list.  Please try again.")]
        public int RequestedTo { get; set; }

        /// <summary>
        /// Gets or sets the requestedTo Name of the FlowChange.
        /// </summary>
        [DataObjectFieldAttribute(false, false, false, 80)]
        [Display(Name = "Requested To")]
        [Required(ErrorMessage = "Need to select a name from pull-down list.  Please try again.")]
        public string RequestedTo_Name => RequestedTo.ToString();
        //{
        //    get
        //    {
        //        return Helpers.GetEmpFullName("RequestedTo", RequestedTo, FacilNo);
        //    }
        //}

        /// <summary>
        /// Gets or sets the requestedDate of the FlowChange.
        /// </summary>
        [DataObjectFieldAttribute(false, false, false)]
        [Display(Name = "Request Date")]
        [Required(ErrorMessage = "Request Date is Required.")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime RequestedDate { get; set; }

        /// <summary>
        /// Gets or sets the requestedTime of the FlowChange.
        /// </summary>
        [DataObjectFieldAttribute(false, false, false, 5)]
        [Display(Name = "Request Time", Prompt = "hh:mm")]
        [Required(ErrorMessage = "Request Time in hh:mm format is Required.")]
        [RegularExpression("([01]?[0-9]|2[0-3]):[0-5][0-9]")]
        public string RequestedTime { get; set; }

        /// <summary>
        /// Gets or sets the eventDate of the FlowChange.
        /// </summary>
        [DataObjectFieldAttribute(false, false, false)]
        [Display(Name = "Effective Date")]
        [Required(ErrorMessage = "Event Date is Required.")]
        //[UIHint("Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime EventDate { get; set; }

        /// <summary>
        /// Gets or sets the eventTime of the FlowChange.
        /// </summary>
        [DataObjectFieldAttribute(false, false, false, 5)]
        [Display(Name = "Effective Time", Prompt = "hh:mm")]
        [RegularExpression("([01]?[0-9]|2[0-3]):[0-5][0-9]", ErrorMessage = "Time must be a valid 24 hour time in HH:MM format")]
        //[RegularExpression("^2[0-3]|[01][0-9]:[0-5][0-9]$")]  // "([01]?[0-9]|2[0-3]):[0-5][0-9]"
        //[RegularExpression("^([0-1]?\d|2[0-3]):([0-5]\d)$")]
        public string EventTime { get; set; }

        /// <summary>
        /// Gets or sets the offTime of the FlowChange.
        /// </summary>
        [DataObjectFieldAttribute(false, false, true, 5)]
        [Display(Name = "Time Off", Prompt = "hh:mm")]
        [RegularExpression("([01]?[0-9]|2[0-3]):[0-5][0-9]", ErrorMessage = "Time must be a valid 24 hour time in HH:MM format")]
        public string OffTime { get; set; }

        //[DataType(DataType.Time)]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:hh:mm tt}")]  "([01]?[0-9]|2[0-3]):[0-5][0-9]" "^2[0-3]|[01][0-9]:[0-5][0-9]$"
        //[Display(Name = "Time Off")]
        //public DateTime? OffTime { get; set; }

        /// <summary>
        /// Gets or sets the meterID of the FlowChange.
        /// </summary>
        [DataObjectFieldAttribute(false, false, false, 30)]
        [Required(ErrorMessage = "Meter ID is missing.  Please select fromt the pull-down.")]
        [Display(Name = "Meter ID")]
        public string MeterID { get; set; }

        /// <summary>
        /// Gets or sets the changedBy of the FlowChange.
        /// </summary>
        [DataObjectFieldAttribute(false, false, true, 10)]
        [Required(ErrorMessage = "Change Value is missing.  When reducing flow, enter a negative sign before the numuber without space.")]
        [Display(Name = "Change +/-", Prompt = "numbers only, no space")]
        [RegularExpression("[-+]?([0-9]*.[0-9]+|[0-9]+)", ErrorMessage = "Change value must be a valid number in digital format.")]  // ^\d+(\.\d{1,2})?$ // ^-*[0-9,\.]+$
        public string ChangeBy { get; set; }

        /// <summary>
        /// Gets or sets the newValue of the FlowChange.
        /// </summary>
        [DataObjectFieldAttribute(false, false, true, 10)]
        //[Required(ErrorMessage = "New Value must be equal to the sum of Old and Change Values.")]  // ^[+]?([.]\d+|\d+([.]\d+)?)$
        [Display(Name = "New Flow")]
        [RegularExpression(@"[0-9]*\.?[0-9]+", ErrorMessage = "New value must be a valid positive number in digital format.")]  // "@^(?:[1-9][0-9]*|0)$@"
        [Range(typeof(Decimal), "0", "9999", ErrorMessage = "Price must be a decimal/number between {1} and {2}.")]
        public decimal? NewValue { get; set; }

        /// <summary>
        /// Gets or sets the unit of the FlowChange.
        /// </summary>
        [DataObjectFieldAttribute(false, false, true, 10)]
        //[Required(ErrorMessage = "All unit must be consistent.")]
        [Display(Name = "New Unit")]
        public string Unit { get; set; }

        /// <summary>
        /// Gets or sets the oldValue of the FlowChange.
        /// </summary>
        [DataObjectFieldAttribute(false, false, true, 10)]
        [Display(Name = "Old Value")]
        [RegularExpression(@"[0-9]*\.?[0-9]+", ErrorMessage = "Old value must be a valid positive number in digital format.")] // "@^(?:[1-9][0-9]*|0)$@"  // @"[0-9]*\.?[0-9]+"
        [Range(typeof(Decimal), "0", "9999", ErrorMessage = "Price must be a decimal/number between {1} and {2}.")]
        public decimal? OldValue { get; set; }

        /// <summary>
        /// Gets or sets the oldUnit of the FlowChange.
        /// </summary>
        [DataObjectFieldAttribute(false, false, true, 10)]
        [Required(ErrorMessage = "All unit must be consistent.")]
        [Display(Name = "Old Unit")]
        public string OldUnit { get; set; }

        /// <summary>
        /// Gets or sets the changedByUnit of the FlowChange.
        /// </summary>
        [DataObjectFieldAttribute(false, false, true, 10)]
        [Required(ErrorMessage = "All unit must be consistent.")]
        [Display(Name = "ChangeBy Unit")]
        public string? ChangeByUnit { get; set; }

        /// <summary>
        /// Gets or sets the accepted of the FlowChange.
        /// </summary>
        [DataObjectFieldAttribute(false, false, true, 10)]
        [Display(Name = "Acceptance Status")]
        public string? Accepted { get; set; }

        /// <summary>
        /// Gets or sets the eventIdentifier of the FlowChange.
        /// </summary>
        [DataObjectFieldAttribute(false, false, false)]
        //[NotNullOrEmpty(Key = "DetailsNotEmpty")]
        [Display(Name = "Event ID / Revision")]
        public string EventIdentifier
        {
            get
            {
                return EventID + " / " + Convert.ToString(EventID_RevNo);
            }

        }

        /// <summary>
        /// Gets or sets the eventHighlight of the FlowChange.
        /// </summary>
        [DataObjectFieldAttribute(false, false, false)]
        //[NotNullOrEmpty(Key = "DetailsNotEmpty")
        [Display(Name = "Event Hightlight")]
        public string EventHighlight
        {
            get
            {
                string _EventHighlight = String.Empty;
                _EventHighlight = "Meter ID: " + MeterID + _CrLf;
                if (Convert.ToDecimal(ChangeBy) < 0)
                {
                    _EventHighlight += "Decrease:  ";
                }
                else if (Convert.ToDecimal(ChangeBy) > 0)
                {
                    _EventHighlight += "Increase:  ";
                }

                _EventHighlight += ChangeBy + " " + ChangeByUnit + _CrLf;

                if (!String.IsNullOrEmpty(Convert.ToString(NewValue)))
                {
                    _EventHighlight += "New Value: " + Convert.ToString(NewValue) + " " + Unit + _CrLf;
                }

                _EventHighlight += "Effective Dt/Tm: " + EventDate.ToString("MM/dd/yyyy") + " " + EventTime + _CrLf;

                if (!String.IsNullOrEmpty(OffTime))
                {
                    _EventHighlight += "Time Off: " + OffTime + _CrLf;
                }

                if (!String.IsNullOrEmpty(RelatedTo))
                {
                    _EventHighlight += "Related to Event Nos.: " + RelatedTo + _CrLf;
                }

                if (!String.IsNullOrEmpty(WorkOrders))
                {
                    _EventHighlight += "Work Order Nos.: " + WorkOrders + _CrLf;
                }

                if (!String.IsNullOrEmpty(Notes))
                {
                    _EventHighlight += "Additional Notes: " + Notes + _CrLf;
                }

                _EventHighlight += "Scanned docs stored: " + ScanDocsNo;

                return _EventHighlight;
            }
        }

        /// <summary>
        /// Gets or sets the eventHeader of the FlowChange.
        /// </summary>
        [DataObjectFieldAttribute(false, false, false)]
        //[NotNullOrEmpty(Key = "DetailsNotEmpty")
        public string EventHeader
        {
            get
            {
                string _EventHeader = "Details for ";
                if (Accepted == "Y")
                {
                    _EventHeader += "Real Time ";
                }
                else
                {
                    _EventHeader += "Pre-Scheduled ";
                }
                _EventHeader += "Flow Change on MeterID " + MeterID + " on " + EventDate.ToString("MM/dd/yyyy") + " at " + EventTime;

                return _EventHeader;
            }
        }

        /// <summary>
        /// Gets or sets the eventTrail of the FlowChange.
        /// </summary>
        [DataObjectFieldAttribute(false, false, false)]
        [Display(Name = "Action History")]
        public string EventTrail
        {
            get
            {
                string _EventTrail = String.Empty;

                if (RequestedBy != null)
                {
                    _EventTrail = "Requested By: " + RequestedBy.ToString() + _CrLf;
                }
                else
                {
                    _EventTrail = "Requested By: " + "n/a" + _CrLf;
                }

                if (RequestedTo != 0)
                {
                    //_EventTrail += "Requested To: " + Helpers.GetEmpFullName("RequestedTo", RequestedTo, FacilNo) + _CrLf;
                    _EventTrail += "Requested To: " + RequestedTo.ToString();
                }
                else
                {
                    _EventTrail += "Requested To: " + "n/a" + _CrLf;
                }

                //if (RequestedDate == null)
                //{
                //    _EventTrail += "Requested Dt/Tm: " + "n/a" + _CrLf;
                //}
                //else
                //{
                    _EventTrail += "Requested Dt/Tm: " + RequestedDate.ToString("MM/dd/yyyy") + " " + RequestedTime + _CrLf;
                //}

                if (OperatorID != 0)
                {
                    _EventTrail += "Logged By: " + Operator.ToString() + _CrLf;
                    _EventTrail += "Logged Dt/Tm: " + UpdateDate.ToString("MM/dd/yyyy hh:mm") + _CrLf;
                }
                else
                {
                    _EventTrail += "Logged By: " + "n/a" + _CrLf;
                    _EventTrail += "Logged Dt/Tm: " + "n/a" + _CrLf;
                }

                if (NotifiedPerson != null)
                {
                    _EventTrail += "Notified Person: " + NotifiedPerson.ToString() + _CrLf;
                }
                else
                {
                    _EventTrail += "Notified Person: " + "n/a";
                }

                return _EventTrail;
            }
        }

        #endregion
    }
}
