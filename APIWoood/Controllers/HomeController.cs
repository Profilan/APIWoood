﻿using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace APIWoood.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (String.IsNullOrEmpty(User.Identity.GetUserId()))
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Dashboard");
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}