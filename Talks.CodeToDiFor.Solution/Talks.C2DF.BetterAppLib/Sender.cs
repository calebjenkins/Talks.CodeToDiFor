using System;
using Talks.C2DF.Interfaces;
using Talks.C2DF.Interfaces.ExternalLibrary;

namespace Talks.C2DF.BetterApp.Lib
{
	public class Sender: ISender
	{
		IEncryptHelper _crypto;
		ILogger _logger;

		public Sender(IEncryptHelper crypto, ILogger logger)
		{
			_crypto = crypto;
			_logger = logger;
		}

		public void Send(string message)
		{
			var xMsg = _crypto.Encrypt(message);
			_logger.Info($"Message Sent: {xMsg}"); // Extension Methods from External Library
		}
	}
}
