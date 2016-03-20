﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Drawing;
using Talks.PCL.SuperSpyLib;
using Talks.PCL.SuperSpyLib.Imp;
using Talks.PCL.SuperSpyLib.UI;

namespace Talks.CodeToDiFor.MVC5Web.Controllers
{
    public class HomeController : Controller
    {

        ISpyLogger logger;

        public HomeController() : this (new FakeSpyLogger())
        {
        }

        public HomeController(ISpyLogger logger)
        {
            this.logger = logger;
        }

        public ActionResult Index()
        {
            return View();
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

        public ActionResult Bond()
        {
        //    ISpyLogger logger = new SpyLogger();
            logger.Log("You are in the Home Controller, Bond Action");

            var model = new BondViewModel()
            {
                Title = "Secret Spy Page",
                Messages = logger.GetMessages()
            };

            return View(model);
        }
    }
}