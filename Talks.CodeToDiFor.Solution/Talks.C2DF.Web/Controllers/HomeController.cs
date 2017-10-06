using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Talks.C2DF.BetterApp.Lib.Logging;
using Talks.C2DF.Interfaces;

namespace Talks.C2DF.Web.Controllers
{
	public class HomeController: Controller
	{

		ISendingMicroApp sendingApp;
		IAppLogger _logger;

		public HomeController(ISendingMicroApp sendingApp, IAppLogger logger)
		{
			this.sendingApp = sendingApp;
			_logger = logger;
		}

		public ActionResult Index()
		{
			_logger.Debug("Sending Message from MVC App");
			var result = sendingApp.Send("Hello World!!!DEAL");

			_logger.Debug($"Result: {result.ResultMessage} -- Price: {result.Price} -- Message: {result.Message} ");

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
	}
}