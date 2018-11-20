using APIWoood.Logic.Models;
using APIWoood.Logic.Repositories;
using APIWoood.Logic.SharedKernel;
using APIWoood.Models;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace APIWoood.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly UrlRepository urlRepository;
        private readonly LogRepository logRepository;
        private readonly HistoryRepository histRepository;
        private readonly UserRepository userRepository = new UserRepository();

        JsonSerializerSettings _jsonSetting = new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore };

        public DashboardController()
        {

            urlRepository = new UrlRepository();
            logRepository = new LogRepository();
            histRepository = new HistoryRepository();
        }

        // GET: Dashboard
        public ActionResult Index(Period period = Period.month)
        {

            // Get the top 5 url's
            var urlViewModelList = new List<Url>();
            var urls = urlRepository.List();
            foreach (var url in urls)
            {
                var logs = logRepository.ListByUrl(url.Name, period);
                if (logs.Count() > 0)
                {
                    var urlViewModel = new Url()
                    {
                        Name = url.Name,
                        Hits = logs.Count(),
                        Id = url.Id
                    };
                    urlViewModelList.Add(urlViewModel);
                }
            }
            var topFiveUrls = urlViewModelList.OrderByDescending(x => x.Hits).Take(5);

            // Get the top 5 users
            var users = userRepository.List();
            var userViewModelList = new List<UserViewModel>();
            foreach (var user in users)
            {
                var logs = logRepository.ListByUser(user.Id, period);
                var userViewModel = new UserViewModel()
                {
                    UserName = user.UserName,
                    Id = user.Id,
                    QuantityVisitedUrls = logs.Count()
                };
                userViewModelList.Add(userViewModel);
            }
            var topFiveUsers = userViewModelList.OrderByDescending(x => x.QuantityVisitedUrls).Take(5);

            // Get the url usage (Live)
            var usageUrls = urlRepository.List().OrderBy(x => x.Hits);

            // Get the laters errors
            
            var logErrors = new List<UrlViewModel>();
            foreach (var url in urls)
            {
                var logs = logRepository.List(period, ErrorType.ERR, url.Name);
                if (logs.Count() > 0)
                {
                    var logViewModel = new UrlViewModel()
                    {
                        Name = url.Name,
                        ErrorCount = logs.Count()
                    };
                    logErrors.Add(logViewModel);
                }
            }

            var viewModel = new DashboardViewModel()
            {
                TopFiveUrlsData = JsonConvert.SerializeObject(DashboardService.GetTopFiveUrlsData(topFiveUrls), _jsonSetting),
                TopFiveUsersData = JsonConvert.SerializeObject(DashboardService.GetTopFiveUsersData(topFiveUsers), _jsonSetting),
                UrlUsageData = JsonConvert.SerializeObject(DashboardService.GetUrlUsageData(usageUrls), _jsonSetting),
                Period = period,
                LogErrors = logErrors
            };

            return View(viewModel);
        }

         public ActionResult UserStatistics(int id, Period period = Period.month, string sortOrder = "NameAsc")
         {

            ViewBag.CurrentSort = sortOrder;

            var urls = urlRepository.List().OrderBy(x => x.Name);
            var visitedUrls = new List<UrlViewModel>();
            foreach (var url in urls)
            {
                var logs = logRepository.ListByUserAndUrl(id, url.Name, period);
                var history = histRepository.ListByUserAndUrl(id, url.Id, period);
                if (logs.Count() > 0 || history.Count() > 0)
                {
                    double totalDuration = 0;
                    foreach (var log in logs)
                    {
                        totalDuration += log.Duration;
                    }
                    
                    var visitedUrl = new UrlViewModel()
                    {
                        Id = url.Id,
                        Name = url.Name,
                        Hits = logs.Count(),
                        HitsOld = history.Count(),
                        Duration = totalDuration / logs.Count(),
                        LatestVisitDate = logs.Count() > 0 ? logs.First().TimeStamp.ToString() : "",
                        LatestVisitDateOld = history.Count() > 0 ? history.First().HistoryIdentifier.Date.ToString() : ""
                    };
                    visitedUrls.Add(visitedUrl);
                }
            }

            var sortedUrls = new List<UrlViewModel>();
            switch (sortOrder)
            {
                case "NameAsc":
                    sortedUrls = visitedUrls.OrderBy(x => x.Name).ToList();
                    break;
                case "LatestVisitDateDesc":
                    sortedUrls = visitedUrls.OrderByDescending(x => x.LatestVisitDate).ToList();
                    break;
                case "HitsDesc":
                    sortedUrls = visitedUrls.OrderByDescending(x => x.Hits).ToList();
                    break;
                case "DurationDesc":
                    sortedUrls = visitedUrls.OrderByDescending(x => x.Duration).ToList();
                    break;
            }

            var users = userRepository.List();

            var viewModel = new UserStatisticsViewModel()
            {
                Id = id,
                Users = users,
                Period = period,
                VisitedUrls = sortedUrls
            };

            return View(viewModel);
        }
    }
}