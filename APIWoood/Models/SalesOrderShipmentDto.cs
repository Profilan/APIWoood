using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace APIWoood.Models
{
    public class SalesOrderShipmentDto
    {
        // SKU_Id
        [JsonProperty("skuId")]
        public string SkuId { get; set; }

        // ShipmentId
        [Required]
        [JsonProperty("shipmentId")]
        public int ShipmentId { get; set; }

        // DebtorNumber
        [Required]
        [StringLength(10)]
        [JsonProperty("debtorNumber")]
        public string DebtorNumber { get; set; }

        // SKU_Type
        [Required]
        [StringLength(10)]
        [JsonProperty("skuType")]
        public string SkuType { get; set; }

        // Carrier
        [Required]
        [StringLength(50)]
        [JsonProperty("carrier")]
        public string Carrier { get; set; }

        // DeliveryDate
        [Required]
        [JsonProperty("deliveryDate")]
        public string DeliveryDate { get; set; }

        // DebtorName
        [Required]
        [StringLength(50)]
        [JsonProperty("debtorName")]
        public string DebtorName { get; set; }

        // DelAddress
        [Required]
        [StringLength(100)]
        [JsonProperty("delAddress")]
        public string DelAddress { get; set; }

        // DelPostcode
        [StringLength(20)]
        [JsonProperty("delPostcode")]
        public string DelPostcode { get; set; }

        // DelCity
        [StringLength(100)]
        [JsonProperty("delCity")]
        public string DelCity { get; set; }

        // DelCountryCode
        [StringLength(2)]
        [JsonProperty("delCountryCode")]
        public string DelCountryCode { get; set; }

        // TrackTraceCode
        [StringLength(50)]
        [JsonProperty("trackTraceCode")]
        public string TrackTraceCode { get; set; }

        // TrackTraceUrl
        [StringLength(250)]
        [JsonProperty("trackTraceUrl")]
        public string TrackTraceUrl { get; set; }

        // Status
        [JsonProperty("status")]
        public int Status { get; set; }
    }
}