using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talks.C2DF.Interfaces;
using Moq;
using Talks.C2DF.Interfaces.Models;
using Talks.C2DF.BetterApp;
using Talks.C2DF.BetterApp.Lib.Logging;

namespace Talks.C2DF.Tests.BetterAppTests
{
	[TestClass]
	public class When_Send_with_SendingMicroApp_
	{
		[TestMethod]
		public void Should_call_cost_calculator()
		{
			var msg = "Hello World";
			var response = new SendResponse() { Message = msg, Price = 5, ResultMessage = "Success" };
			var costMock = new Mock<ICostCalculator>();
			costMock.Setup(x => x.CalculatePrice(It.Is<string>((str) => str == msg))).Returns(response.Price).Verifiable();

			var senderMock = new Mock<IMessageSender>();
			var loggerMock = new Mock<IAppLogger>();

			var sut = new SuperSendingMicroApp(costMock.Object, senderMock.Object, loggerMock.Object);
			var result = sut.Send(msg);

			Assert.IsTrue(result.Message == msg);
			Assert.IsTrue(result.Price == response.Price);
			costMock.VerifyAll();
		}

		[TestMethod]
		public void Should_call_messageSender()
		{
			var msg = "Hello World";
			var costMock = new Mock<ICostCalculator>();

			var senderMock = new Mock<IMessageSender>();
			senderMock.Setup(x => x.Send(It.Is<string>((str) => str == msg))).Verifiable();

			var loggerMock = new Mock<IAppLogger>();

			var sut = new SuperSendingMicroApp(costMock.Object, senderMock.Object, loggerMock.Object);
			var result = sut.Send(msg);

			Assert.IsTrue(result.Message == msg);
			senderMock.VerifyAll();
		}
	}
}
