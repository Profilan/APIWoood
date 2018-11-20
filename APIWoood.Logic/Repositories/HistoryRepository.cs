using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIWoood.Logic.Models;
using APIWoood.Logic.SharedKernel;
using APIWoood.Logic.SharedKernel.Interfaces;
using NHibernate;

namespace APIWoood.Logic.Repositories
{
    public class HistoryRepository : IRepository<History, HistoryIdentifier>
    {
        public void Delete(HistoryIdentifier id)
        {
            throw new NotImplementedException();
        }

        public History GetById(HistoryIdentifier id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<History> ListByUserId(int userId, Period period = Period.month)
        {
            using (ISession session = SessionFactory.GetNewSession("db2"))
            {
                var query = from h in session.Query<History>()
                            select h;

                query = query.Where(h => h.HistoryIdentifier.UserId == userId);

                var dateNow = DateTime.Now;
                var dateBefore = dateNow.AddDays(-30);

                switch (period)
                {
                    case Period.hour:
                        dateBefore = dateNow.AddHours(-1);
                        break;
                    case Period.day:
                        dateBefore = dateNow.AddDays(-1);
                        break;
                    case Period.week:
                        dateBefore = dateNow.AddDays(-7);
                        break;
                }
                query = query.Where(h => h.HistoryIdentifier.Date >= dateBefore && h.HistoryIdentifier.Date <= dateNow);

                query.OrderByDescending(h => h.HistoryIdentifier.Date);

                return query.ToList();
            }
        }

        public IEnumerable<History> ListByUrlId(int urlId, Period period = Period.month)
        {
            using (ISession session = SessionFactory.GetNewSession("db2"))
            {
                var query = from h in session.Query<History>()
                            select h;

                query = query.Where(h => h.HistoryIdentifier.UrlId == urlId);

                var dateNow = DateTime.Now;
                var dateBefore = dateNow.AddDays(-30);

                switch (period)
                {
                    case Period.hour:
                        dateBefore = dateNow.AddHours(-1);
                        break;
                    case Period.day:
                        dateBefore = dateNow.AddDays(-1);
                        break;
                    case Period.week:
                        dateBefore = dateNow.AddDays(-7);
                        break;
                }
                query = query.Where(h => h.HistoryIdentifier.Date >= dateBefore && h.HistoryIdentifier.Date <= dateNow);

                query.OrderByDescending(h => h.HistoryIdentifier.Date);

                return query.ToList();
            }
        }

        public IEnumerable<History> ListByUserAndUrl(int userId, int urlId, Period period = Period.month)
        {
            using (ISession session = SessionFactory.GetNewSession("db2"))
            {
                var query = from h in session.Query<History>()
                            select h;

                query = query.Where(h => h.HistoryIdentifier.UserId == userId && h.HistoryIdentifier.UrlId == urlId);

                var dateNow = DateTime.Now;
                var dateBefore = dateNow.AddDays(-30);

                switch (period)
                {
                    case Period.hour:
                        dateBefore = dateNow.AddHours(-1);
                        break;
                    case Period.day:
                        dateBefore = dateNow.AddDays(-1);
                        break;
                    case Period.week:
                        dateBefore = dateNow.AddDays(-7);
                        break;
                }
                query = query.Where(h => h.HistoryIdentifier.Date >= dateBefore && h.HistoryIdentifier.Date <= dateNow);

                query.OrderByDescending(h => h.HistoryIdentifier.Date);

                return query.ToList();
            }
        }

        public void Insert(History entity)
        {
            throw new NotImplementedException();
        }

        public PagedResult<History> List(string sortOrder, int pageSize = -1, int pageNumber = -1)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<History> List()
        {
            throw new NotImplementedException();
        }

        public void Update(History entity)
        {
            throw new NotImplementedException();
        }
    }
}
