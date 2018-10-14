using System;
using Talks.C2DF.ExternalLoggingLib;
using Talks.C2DF.Interfaces;

namespace Talks.C2DF.NotSoSuperLib.Lib
{
	public class Sender : IMessageSender
	{
		ILogger logger;
		public Sender()
		{
			logger = new Logger();
		}
		public void Send(string message)
		{
			logger.Info("Entering Sender");
			var enx = new Encryptor();
			var xMsg = enx.Encrypt(message);

			Console.WriteLine("Sent: " + xMsg);
		}
	}
}
