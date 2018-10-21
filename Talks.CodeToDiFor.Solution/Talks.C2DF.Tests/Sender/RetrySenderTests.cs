using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talks.C2DF.BetterAppLib.Logging;
using Talks.C2DF.BetterAppLib.v2Features;
using Talks.C2DF.ExternalLoggingLib;
using Talks.C2DF.Interfaces;

namespace Talks.C2DF.Tests.Sender
{
	[TestClass]
	public class RetrySenderTests
	{
		Mock<IMessageSender> _senderMock;
		Mock<IAppLogger> _logger;

		[TestInitialize]
		public void SetUp()
		{
			_senderMock = new Mock<IMessageSender>();
			_logger = new Mock<IAppLogger>();
		}

		[TestMethod]
		public void _should_forward_to_sender()
		{
			var input = "this is the text to send";
			_senderMock.Setup(x => x.Send(It.Is<string>(s => s == input))).Verifiable();

			var sut = new RetrySender(_logger.Object, _senderMock.Object);
			sut.Send(input);

			_senderMock.VerifyAll();
		}
	}
}
