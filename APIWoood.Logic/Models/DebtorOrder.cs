﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIWoood.Logic.Models
{
    public class DebtorOrder
    {
        public virtual int ID { get; set; }
        public virtual string ORDERNR { get; set; }
	    public virtual string DEBNR { get; set; }
	    public virtual string FAKDEBNR { get; set; }
	    public virtual string REFERENTIE { get; set; }
	    public virtual string OMSCHRIJVING { get; set; }
	    public virtual DateTime ORDDAT { get; set; }
	    public virtual float AANTAL_BESTELD { get; set; }
	    public virtual string ITEMCODE { get; set; }
	    public virtual DateTime AFLEVERDATUM { get; set; }
	    public virtual string OMSCHRIJVING_NL { get; set; }
	    public virtual string OMSCHRIJVING_EN { get; set; }
	    public virtual string OMSCHRIJVING_DE { get; set; }
	    public virtual float AANT_GELEV { get; set; }
	    public virtual int STATUS { get; set; }
	    public virtual string DEL_LANDCODE { get; set; }
	    public virtual string SELCODE { get; set; }
	    public virtual float PRIJS_PER_STUK { get; set; }
	    public virtual float SUBTOTAAL { get; set; }
    }
}
