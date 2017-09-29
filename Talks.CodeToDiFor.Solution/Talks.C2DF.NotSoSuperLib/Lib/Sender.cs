using System;
using System.Linq;
using Talks.C2DF.Interfaces;
using Talks.C2DF.Interfaces.ExternalLibrary;

namespace Talks.C2DF.NotSoSuperLib.Lib
{
	public class Sender: ISender
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
