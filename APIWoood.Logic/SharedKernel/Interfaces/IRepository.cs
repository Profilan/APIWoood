using APIWoood.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIWoood.Logic.SharedKernel.Interfaces
{
    public interface IRepository<TEntity, TId>
    {
        PagedResult<TEntity> List(string sortOrder, int pageSize = -1, int pageNumber = -1);
        IEnumerable<TEntity> List();
        TEntity GetById(TId id);
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(TId id);
    }
}
