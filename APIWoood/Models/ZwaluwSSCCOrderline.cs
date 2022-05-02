using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace APIWoood.Models
{
    public class ZwaluwSSCCOrderline
    {
        [Required]
        [JsonProperty("orderlineId")]
        public int OrderlineId { get; set; }

        [JsonProperty("itemCode")]
        public string ItemCode { get; set; }

        [JsonProperty("quantity")]
        public decimal OrderlineQuantity { get; set; }

        public IList<ZwaluwSSCCShippingDetails> ShippingDetails { get; set; }
    }
}