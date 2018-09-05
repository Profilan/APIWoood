using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace APIWoood.Models
{
    public class Header
    {
        [JsonProperty("api-key")]
        [Required]
        public string apikey { get; set; }
        [Required]
        public string username { get; set; }
        public string password { get; set; }
    }
}