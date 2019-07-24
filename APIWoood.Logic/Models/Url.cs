using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIWoood.Logic.Models
{
    public class Url
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual int Hits { get; set; }
        public virtual bool ShowInStatistics { get; set; }

        public virtual ISet<User> Users { get; set; }

        public Url()
        {
            Users = new HashSet<User>();
        }
    }
}
