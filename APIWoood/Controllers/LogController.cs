using APIWoood.Logic.Repositories;
using APIWoood.Logic.SharedKernel;
using APIWoood.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Web.Mvc;

namespace APIWoood.Controllers
{
    [Authorize]
    public class LogController : Controller
    {
        private readonly LogRepository _logRepository;
        private UserRepository userRepository;

        public LogController()
        {
            _logRepository = new LogRepository();
            userRepository = new UserRepository();
        }

        // GET: Log
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page, string startDate = null, string endDate = null, int userId = -1, ErrorType ErrorType = ErrorType.NONE)
        {
            var loggedInUser = userRepository.GetById(Convert.ToInt32(User.Identity.GetUserId()));

            if (loggedInUser.Role == "admin")
            {
                ViewBag.CurrentSort = sortOrder;
                ViewBag.TimestampSortParm = String.IsNullOrEmpty(sortOrder) ? "timestamp_desc" : "";
                // ViewBag.PrioritySortParm = sortOrder == "Date" ? "date_desc" : "Date";

                if (searchString != null)
                {
                    page = 1;
                }
                else
                {
                    searchString = currentFilter;
                }

                ViewBag.CurrentFilter = searchString;

                DateTime start, end;

                if (String.IsNullOrEmpty(startDate) || String.IsNullOrEmpty(endDate))
                {
                    var dateNow = DateTime.Now.AddMonths(-1);
                    start = DateTime.Now.AddMonths(-1).Date;
                    end = DateTime.Now.AddDays(1).Date;
                }
                else
                {
                    start = Convert.ToDateTime(startDate);
                    end = Convert.ToDateTime(endDate);
                }

                ViewBag.StartDate = start.ToString("yyyy-MM-dd");
                ViewBag.EndDate = end.ToString("yyyy-MM-dd");

                int pageSize = 25;
                int pageNumber = (page ?? 1);

                ViewBag.ErrorType = ErrorType;

                var logs = _logRepository.List(sortOrder, searchString, pageSize, pageNumber, start, end, userId, ErrorType);
                var users = userRepository.List();

                var viewModel = new LogListViewModel()
                {
                    Logs = logs,
                    Users = users,
                    UserId = userId
                };

                return View(viewModel);
            }
            else
            {
                throw new Exception("You are not allowed to access this");
            }
        }

        // GET: Log/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
    }
}
