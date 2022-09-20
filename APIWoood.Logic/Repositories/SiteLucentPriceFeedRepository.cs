using APIWoood.Logic.Helpers;
using APIWoood.Logic.Models;
using APIWoood.Logic.SharedKernel;
using APIWoood.Logic.SharedKernel.Interfaces;
using NHibernate;
using System;
using System.Collections.Generic;

namespace APIWoood.Logic.Repositories
{
    public class SiteLucentPriceFeedRepository : IRepository<SiteLucentPriceFeed, string>
    {
        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public SiteLucentPriceFeed GetById(string id)
        {
            throw new NotImplementedException();
        }

        public void Insert(SiteLucentPriceFeed entity)
        {
            throw new NotImplementedException();
        }

        public PagedResult<SiteLucentPriceFeed> List(string sortOrder, int pageSize = -1, int pageNumber = -1)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SiteLucentPriceFeed> List()
        {
            using (ISession session = SessionFactory.GetNewSession("db2"))
            {
                var executor = new HibernateStoredProcedureExecutor(session);
                var items = executor.ExecuteStoredProcedure<SiteLucentPriceFeed>(
                    "GetSiteLucentPriceFeed");

                return items;
            }
        }
        public void Update(SiteLucentPriceFeed entity)
        {
            throw new NotImplementedException();
        }
    }
}
