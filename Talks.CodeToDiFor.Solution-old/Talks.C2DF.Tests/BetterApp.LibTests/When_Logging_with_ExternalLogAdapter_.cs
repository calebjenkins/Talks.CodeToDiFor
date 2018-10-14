using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Talks.C2DF.BetterApp.Lib;
using Talks.C2DF.BetterApp.Lib.Logging;
using Talks.C2DF.Interfaces.ExternalLibrary;

namespace Talks.C2DF.Tests.BetterAppLibTests
{
	[TestClass]
	public class When_Logging_with_ExternalLogAdapter_
	{
		Mock<ILogger> externalLoggerMock;
		const string expectedText = "Expected Message";

		private Mock<ILogger> getMock(LogType type, string message)
		{
			var lm = new Mock<ILogger>();
			lm.Setup(x => x.Enabled(It.Is<LogType>((lt) => lt == type))).Returns(true).Verifiable();
			lm.Setup(x => x.Log(It.Is<LogEntry>((le) => le.LogType == type && le.Message == message))).Verifiable();
			return lm;
		}

		[TestMethod]
		public void should_use_Debug_when_Debug()
		{
			externalLoggerMock = getMock(LogType.Debug, expectedText);
			var log = new ExternalLogAdapter(externalLoggerMock.Object);
			log.Debug(expectedText);
			externalLoggerMock.VerifyAll();
		}

		[TestMethod]
		public void should_use_Error_when_Error()
		{
			externalLoggerMock = getMock(LogType.Error, expectedText);
			var log = new ExternalLogAdapter(externalLoggerMock.Object);
			log.Error(expectedText);
			externalLoggerMock.VerifyAll();
		}

		[TestMethod]
		public void should_use_Info_when_Info()
		{
			externalLoggerMock = getMock(LogType.Info, expectedText);
			var log = new ExternalLogAdapter(externalLoggerMock.Object);
			log.Info(expectedText);
			externalLoggerMock.VerifyAll();
		}

		[TestMethod]
		public void should_use_Warn_when_Warn()
		{
			externalLoggerMock = getMock(LogType.Warn, expectedText);
			var log = new ExternalLogAdapter(externalLoggerMock.Object);
			log.Warn(expectedText);
			externalLoggerMock.VerifyAll();
		}

		[TestMethod]
		public void should_Not_use_Error_when_Info()
		{
			externalLoggerMock = new Mock<ILogger>();
			externalLoggerMock.Setup(x => x.Enabled(It.Is<LogType>((lt) => lt == LogType.Info))).Returns(true).Verifiable();
			externalLoggerMock.Setup(x => x.Log(It.Is<LogEntry>((le) => le.LogType == LogType.Info && le.Message == expectedText))).Verifiable();

			IAppLogger log = new ExternalLogAdapter(externalLoggerMock.Object);
			log.Info(expectedText);

			externalLoggerMock.Verify(x => x.Enabled(It.Is<LogType>((lt) => lt == LogType.Info)), Times.Once);
			externalLoggerMock.Verify(x => x.Enabled(It.Is<LogType>((lt) => lt == LogType.Warn)), Times.Never);
			externalLoggerMock.Verify(x => x.Enabled(It.Is<LogType>((lt) => lt == LogType.Error)), Times.Never);
			externalLoggerMock.Verify(x => x.Enabled(It.Is<LogType>((lt) => lt == LogType.Debug)), Times.Never);

			externalLoggerMock.VerifyAll();
		}
	}
}
