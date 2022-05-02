using APIWoood.Logic.Models;
using APIWoood.Logic.SharedKernel;
using APIWoood.Logic.SharedKernel.Interfaces;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;

namespace APIWoood.Logic.Repositories
{
    public class ZwaluwSSCCRepository : IRepository<ZwaluwSSCC, int>
    {
        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public ZwaluwSSCC GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Insert(ZwaluwSSCC entity)
        {
            using (ISession session = SessionFactory.GetNewSession("db2"))
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    entity.SysCreated = DateTime.Now;
                    entity.SysModified = entity.SysCreated;

                    session.SaveOrUpdate(entity);
                    transaction.Commit();
                }
            }
        }

        public PagedResult<ZwaluwSSCC> List(string sortOrder, int pageSize = -1, int pageNumber = -1)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ZwaluwSSCC> List()
        {
            using (ISession session = SessionFactory.GetNewSession("db2"))
            {
                var query = session.Query<ZwaluwSSCC>();

                return query.ToList();
            }
        }

        public void Update(ZwaluwSSCC entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
