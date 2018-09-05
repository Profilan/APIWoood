using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace APIWoood.Models
{
    public class OrderItem
    {
        public int ID { get; set; }
        [Required]
        public string ITEMCODE { get; set; }
        [Required]
        public float AANTAL { get; set; }
        public int STATUS { get; set; }
        public string ORDERNR { get; set; }
        public string VERZENDWEEK { get; set; }
        public DateTime SYSCREATED { get; set; }
        public DateTime SYSMODIFIED { get; set; }
        public string SYSMSG { get; set; }
    }
}