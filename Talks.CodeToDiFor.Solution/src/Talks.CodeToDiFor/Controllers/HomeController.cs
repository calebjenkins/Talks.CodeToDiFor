using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Talks.SuperSpyLib.UI;
using Talks.SuperSpyLib;

namespace Talks.CodeToDiFor.Controllers
{
    public class HomeController : Controller
    {
        IMessageSender sender;
        public HomeController(IMessageSender Sender)
        {
            sender = Sender;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        public IActionResult Bond()
        {
            var model = new BondViewModel()
            {
                Title = "Secret Spy Page",
            };

            model.Messages = sender.Send(model.Messages, "Save the World!");

            return View(model);
        }
    }
}
