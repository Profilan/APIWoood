using APIWoood.Logic.Models;
using APIWoood.Logic.SharedKernel;
using APIWoood.Logic.SharedKernel.Interfaces;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIWoood.Logic.Repositories
{
    public class DeliveryMethodRepository : IRepository<DeliveryMethod, string>
    {
        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public DeliveryMethod GetById(string id)
        {
            using (ISession session = SessionFactory.GetNewSession("db1"))
            {
                var item = session.Get<DeliveryMethod>(id);

                return item;
            }
        }

        public void Insert(DeliveryMethod entity)
        {
            throw new NotImplementedException();
        }

        public PagedResult<DeliveryMethod> List(string sortOrder, int pageSize = -1, int pageNumber = -1)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DeliveryMethod> List()
        {
            using (ISession session = SessionFactory.GetNewSession("db1"))
            {
                var query = session.Query<DeliveryMethod>()
                    .OrderBy(s => s.CODE);

                return query.ToList();
            }
        }

        public IEnumerable<DeliveryMethod> ListByCode(string code)
        {
            using (ISession session = SessionFactory.GetNewSession("db1"))
            {
                var query = from s in session.Query<DeliveryMethod>()
                            select s;

                query = query.Where(s => s.CODE == code);

                return query.ToList();
            }
        }

        public void Update(DeliveryMethod entity)
        {
            throw new NotImplementedException();
        }
    }
}
