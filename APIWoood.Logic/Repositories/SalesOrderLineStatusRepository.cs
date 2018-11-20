using System;
using System.Collections.Generic;
using APIWoood.Logic.Models;
using APIWoood.Logic.SharedKernel;
using APIWoood.Logic.SharedKernel.Interfaces;
using NHibernate;

namespace APIWoood.Logic.Repositories
{
    public class SalesOrderLineStatusRepository : IRepository<SalesOrderLineStatus, int>
    {
        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public SalesOrderLineStatus GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Insert(SalesOrderLineStatus entity)
        {
            using (ISession session = SessionFactory.GetNewSession("db2"))
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    entity.SysCreated = DateTime.Now;

                    session.Save(entity);
                    transaction.Commit();
                }
            }
        }

        public PagedResult<SalesOrderLineStatus> List(string sortOrder, int pageSize = -1, int pageNumber = -1)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<SalesOrderLineStatus> List()
        {
            throw new System.NotImplementedException();
        }

        public void Update(SalesOrderLineStatus entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
