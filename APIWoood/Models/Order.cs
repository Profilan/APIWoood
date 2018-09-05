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
        public string DS_LAND { get; set; }
        public string DS_TELEFOON { get; set; }
        public string DS_EMAIL { get; set; }
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

            SYSCREATED = DateTime.Now;
            SYSMODIFIED = SYSCREATED;
        }
    }
}