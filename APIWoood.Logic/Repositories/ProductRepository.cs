using APIWoood.Logic.Models;
using APIWoood.Logic.SharedKernel;
using APIWoood.Logic.SharedKernel.Interfaces;
using NHibernate;
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
    public class ProductRepository : RepositoryAbstract<Product, string>
    {
        public override void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public override Product GetById(string id)
        {
            using (ISession session = SessionFactory.GetNewSession("db2"))
            {
                var item = session.Get<Product>(id);

                return item;
            }
        }

        public override void Insert(Product entity)
        {
            throw new NotImplementedException();
        }

        public override PagedResult<Product> List(string sortOrder, int pageSize = -1, int pageNumber = -1)
        {
            using (ISession session = SessionFactory.GetNewSession("db2"))
            {
                var criteria = session.CreateCriteria<Product>();

                switch (sortOrder)
                {
                    case "ARTIKELCODE_ASC":
                    default:
                        criteria.AddOrder(new Order("ARTIKELCODE", true));
                        break;
                }

                var countCriteria = CriteriaTransformer.TransformToRowCount(criteria);

                criteria.SetMaxResults(pageSize)
                    .SetFirstResult((pageNumber - 1) * pageSize);

                var multi = session.CreateMultiCriteria()
                    .Add(countCriteria)
                    .Add(criteria)
                    .List();

                var result = new PagedResult<Product>();

                result.CurrentPage = pageNumber;

                result.PageSize = pageSize;

                result.RowCount = (int)((IList)multi[0])[0];
                var pageCount = (double)result.RowCount / result.PageSize;

                result.PageCount = (int)Math.Ceiling(pageCount);

                result.Results = ((IEnumerable)multi[1]).Cast<Product>().ToList();

                return result;
            }
        }

        public override IEnumerable<Product> List()
        {
            using (ISession session = SessionFactory.GetNewSession("db2"))
            {
                var query = session.Query<Product>();

                return query.ToList();
            }
        }

        public override void Update(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
