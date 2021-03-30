using APIWoood.Logic.Models;
using APIWoood.Logic.SharedKernel;
using APIWoood.Logic.SharedKernel.Interfaces;
using NHibernate;
using NHibernate.Multi;
using NHibernate.Criterion;
using NHibernate.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIWoood.Logic.Repositories
{
    public class SalesOrderShipmentRepository : IRepository<SalesOrderShipment, int>
    {
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public SalesOrderShipment GetById(int id)
        {
            throw new NotImplementedException();
        }

        public SalesOrderShipment GetBySkuId(string skuId)
        {
            using (ISession session = SessionFactory.GetNewSession("db2"))
            {
                var query = from u in session.Query<SalesOrderShipment>()
                            select u;

                query = query.Where(u => u.SkuId == skuId);

                var users = query.ToList();

                if (users.Count > 0)
                {
                    return query.ToList().Last();
                }
                else
                {
                    return null;
                }
            }
        }

        public void Insert(SalesOrderShipment entity)
        {
            using (ISession session = SessionFactory.GetNewSession("db2"))
            {
                using (ITransaction transaction = session.BeginTransaction())
                {

                    session.Save(entity);
                    transaction.Commit();
                }
            }
        }

        public PagedResult<SalesOrderShipment> List(string sortOrder, int pageSize = -1, int pageNumber = -1)
        {
            using (ISession session = SessionFactory.GetNewSession("db2"))
            {
                var criteria = session.CreateCriteria<SalesOrderShipment>();

                switch (sortOrder)
                {
                    case "ID_ASC":
                    default:
                        criteria.AddOrder(new Order("Id", true));
                        break;
                }

                var countCriteria = CriteriaTransformer.TransformToRowCount(criteria);

                criteria.SetMaxResults(pageSize)
                    .SetFirstResult((pageNumber - 1) * pageSize);

                var multi = session.CreateQueryBatch()
                    .Add<int>(countCriteria)
                    .Add<SalesOrderShipment>(criteria);

                var result = new PagedResult<SalesOrderShipment>();

                result.CurrentPage = pageNumber;

                result.PageSize = pageSize;

                result.RowCount = multi.GetResult<int>(0).Single();
                var pageCount = (double)result.RowCount / result.PageSize;

                result.PageCount = (int)Math.Ceiling(pageCount);

                result.Results = multi.GetResult<SalesOrderShipment>(1);

                return result;
            }
        }

        public IEnumerable<SalesOrderShipment> List()
        {
            throw new NotImplementedException();
        }

        public void Update(SalesOrderShipment entity)
        {
            using (ISession session = SessionFactory.GetNewSession("db2"))
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Update(entity);
                    transaction.Commit();
                }
            }
        }
    }
}
