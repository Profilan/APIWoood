using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace APIWoood.Models
{
    public class ZwaluwSSCCDto
    {
        [Required]
        [JsonProperty("ediReference")]
        public string EdiReference { get; set; }

        [JsonProperty("shipmentNumber")]
        public string ShipmentNumber { get; set; }

        [JsonProperty("dateTime")]
        public DateTime DateTime { get; set; }

        [JsonProperty("refernceNumber")]
        public string ReferenceNumber { get; set; }

        [JsonProperty("order")]
        public IList<ZwaluwSSCCOrder> Orders { get; set; }
    }
}