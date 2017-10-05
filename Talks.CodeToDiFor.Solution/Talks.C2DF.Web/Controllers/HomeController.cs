using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Talks.C2DF.Interfaces;

namespace Talks.C2DF.Web.Controllers
{
	public class HomeController: Controller
	{

		readonly ISendingMicroApp sendingApp;

		public HomeController(ISendingMicroApp sendingApp)
		{
			this.sendingApp = sendingApp;
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
	}
}