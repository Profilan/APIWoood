
using APIWoood.Logic.Models;
using APIWoood.Logic.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace APIWoood.Models
{
    public static class DashboardService
    {
        private static List<DataPoint> _dataPoints;

        public static List<DataPoint> GetTopFiveUrlsData(IEnumerable<Url> urls)
        {
            _dataPoints = new List<DataPoint>();

            foreach (var url in urls)
            {
                if (url.Hits > 0)
                {
                    _dataPoints.Add(new DataPoint(url.Hits, url.Name, url.Id));
                }
            }
            if (_dataPoints.Count > 0)
            {
                _dataPoints[0].Exploded = true;
            }

            return _dataPoints;
        }

        public static List<DataPoint> GetTopFiveUsersData(IEnumerable<UserViewModel> users)
        {
            _dataPoints = new List<DataPoint>();

            foreach (var user in users)
            {
                if (user.QuantityVisitedUrls > 0)
                {
                    _dataPoints.Add(new DataPoint(user.QuantityVisitedUrls, user.UserName, user.Id));
                }
            }
            if (_dataPoints.Count > 0)
            {
                _dataPoints[0].Exploded = true;
            }

            return _dataPoints;
        }

        public static List<DataPoint> GetUrlUsageData(IEnumerable<Url> urls)
        {
            _dataPoints = new List<DataPoint>();

            foreach (var url in urls)
            {
                if (url.Hits > 0)
                {
                    _dataPoints.Add(new DataPoint(url.Hits, url.Name, url.Id));
                }
            }

            return _dataPoints;
        }
    }
}