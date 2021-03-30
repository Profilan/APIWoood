using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace APIWoood.Models
{
    public class DutchNedDeliveryAppointment
    {
        [JsonProperty("id")]
        [Required]
        public int OrderLineId { get; set; }

        [JsonProperty("dutchned_delivery_order_id")]
        public int DutchNedDeliveryOrderId { get; set; }

        [JsonProperty("dutchned_package_id")]
        public int DutchNedPackageId { get; set; }

        [JsonProperty("event")]
        public int Status { get; set; }

        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("data", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public object Data { get; set; }
    }
}