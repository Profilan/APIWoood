using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace APIWoood.Models
{
    public class ZwaluwSSCCOrder
    {
        [JsonProperty("loadingDate")]
        public DateTime LoadingDate { get; set; }

        [JsonProperty("unloadingDate")]
        public DateTime UnloadingDate { get; set; }

        [JsonProperty("primaryReference")]
        public string PrimaryReference { get; set; }

        [Required]
        [JsonProperty("statusCode")]
        public int StatusCode { get; set; }

        [JsonProperty("orderNumber")]
        public string OrderNumber { get; set; }

        [JsonProperty("orderLine")]
        public IList<ZwaluwSSCCOrderline> Lines { get; set; }
    }
}