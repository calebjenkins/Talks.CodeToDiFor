using System;
using System.Linq;
using Talks.C2DF.Interfaces;

namespace Talks.C2DF.NotSoSuperLib.Lib
{
	public class Sender: ISender
	{
		public void Send(string message)
		{
			var enx = new Encryptor();
			var xMsg = enx.Encrypt(message);

			Console.WriteLine("Sent: " + xMsg);
		}
	}
}
