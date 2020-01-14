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
    public class PricelistRepository : IRepository<Pricelist, PricelistIdentifier>
    {
        public void Delete(PricelistIdentifier id)
        {
            throw new NotImplementedException();
        }

        public Pricelist GetById(PricelistIdentifier id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Pricelist entity)
        {
            throw new NotImplementedException();
        }

        public PagedResult<Pricelist> List(string sortOrder, int pageSize = 25, int pageNumber = 1)
        {
            using (ISession session = SessionFactory.GetNewSession("db2"))
            {
                var criteria = session.CreateCriteria<Pricelist>();

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
                    .Add<Pricelist>(criteria);

                var result = new PagedResult<Pricelist>();

                result.CurrentPage = pageNumber;

                result.PageSize = pageSize;

                result.RowCount = multi.GetResult<int>(0).Single();
                var pageCount = (double)result.RowCount / result.PageSize;

                result.PageCount = (int)Math.Ceiling(pageCount);

                result.Results = multi.GetResult<Pricelist>(1);

                return result;
            }
        }

        public IEnumerable<Pricelist> List()
        {
            using (ISession session = SessionFactory.GetNewSession("db2"))
            {
                var query = session.Query<Pricelist>();

                return query.ToList();
            }
        }

        public IEnumerable<Pricelist> ListByArticle(string artikelcode)
        {
            using (ISession session = SessionFactory.GetNewSession("db2"))
            {
                var query = from s in session.Query<Pricelist>()
                            select s;

                query = query.Where(s => s.PricelistIdentifier.ARTIKELCODE == artikelcode);

                return query.ToList();
            }
        }

        public IEnumerable<Pricelist> ListByDebtor(string debiteurnr)
        {
            using (ISession session = SessionFactory.GetNewSession("db2"))
            {
                var query = from s in session.Query<Pricelist>()
                            select s;

                query = query.Where(s => s.PricelistIdentifier.DEBITEURNR == debiteurnr);

                return query.ToList();
            }
        }

        public void Update(Pricelist entity)
        {
            throw new NotImplementedException();
        }
    }
}
