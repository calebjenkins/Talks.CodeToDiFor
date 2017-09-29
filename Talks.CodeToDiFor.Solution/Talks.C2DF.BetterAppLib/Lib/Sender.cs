using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talks.C2DF.Interfaces;

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
			_logger.Info($"Message Sent: {xMsg}");
		}
	}
}
