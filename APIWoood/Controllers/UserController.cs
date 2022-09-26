using APIWoood.Logic.Models;
using APIWoood.Logic.Repositories;
using APIWoood.Logic.SharedKernel;
using APIWoood.Models;
using APIWoood.Models.Identity;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace APIWoood.Controllers
{
    public class UserController : Controller
    {
        private readonly UserRepository userRepository;
        private readonly DebtorRepository debtorRepository;
        private readonly UserDebtorRepository userDebtorRepository;
        private readonly UrlRepository urlRepository;

        public UserController()
        {
            userRepository = new UserRepository();
            debtorRepository = new DebtorRepository();
            userDebtorRepository = new UserDebtorRepository();
            urlRepository = new UrlRepository();
        }

        // GET: User
        [Authorize]
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var loggedInUser = userRepository.GetById(Convert.ToInt32(userId));

            if (loggedInUser.Role == "admin" || loggedInUser.Role == "guest")
            {
                var items = userRepository.List();

                var users = new List<UserViewModel>();
                foreach (var item in items)
                {
                    users.Add(new UserViewModel()
                    {
                        Id = item.Id,
                        UserName = item.UserName,
                        ApiKey = item.ApiKey,
                        Email = item.Email,
                        Role = item.Role,

                    });
                }

                return View(users);
            }
            else
            {
                throw new Exception("You are not allowed to access this");
            }
        }

        // GET: Url/Create
        [Authorize]
        public ActionResult Create()
        {
            var userId = User.Identity.GetUserId();
            var loggedInUser = userRepository.GetById(Convert.ToInt32(userId));

            if (loggedInUser.Role == "admin")
            {
                return View();
            }
            else
            {
                throw new Exception("You are not allowed to access this");
            }
        }

        // POST: User/Create
        [HttpPost]
        [Authorize]
        public ActionResult Create(FormCollection collection)
        {
            var userId = User.Identity.GetUserId();
            var loggedInUser = userRepository.GetById(Convert.ToInt32(userId));

            if (loggedInUser.Role == "admin")
            {
                try
                {
                    var debtors = collection["Debtors[]"].Split(',');
                    var urls = collection["Urls[]"].Split(',');
                    var user = new User();
                    user.SetCredentials(collection["Username"], collection["Password"]);
                    user.ApiKey = collection["ApiKey"];
                    user.AllowedIP = collection["AllowedIP"];
                    var role = (Role)Convert.ToInt32(collection["UserRole"]);
                    user.Role = role.ToString();
                    if (collection["Email"] != null)
                    {
                        user.Email = collection["Email"];
                    }
                    else
                    {
                        user.Email = "";
                    }

                    foreach (string debtorId in debtors)
                    {
                        if (!String.IsNullOrEmpty(debtorId))
                        {
                            var parts = debtorId.Split(' ');
                            var debtor = debtorRepository.GetById(parts[0]);
                            user.Debtors.Add(debtor);
                        }
                    }

                    foreach (string urlName in urls)
                    {
                        if (!String.IsNullOrEmpty(urlName))
                        {
                            var url = urlRepository.GetByName(urlName);
                            user.Urls.Add(url);
                        }
                    }
                    userRepository.Insert(user);

                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
            else
            {
                throw new Exception("You are not allowed to access this");
            }
        }

        // GET: User/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {
            var userId = User.Identity.GetUserId();
            var loggedInUser = userRepository.GetById(Convert.ToInt32(userId));

            if (loggedInUser.Role == "admin")
            {
                var item = userRepository.GetById(id);

                Role userRole;
                Enum.TryParse(item.Role, out userRole);

                var user = new UserViewModel()
                {
                    Id = item.Id,
                    UserName = item.UserName,
                    Email = item.Email,
                    UserRole = userRole,
                    ApiKey = item.ApiKey,
                    AllowedIP = item.AllowedIP,
                    Debtors = item.Debtors,
                    Urls = item.Urls,
                    Role = item.Role
                };

                return View(user);
            }
            else
            {
                throw new Exception("You are not allowed to access this");
            }
        }

        // POST: User/Edit/5
        [HttpPost]
        [Authorize]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var userId = User.Identity.GetUserId();
            var loggedInUser = userRepository.GetById(Convert.ToInt32(userId));

            if (loggedInUser.Role == "admin")
            {
                try
                {
                    var debtors = collection["Debtors[]"].Split(',');
                    var urls = collection["Urls[]"].Split(',');
                    var user = userRepository.GetById(id);
                    user.ApiKey = collection["ApiKey"];
                    user.AllowedIP = collection["AllowedIP"];
                    var role = (Role)Convert.ToInt32(collection["UserRole"]);
                    user.Role = role.ToString();
                    if (collection["Email"] != null)
                    {
                        user.Email = collection["Email"];
                    }
                    else
                    {
                        user.Email = "";
                    }

                    user.Debtors.Clear();
                    foreach (string debtorId in debtors)
                    {
                        if (!String.IsNullOrEmpty(debtorId))
                        {
                            var parts = debtorId.Split(' ');
                            var debtor = debtorRepository.GetById(parts[0]);
                            user.Debtors.Add(debtor);
                        }
                    }

                    user.Urls.Clear();
                    foreach (string urlName in urls)
                    {
                        if (!String.IsNullOrEmpty(urlName))
                        {
                            var url = urlRepository.GetByName(urlName);
                            user.Urls.Add(url);
                        }
                    }

                    userRepository.Update(user);

                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
            else
            {
                throw new Exception("You are not allowed to access this");
            }
        }

        [Authorize]
        public ActionResult ChangePassword(int id)
        {
            var userId = User.Identity.GetUserId();
            var loggedInUser = userRepository.GetById(Convert.ToInt32(userId));

            if (loggedInUser.Role == "admin")
            {
                var item = userRepository.GetById(id);

                var model = new PasswordViewModel()
                {
                    Id = item.Id
                };

                return View(model);
            }
            else
            {
                throw new Exception("You are not allowed to access this");
            }
        }

        [HttpPost]
        [Authorize]
        public ActionResult ChangePassword(int id, FormCollection collection)
        {
            var userId = User.Identity.GetUserId();
            var loggedInUser = userRepository.GetById(Convert.ToInt32(userId));

            if (loggedInUser.Role == "admin")
            {
                try
                {
                    var user = userRepository.GetById(id);
                    user.SetPassword(collection["Password1"]);

                    userRepository.Update(user);

                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
            else
            {
                throw new Exception("You are not allowed to access this");
            }
        }

        [Authorize]
        public ActionResult UrlVisits(int userId, int urlId, Period period = Period.month)
        {
            var urlRep = new UrlRepository();
            var url = urlRep.GetById(urlId);

            var logRep = new LogRepository();
            var logs = logRep.ListByUserAndUrl(userId, url.Name, period).OrderByDescending(x => x.TimeStamp);

            var histRep = new HistoryRepository();
            var history = histRep.ListByUserAndUrl(userId, url.Id, period);

            var viewModel = new LogViewModel()
            {
                Users = userRepository.List(),
                Visits = logs,
                VisitsOld = history,
                Urls = urlRep.List(),
                UrlId = urlId,
                UserId = userId,
                Period = period,
            };

            return View(viewModel);
        }
    }
}
