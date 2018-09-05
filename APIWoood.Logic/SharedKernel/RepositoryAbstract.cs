using APIWoood.Logic.Models;
using APIWoood.Logic.SharedKernel.Interfaces;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIWoood.Logic.SharedKernel
{
    public abstract class RepositoryAbstract<TEntity, TId> : IRepository<TEntity, TId>
    {
        public abstract void Delete(TId id);

        public abstract TEntity GetById(TId id);

        public abstract void Insert(TEntity entity);

        public abstract PagedResult<TEntity> List(string sortOrder, int pageSize = -1, int pageNumber = -1);

        public abstract IEnumerable<TEntity> List();

        public abstract void Update(TEntity entity);
    }
}
