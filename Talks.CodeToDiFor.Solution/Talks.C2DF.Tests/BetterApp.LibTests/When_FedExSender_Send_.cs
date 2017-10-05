using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Talks.C2DF.BetterApp.Lib;
using Talks.C2DF.BetterApp.Lib.Logging;
using Talks.C2DF.Interfaces;

namespace Talks.C2DF.Tests.BetterAppLibTests
{
	[TestClass]
	public class When_FedExSender_Send_
	{
		const string expectedText = "Hello World";
		const string cryptoText = "ENCRYPTED_TEXT";

		[TestMethod]
		public void Should_Encrypt_First()
		{
			var cryptoMock = new Mock<IEncryptHelper>();
			cryptoMock.Setup(x => x.Encrypt(It.Is<string>((str) => str == expectedText))).Returns(cryptoText).Verifiable();

			var loggerMock = new Mock<IAppLogger>();

			var sut = new FedExSender(cryptoMock.Object, loggerMock.Object);
			sut.Send(expectedText);

			cryptoMock.VerifyAll();
		}

		[TestMethod]
		public void Should_Log_Crypto_Text()
		{
			var cryptoMock = new Mock<IEncryptHelper>();
			cryptoMock.Setup(x => x.Encrypt(It.Is<string>((str) => str == expectedText))).Returns(cryptoText).Verifiable();

			var loggerMock = new Mock<IAppLogger>();
			loggerMock.Setup(x => x.Info(It.Is<string>((str) => str.Contains(cryptoText)))).Verifiable();

			var sut = new FedExSender(cryptoMock.Object, loggerMock.Object);
			sut.Send(expectedText);

			cryptoMock.VerifyAll();
			loggerMock.VerifyAll();
		}
	}
}
