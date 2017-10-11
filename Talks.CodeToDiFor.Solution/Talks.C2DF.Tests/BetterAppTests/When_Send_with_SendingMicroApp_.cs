using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Talks.C2DF.Interfaces;
using Talks.C2DF.Interfaces.Models;
using Talks.C2DF.BetterApp;
using Talks.C2DF.BetterApp.Lib.Logging;

namespace Talks.C2DF.Tests.BetterAppTests
{
	[TestClass]
	public class When_Send_with_SendingMicroApp_
	{

		const string msg = "Hello World";

		[TestMethod]
		public void Should_call_cost_calculator()
		{
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
			var costMock = new Mock<ICostCalculator>();

			var senderMock = new Mock<IMessageSender>();
			senderMock.Setup(x => x.Send(It.Is<string>((str) => str == msg))).Verifiable();

			var loggerMock = new Mock<IAppLogger>();

			var sut = new SuperSendingMicroApp(costMock.Object, senderMock.Object, loggerMock.Object);
			var result = sut.Send(msg);

			Assert.IsTrue(result.Message == msg);
			senderMock.VerifyAll();
		}

		[TestMethod]
		public void should_log_exceptions()
		{
			var costMock = new Mock<ICostCalculator>();
			var senderMock = new Mock<IMessageSender>();
			senderMock.Setup(x => x.Send(It.IsAny<string>())).Throws(new Exception("TestException"));

			var loggerMock = new Mock<IAppLogger>();
			loggerMock.Setup(x => x.Error(It.Is<string>((str) => str.Contains("TestException")))).Verifiable();

			var sut = new SuperSendingMicroApp(costMock.Object, senderMock.Object, loggerMock.Object);
			var result = sut.Send(msg);

			Assert.IsTrue(result.Message == string.Empty);
			Assert.IsTrue(result.ResultMessage == "Fail");

			loggerMock.VerifyAll();
		}
	}
}
