namespace APIWoood.Logic.Models
{
    public class Structure
    {
        public virtual int ID { get; set; }
	    public virtual int LVL { get; set; }
	    public virtual string SEQ_NO { get; set; }
	    public virtual string MAINPROD { get; set; }
	    public virtual string ITEMPROD { get; set; }
	    public virtual string ITEMREQ { get; set; }
	    public virtual string ITEMREQ_DESC { get; set; }
        public virtual string NL_ITEMREQ_DESC { get; set; }
        public virtual string EN_ITEMREQ_DESC { get; set; }
	    public virtual string DE_ITEMREQ_DESC { get; set; }
	    public virtual string FR_ITEMREQ_DESC { get; set; }
	    public virtual int QTY_PER_MAINPROD { get; set; }
    }
}
