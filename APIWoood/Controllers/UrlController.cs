using APIWoood.Logic.Models;
using APIWoood.Logic.Repositories;
using APIWoood.Logic.SharedKernel;
using APIWoood.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace APIWoood.Controllers
{
    [Authorize]
    public class UrlController : Controller
    {
        private readonly UrlRepository urlRepository;
        private readonly UserRepository userRepository;
        private readonly LogRepository logRepository;
        private readonly HistoryRepository histRepository;

        public UrlController()
        {
            urlRepository = new UrlRepository();
            userRepository = new UserRepository();
            logRepository = new LogRepository();
            histRepository = new HistoryRepository();
        }

        // GET: Url
        public ActionResult Index()
        {
            var loggedInUser = userRepository.GetById(Convert.ToInt32(User.Identity.GetUserId()));

            if (loggedInUser.Role == "admin" || loggedInUser.Role == "guest")
            {
                var items = urlRepository.List();

                return View(items);
            }
            else
            {
                throw new Exception("You are not allowed to access this");
            }
        }

        public ActionResult Details(int id, Period period = Period.month)
        {
            var url = urlRepository.GetById(id);

            var visitors = new List<UserViewModel>();

            var users = userRepository.List();
            foreach (var user in users)
            {
                var logs = logRepository.ListByUserAndUrl(user.Id, url.Name, period);
                var history = histRepository.ListByUserAndUrl(user.Id, url.Id, period);
                if (logs.Count() > 0 || history.Count() > 0)
                {
                    double duration = 0;
                    foreach (var log in logs)
                    {
                        duration += log.Duration;
                    }
                    var visitor = new UserViewModel()
                    {
                        Id = user.Id,
                        UserName = user.UserName,
                        QuantityVisitedUrls = logs.Count(),
                        QuantityVisitedUrlsOld = history.Count(),
                        LatestVisitDate = logs.Count() > 0 ? logs.Last().TimeStamp.ToString() : "",
                        LatestVisitDateOld = history.Count() > 0 ? history.Last().HistoryIdentifier.Date.ToString() : "",
                        Duration = duration / logs.Count()
                    };
                    visitors.Add(visitor);
                }
            }

            var viewModel = new UrlStatisticsViewModel()
            {
                Id = url.Id,
                Urls = urlRepository.List(),
                Period = period,
                Visitors = visitors
            };

            return View(viewModel);
        }

        // GET: Url/Create
        public ActionResult Create()
        {
            var loggedInUser = userRepository.GetById(Convert.ToInt32(User.Identity.GetUserId()));

            if (loggedInUser.Role == "admin")
            {
                return View();
            }
            else
            {
                throw new Exception("You are not allowed to access this");
            }
        }

        // POST: Url/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                var item = new Url()
                {
                    Name = collection["Name"],
                    Hits = 0
                };

                urlRepository.Insert(item);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Url/Edit/5
        public ActionResult Edit(int id)
        {
            var item = urlRepository.GetById(id);

            return View(item);
         }

        // POST: Url/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Url/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Url/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
