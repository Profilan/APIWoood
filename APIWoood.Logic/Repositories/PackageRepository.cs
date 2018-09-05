using APIWoood.Logic.Models;
using APIWoood.Logic.SharedKernel;
using APIWoood.Logic.SharedKernel.Interfaces;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIWoood.Logic.Repositories
{
    public class PackageRepository : RepositoryAbstract<Package, string>
    {
        public override void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public override Package GetById(string id)
        {
            throw new NotImplementedException();
        }

        public override void Insert(Package entity)
        {
            throw new NotImplementedException();
        }

        public override PagedResult<Package> List(string sortOrder, int pageSize = -1, int pageNumber = -1)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Package> List()
        {
            using (ISession session = SessionFactory.GetNewSession("db2"))
            {
                var query = session.Query<Package>();

                return query.ToList();
            }
        }

        public IEnumerable<Package> ListByArtikelCode(string artikelCode)
        {
            using (ISession session = SessionFactory.GetNewSession("db2"))
            {
                var query = from i in session.Query<Package>()
                            select i;

                query = query.Where(i => i.ARTIKELCODE == artikelCode);

                return query.ToList();
            }
        }

        public override void Update(Package entity)
        {
            throw new NotImplementedException();
        }
    }
}
