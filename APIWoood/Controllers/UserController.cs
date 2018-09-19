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

        public UserController()
        {
            userRepository = new UserRepository();
            debtorRepository = new DebtorRepository();
            userDebtorRepository = new UserDebtorRepository();
        }

        // GET: User
        [Authorize]
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var loggedInUser = userRepository.GetById(Convert.ToInt32(userId));

            if (loggedInUser.Role == "admin")
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
                    var user = new User();
                    user.SetCredentials(collection["Username"], collection["Password"]);
                    user.ApiKey = collection["ApiKey"];
                    user.AllowedIP = collection["AllowedIP"];
                    user.Role = collection["UserRole"];
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
                        var parts = debtorId.Split(' ');
                        var debtor = debtorRepository.GetById(parts[0]);
                        user.Debtors.Add(debtor);
                    }

                    userRepository.Insert(user);

                    return RedirectToAction("Index");
                }
                catch (Exception e)
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

                IList<string> selectedDebtors = new List<string>();
                var userDebtors = userDebtorRepository.ListByUserId(id);

                foreach (var userDebtor in userDebtors)
                {
                    var debtor = debtorRepository.GetById(userDebtor.UserDebtorIdentifier.DEBITEURNR);
                    selectedDebtors.Add(debtor.DEBITEURNR + " " + debtor.NAAM);
                }

                var user = new UserViewModel()
                {
                    Id = item.Id,
                    UserName = item.UserName,
                    Email = item.Email,
                    UserRole = userRole,
                    ApiKey = item.ApiKey,
                    AllowedIP = item.AllowedIP,
                    SelectedDebtors = selectedDebtors,
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
                    // TODO: Add update logic here

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
    }
}
