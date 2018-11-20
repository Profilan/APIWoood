using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace APIWoood.Models
{
    public class DutchNedSalesOrderLineStatus
    {
        [JsonProperty("order_line_id")]
        [Required]
        public int OrderLineId { get; set; }

        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("data")]
        public string Data { get; set; }
    }
}