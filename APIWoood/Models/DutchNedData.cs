using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIWoood.Models
{
    public class DutchNedData
    {
        [JsonProperty("tracking_code")]
        public string TrackingCode { get; set; }

        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("notes")]
        public string Notes { get; set; }

        [JsonProperty("time_from")]
        public string TimeFrom { get; set; }

        [JsonProperty("time_till")]
        public string TimeTill { get; set; }
    }
}