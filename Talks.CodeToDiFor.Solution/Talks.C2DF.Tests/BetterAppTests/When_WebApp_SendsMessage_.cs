using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Talks.C2DF.BetterApp.Lib.Logging;
using Talks.C2DF.Interfaces;
using Talks.C2DF.Interfaces.Models;
using Talks.C2DF.Web.Controllers;

namespace Talks.C2DF.Tests.BetterAppTests
{
	[TestClass]
	public class When_WebApp_SendsMessage_
	{

		[TestMethod]
		public void should_Send_proper_text_to_senderMicroApp()
		{
			var exampleText = "HelloWorld";
			var response = new SendResponse() { Message = exampleText, Price = 10, ResultMessage = "Success" };

			var sendingAppMock = new Mock<ISendingMicroApp>();
			sendingAppMock.Setup(x => x.Send(It.Is<string>((str) => str == exampleText))).Returns(response).Verifiable();
			var loggerMock = new Mock<IAppLogger>();

			var sut = new HomeController(sendingAppMock.Object, loggerMock.Object);
			var result = sut.Send(exampleText);

			sendingAppMock.VerifyAll();
			Assert.IsTrue((result as ViewResult).ViewName == "index");
		}
	}
}
