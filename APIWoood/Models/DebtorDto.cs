using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIWoood.Models
{
    public class DebtorDto
    {
        public string NAAM { get; set; }
        public string TYPE { get; set; }
        public string DEBITEURNR { get; set; }
        public string FAKTUURDEBITEURNR { get; set; }
        public string CLASSIFICATIE { get; set; }
        public string CLASS_OMS { get; set; }
        public string BTWNR { get; set; }
        public string BETALINGSCONDITIE { get; set; }
        public string BETALINGSCONDITIEOMS { get; set; }
        public string LEVERINGSWIJZE { get; set; }
        [JsonProperty("WOOOD.NL")]
        public int WOOOD_NL { get; set; }
        public int PORTAL { get; set; }
        public string FACTADRES { get; set; }
        public string FACTPC { get; set; }
        public string FACTPLAATS { get; set; }
        public string FACTLANDCODE { get; set; }
        public string FACTLAND { get; set; }
        public string BEZADRES { get; set; }
        public string BEZPC { get; set; }
        public string BEZPLAATS { get; set; }
        public string BEZLANDCODE { get; set; }
        public string BEZLAND { get; set; }
        public string AFLADRES { get; set; }
        public string AFLPC { get; set; }
        public string AFLPLAATS { get; set; }
        public string AFLLANDCODE { get; set; }
        public string AFLLAND { get; set; }
        public string POSTADRES { get; set; }
        public string POSTPC { get; set; }
        public string POSTPLAATS { get; set; }
        public string POSTLANDCODE { get; set; }
        public string POSTLAND { get; set; }
        public string CMP_NAME { get; set; }
        public string KVK { get; set; }
        public float FRANCO_LIMIET { get; set; }
        public float MINIMUM_ORDER_LIMIET { get; set; }
        public float ORDER_TOESLAG { get; set; }
        public int ACCOUNTMANAGER { get; set; }
        public string DFF_ACCESSCODE { get; set; }
        public int OVERRIDE_LIMITS { get; set; }
        public string DEB_NAME_ALIAS { get; set; }
        public string DEB_WWW_ALIAS { get; set; }
        public int DEALER_ACTIVATION { get; set; }
        public string DEALER_BRANDS { get; set; }
        public string DEALER_TYPE { get; set; }
        public string DEALER_WWW_WOOOD { get; set; }
        public string DEALER_WWW_BPH { get; set; }
    }
}