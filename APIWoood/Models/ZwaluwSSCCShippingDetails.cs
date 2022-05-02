using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace APIWoood.Models
{
    public class ZwaluwSSCCShippingDetails
    {
        [Required]
        [JsonProperty("skuCode")]
        public string SkuCode { get; set; }

        [JsonProperty("lotCode")]
        public string LotCode { get; set; }

        [Required]
        [JsonProperty("quantity")]
        public decimal PalletQuantity { get; set; }
    }
}