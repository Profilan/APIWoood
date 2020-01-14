using APIWoood.Logic.Models;
using APIWoood.Logic.SharedKernel;
using APIWoood.Logic.SharedKernel.Interfaces;
using NHibernate;
using NHibernate.Multi;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIWoood.Logic.Repositories
{
    public class ProductRangeRepository : IRepository<ProductRange, ProductRangeIdentifier>
    {
        public void Delete(ProductRangeIdentifier id)
        {
            throw new NotImplementedException();
        }

        public ProductRange GetById(ProductRangeIdentifier id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductRange> ListByRange(int ass)
        {
            using (ISession session = SessionFactory.GetNewSession("db1"))
            {
                var query = from s in session.Query<ProductRange>()
                            select s;

                query = query.Where(s => s.ProductRangeIdentifier.ASS == ass);

                return query.ToList();
            }
        }

        public void Insert(ProductRange entity)
        {
            throw new NotImplementedException();
        }

        public PagedResult<ProductRange> List(string sortOrder, int pageSize = 25, int pageNumber = 1)
        {
            using (ISession session = SessionFactory.GetNewSession("db1"))
            {
                var criteria = session.CreateCriteria<ProductRange>();

                var countCriteria = CriteriaTransformer.TransformToRowCount(criteria);

                criteria.SetMaxResults(pageSize)
                    .SetFirstResult((pageNumber - 1) * pageSize);

                /*
                var multi = session.CreateMultiCriteria()
                    .Add(countCriteria)
                    .Add(criteria)
                    .List();
                    */
                var multi = session.CreateQueryBatch()
                    .Add<int>(countCriteria)
                    .Add<ProductRange>(criteria);

                var result = new PagedResult<ProductRange>();

                result.CurrentPage = pageNumber;

                result.PageSize = pageSize;

                result.RowCount = multi.GetResult<int>(0).Single();
                var pageCount = (double)result.RowCount / result.PageSize;

                result.PageCount = (int)Math.Ceiling(pageCount);

                result.Results = multi.GetResult<ProductRange>(1);

                return result;
            }
        }

        public IEnumerable<ProductRange> List()
        {
            using (ISession session = SessionFactory.GetNewSession("db1"))
            {
                var query = session.Query<ProductRange>();

              

                return query.ToList();
            }
        }

        public void Update(ProductRange entity)
        {
            throw new NotImplementedException();
        }
    }
}
