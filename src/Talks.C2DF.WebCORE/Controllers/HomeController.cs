using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Talks.C2DF.ExternalLoggingLib;
using Talks.C2DF.Interfaces;
using Talks.C2DF.Models;
using Talks.C2DF.WebCORE.Models;

namespace Talks.C2DF.WebCORE.Controllers
{
	public class HomeController : Controller
	{

		ILogger _logger;
		IMessageSendingMicroApp _sendingApp;

		public HomeController(ILogger logger, IMessageSendingMicroApp sender)
		{
			_logger = logger ?? throw new NullReferenceException(nameof(Logger));
			_sendingApp = sender ?? throw new NullReferenceException(nameof(sender));
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

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}

		public ActionResult Send(string Text)
		{
			if (string.IsNullOrEmpty(Text))
			{
				_logger.Debug("Can not send Message from MVC App when text is empty");
				ViewBag.Message = $"No message to send";
				ViewBag.Logs = _logger.GetEntries();
				return View("send", new SendResponse());
			}

			_logger.Debug("Sending Message from MVC App");
			var result = _sendingApp.Send(Text);
			_logger.Debug($"Result: {result.ResultMessage} -- Price: {result.Price} -- Message: {result.Message} ");

			
			ViewBag.Message = $"Message Sent!";
			ViewBag.Logs = _logger.GetEntries();
			return View("send", result);
		}
	}
}
