using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIWoood.Models
{
    public abstract class HalItem
    {
        [JsonProperty("_links", Order = -1)]
        public Link Link { get; set; }
    }
}