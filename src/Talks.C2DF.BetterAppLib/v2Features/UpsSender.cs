using Talks.C2DF.Interfaces;

namespace Talks.C2DF.BetterAppLib.v2Features;

public class UpsSender : IMessageSender
{
	IEncryptHelper _crypto;
	IAppLogger _logger;

	public UpsSender(IEncryptHelper crypto, IAppLogger logger)
	{
		_crypto = crypto;
		_logger = logger;
	}

	public void Send(string message)
	{
		var xMsg = _crypto.Encrypt(message);
		_logger.Info($"Message Sent via UPS: {xMsg}"); // Extension Methods from External Library
	}
}
