using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ESL.Api.Models.BusinessEntities
{
    [Keyless]
    public partial record WO
    {
        #region Private Variables

        #endregion

        #region Public Properties

        [JsonProperty(PropertyName = "created_by")]
        public string UpdatedBy { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "created_date")]
        public string UpdateDate { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "requested_by")] 
        public string RequestedBy { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "requested_to")] 
        public string RequestedTo { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "requested_date")]
        public string RequestedDate { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "requested_time")]
        public string RequestedTime { get; set; } = string.Empty;

        //public static String GetTimestamp(this DateTime value)=> $"{value:yyyyMMddHHmmssfff}";
 


        // https://stackoverflow.com/questions/10286204/the-right-json-date-format
        [JsonProperty(PropertyName = "event_date")]
        public string EventDate { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "event_time")]
        public string EventTime { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "meter_id")]
        public string MeterID { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "new_value")]
        [Column(TypeName = "NUMBER(8,2)")]
        public decimal? NewValue { get; set; } 

        [JsonProperty(PropertyName = "old-value")]
        [Column(TypeName = "NUMBER(8,2)")]
        public decimal? OldValue { get; set; }

        //[JsonProperty(PropertyName = "accepted")]
        //public string Accepted { get; set; }

        [JsonProperty(PropertyName = "facilno")]
        public int FacilNo { get; set; }

        //[JsonProperty(PropertyName = "logtypeno")]
        //public int LogTypeNo { get; set; }

        [JsonProperty(PropertyName = "off-time")]
        public string? OffTime { get; set; }

        #endregion Public Properties
    }
}
