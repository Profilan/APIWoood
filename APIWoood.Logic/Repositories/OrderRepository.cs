using APIWoood.Logic.Models;
using APIWoood.Logic.SharedKernel;
using APIWoood.Logic.SharedKernel.Interfaces;
using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIWoood.Logic.Repositories
{
    public class OrderRepository : IRepository<OrderHeader, int>
    {
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public OrderHeader GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderHeader> GetByIdentifier(OrderIdentifier orderIdentifier)
        {
            using (ISession session = SessionFactory.GetNewSession("db1"))
            {
                var query = from o in session.Query<OrderHeader>()
                            select o;

                query = query.Where(o => o.OrderIdentifier == orderIdentifier);

                return query.ToList();
            }
        }

        public void Insert(OrderHeader orderHeader)
        {
            using (ISession session = SessionFactory.GetNewSession("db1"))
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    orderHeader.SYSCREATED = DateTime.Now;
                    orderHeader.SYSMODIFIED = orderHeader.SYSCREATED;

                    session.Save(orderHeader);
                    transaction.Commit();
                }
            }
        }

        public PagedResult<OrderHeader> List(string sortOrder, int pageSize = 25, int pageNumber = 1)
        {
            using (ISession session = SessionFactory.GetNewSession("db1"))
            {
                var query = session.Query<OrderHeader>().Skip((pageNumber - 1) * pageSize).Take(pageSize);

                //                var query = from d in session.Query<DebtorOrder>()
                //                            select d;

                switch (sortOrder)
                {
                    case "ID_DESC":
                    default:
                        //query = query.OrderByDescending(h => h.SYSCREATED);
                        break;
                }

                var result = new PagedResult<OrderHeader>();

                result.Results = query.ToList();

                return result;
            }
        }

        public IEnumerable<OrderHeader> List()
        {
            throw new NotImplementedException();
        }

        public void Update(OrderHeader entity)
        {
            throw new NotImplementedException();
        }
    }
}
