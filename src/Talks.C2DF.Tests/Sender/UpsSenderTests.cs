using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Talks.C2DF.BetterAppLib.v2Features;
using Talks.C2DF.Interfaces;

namespace Talks.C2DF.Tests.Sender;

[TestClass]
public class UpsSenderTests
{
	Mock<IEncryptHelper> _cryptoMock;
	Mock<IAppLogger> _loggerMock;
	const string input = "this is the text to send to crypto";

	[TestInitialize]
	public void SetUp()
	{
		_cryptoMock = new Mock<IEncryptHelper>();
		_loggerMock = new Mock<IAppLogger>();
	}

	[TestMethod]
	public void _should_encrypt_before_sending()
	{
		_cryptoMock.Setup(x => x.Encrypt(It.Is<string>(s => s == input))).Verifiable();
		_loggerMock.Setup(x => x.Info(It.IsAny<string>())).Verifiable();

		var sut = new UpsSender(_cryptoMock.Object, _loggerMock.Object);
		sut.Send(input);

		_cryptoMock.Verify(x => x.Encrypt(It.Is<string>(s => s == input)), Times.Once);
		_loggerMock.Verify(x => x.Info(It.IsAny<string>()), Times.Once);
		_loggerMock.Verify(x => x.Error(It.IsAny<string>()), Times.Never);
	}

}
