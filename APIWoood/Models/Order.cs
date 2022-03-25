using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace APIWoood.Models
{
    public class Order
    {
        [Required]
        public string REFERENTIE { get; set; }
        [Required]
        public string DEBITEURNR { get; set; }
        [StringLength(30)]
        public string OMSCHRIJVING { get; set; }
        public int STATUS { get; set; }
        public string ORDERNR { get; set; }
        public string SELECTIECODE { get; set; }
        public string ORDERTOELICHTING { get; set; }
        public int ACCEPTATIE_VERZAMELEN { get; set; }
        public int ACCEPTATIE_ORDERKOSTEN { get; set; }
        public string DS_NAAM { get; set; }
        public string DS_AANSPREEKTITEL { get; set; }
        public string DS_ADRES1 { get; set; }
        public string DS_POSTCODE { get; set; }
        public string DS_PLAATS { get; set; }
        [StringLength(2)]
        public string DS_LAND { get; set; }
        public string DS_TELEFOON { get; set; }
        public string DS_EMAIL { get; set; }
        public string SR_SERVICE_PRODUCT { get; set; }
        public string SR_AFLEVEREN_AAN { get; set; }
        public string SR_LOCATIE { get; set; }
        public string SR_BEDRIJFSNAAM { get; set; }
        public string SR_BEWIJS { get; set; }
        public string SR_ORDERREF { get; set; }
        public string SR_REDEN { get; set; }
        public string SR_TOELICHTING { get; set; }
        public string SR_PDF_ATTACHMENT { get; set; }
        public string AUTHENTICATED_USER { get; set; }
        public int ACCEPTATIE_ORDERSPLITSING { get; set; }
        public int PAYMENT_RELEASE_REQUIRED { get; set; }
        public DateTime SYSCREATED { get; set; }
        public DateTime SYSMODIFIED { get; set; }
        public string SYSMSG { get; set; }

        public virtual ISet<OrderItem> item { get; set; }

        public Order()
        {
            item = new HashSet<OrderItem>();

            SR_SERVICE_PRODUCT = "";
            SR_AFLEVEREN_AAN = "";
            SR_LOCATIE = "";
            SR_BEDRIJFSNAAM = "";
            SR_BEWIJS = "";
            SR_ORDERREF = "";
            SR_REDEN = "";
            SR_TOELICHTING = "";
            SR_PDF_ATTACHMENT = "";

            SYSCREATED = DateTime.Now;
            SYSMODIFIED = SYSCREATED;
        }
    }
}