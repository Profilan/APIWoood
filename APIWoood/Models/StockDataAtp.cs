using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIWoood.Models
{
    public class StockDataAtp
    {
        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("timezone_type")]
        public int TimezoneType { get; set; }

        [JsonProperty("timezone")]
        public string Timezone { get; set; }

        public StockDataAtp(DateTime date)
        {
            TimezoneType = 3;
            Timezone = "Europe/Amsterdam";
            Date = date.ToString("yyyy-MM-dd HH:mm:ss.000000");
        }
    }
}