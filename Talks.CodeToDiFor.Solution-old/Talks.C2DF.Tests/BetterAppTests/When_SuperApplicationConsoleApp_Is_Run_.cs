using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Talks.C2DF.BetterApp;
using Talks.C2DF.BetterApp.Lib.Console;
using Talks.C2DF.Interfaces;
using Talks.C2DF.Interfaces.Models;

namespace Talks.C2DF.Tests.BetterAppTests
{
	[TestClass]
	public class When_SuperApplicationConsoleApp_Is_Run_
	{

		const string ConsoleText = "Hello World";
		SendResponse response;

		[TestInitialize]
		public void SetUp()
		{
			response = new SendResponse()
			{
				Message = ConsoleText,
				Price = 10,
				ResultMessage = "success"
			};
		}


		[TestMethod]
		public void Should_ReadInputFrom_Console()
		{
			// set Up
			var consoleColor = ConsoleColor.White;

			var consoleMock = new Mock<IConsole>();
			consoleMock.SetupGet(x => x.ForegroundColor).Returns(consoleColor).Verifiable();
			consoleMock.SetupSet(x => x.ForegroundColor = consoleColor).Verifiable();
			consoleMock.Setup(x => x.ReadLine()).Returns(ConsoleText).Verifiable();
			consoleMock.Setup(x => x.ReadKey()).Returns(new ConsoleKeyInfo(' ', ConsoleKey.Spacebar, false, false, false));
			consoleMock.Setup(x => x.Clear()).Verifiable();
			consoleMock.Setup(x => x.WriteLine()).Verifiable();
			consoleMock.Setup(x => x.Write(It.IsAny<string>()));
			consoleMock.Setup(x => x.WriteLine(It.IsAny<string>()));

			var appMock = new Mock<ISendingMicroApp>();
			appMock.Setup(x => x.Send(It.Is<string>((value) => value == ConsoleText)))
			.Returns(response)
			.Verifiable();


			// Test
			var sut = new SuperApplicationConsoleApp(appMock.Object, consoleMock.Object);
			sut.Run();

			// Validate
			consoleMock.VerifyAll();
			appMock.Verify();

		}

		[TestMethod]
		public void Should_Use_Console_Cyan_for_LoggingColor()
		{
			// set Up
			var consoleColor = ConsoleColor.White;
			var ExpectedLogColor = ConsoleColor.Cyan;

			var consoleMock = new Mock<IConsole>();
			consoleMock.SetupGet(x => x.ForegroundColor).Returns(consoleColor).Verifiable();

			consoleMock.SetupSet(x => x.ForegroundColor = ExpectedLogColor).Verifiable();
			consoleMock.SetupSet(x => x.ForegroundColor = consoleColor).Verifiable();

			consoleMock.Setup(x => x.ReadLine()).Returns(ConsoleText).Verifiable();
			consoleMock.Setup(x => x.ReadKey()).Returns(new ConsoleKeyInfo(' ', ConsoleKey.Spacebar, false, false, false));

			var appMock = new Mock<ISendingMicroApp>();
			appMock.Setup(x => x.Send(It.Is<string>((value) => value == ConsoleText)))
			.Returns(response)
			.Verifiable();

			// Test
			var sut = new SuperApplicationConsoleApp(appMock.Object, consoleMock.Object);
			sut.Run();

			// Validate
			consoleMock.VerifyAll();
			appMock.Verify();

		}
	}
}
