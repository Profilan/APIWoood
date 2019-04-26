using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIWoood.Logic.Models
{
    public class Debtor
    {
	    public virtual string NAAM { get; set; }
	    public virtual string TYPE { get; set; }
        public virtual string DEBITEURNR { get; set; }
        public virtual string FAKTUURDEBITEURNR { get; set; }
	    public virtual string CLASSIFICATIE { get; set; }
	    public virtual string CLASS_OMS { get; set; }
	    public virtual string BTWNR { get; set; }
	    public virtual string BETALINGSCONDITIE { get; set; }
	    public virtual string BETALINGSCONDITIEOMS { get; set; }
	    public virtual string LEVERINGSWIJZE { get; set; }
	    public virtual int WOOOD_NL { get; set; }
	    public virtual int PORTAL { get; set; }
	    public virtual string FACTADRES { get; set; }
	    public virtual string FACTPC { get; set; }
	    public virtual string FACTPLAATS { get; set; }
	    public virtual string FACTLANDCODE { get; set; }
	    public virtual string FACTLAND { get; set; }
	    public virtual string BEZADRES { get; set; }
	    public virtual string BEZPC { get; set; }
	    public virtual string BEZPLAATS { get; set; }
	    public virtual string BEZLANDCODE { get; set; }
	    public virtual string BEZLAND { get; set; }
	    public virtual string AFLADRES { get; set; }
	    public virtual string AFLPC { get; set; }
	    public virtual string AFLPLAATS { get; set; }
	    public virtual string AFLLANDCODE { get; set; }
	    public virtual string AFLLAND { get; set; }
	    public virtual string POSTADRES { get; set; }
	    public virtual string POSTPC { get; set; }
	    public virtual string POSTPLAATS { get; set; }
	    public virtual string POSTLANDCODE { get; set; }
	    public virtual string POSTLAND { get; set; }
	    public virtual string CMP_NAME { get; set; }
	    public virtual string KVK { get; set; }
	    public virtual float FRANCO_LIMIET { get; set; }
	    public virtual float MINIMUM_ORDER_LIMIET { get; set; }
	    public virtual float ORDER_TOESLAG { get; set; }
        public virtual int  ACCOUNTMANAGER { get; set; }
        public virtual string DFF_ACCESSCODE { get; set; }
	    public virtual int OVERRIDE_LIMITS { get; set; }
	    public virtual string DEB_NAME_ALIAS { get; set; }
	    public virtual string DEB_WWW_ALIAS { get; set; }
        public virtual int DEALER_ACTIVATION { get; set; }
        public virtual string DEALER_BRANDS { get; set; }
        public virtual string DEALER_TYPE { get; set; }

        public virtual ISet<User> Users { get; set; }

        public Debtor()
        {
            Users = new HashSet<User>();
        }
    }
}
