using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using Talks.C2DF.BetterAppLib.Logging;
using Talks.C2DF.BetterAppLib.v2Features;
using Talks.C2DF.Interfaces;

namespace Talks.C2DF.Tests.Sender
{
	[TestClass]
	public class RetrySenderTests
	{
		Mock<IMessageSender> _senderMock;
		Mock<IAppLogger> _logger;
		const string input = "this is the text to send";

		[TestInitialize]
		public void SetUp()
		{
			_senderMock = new Mock<IMessageSender>();
			_logger = new Mock<IAppLogger>();
		}

		[TestMethod]
		public void _should_forward_to_sender()
		{
			_senderMock.Setup(x => x.Send(It.Is<string>(s => s == input))).Verifiable();
			_logger.Setup(x => x.Info(It.IsAny<string>())).Verifiable();
			_logger.Setup(x => x.Error(It.IsAny<string>())).Verifiable();

			var sut = new RetrySender(_logger.Object, _senderMock.Object);
			sut.Send(input);

			_senderMock.Verify(x => x.Send(It.Is<string>(s => s == input)), Times.Once);
			_logger.Verify(x => x.Info(It.IsAny<string>()), Times.Exactly(2));
			_logger.Verify(x => x.Error(It.IsAny<string>()), Times.Never);
		}

		[TestMethod]
		public void _should_retry_3_times()
		{
			_senderMock.Setup(x => x.Send(It.Is<string>(s => s == input)))
			.Throws<Exception>()
			.Verifiable();
			
			var sut = new RetrySender(_logger.Object, _senderMock.Object);
			sut.Send(input);

			_senderMock.Verify(x => x.Send(It.Is<string>(s => s == input)), Times.Exactly(3));
		}

		[TestMethod]
		public void _should_log_on_retry()
		{
			_senderMock.Setup(x => x.Send(It.Is<string>(s => s == input)))
			.Throws<Exception>()
			.Verifiable();

			_logger.Setup(x => x.Info(It.IsAny<string>())).Verifiable();
			_logger.Setup(x => x.Error(It.IsAny<string>())).Verifiable();

			var sut = new RetrySender(_logger.Object, _senderMock.Object);
			sut.Send(input);

			_senderMock.Verify(x => x.Send(It.Is<string>(s => s == input)), Times.Exactly(3));
			_logger.Verify(x => x.Info(It.IsAny<string>()), Times.Exactly(4));
			_logger.Verify(x => x.Error(It.IsAny<string>()), Times.Once);
		}
	}
}
