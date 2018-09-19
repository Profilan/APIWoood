using APIWoood.Logic.Models;
using APIWoood.Logic.Repositories;
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

        public UrlController()
        {
            urlRepository = new UrlRepository();
            userRepository = new UserRepository();
        }

        // GET: Url
        public ActionResult Index()
        {
            var loggedInUser = userRepository.GetById(Convert.ToInt32(User.Identity.GetUserId()));

            if (loggedInUser.Role == "admin")
            {
                var items = urlRepository.List();

                return View(items);
            }
            else
            {
                throw new Exception("You are not allowed to access this");
            }
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
