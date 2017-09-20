using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talks.C2DF.NotSoSuperLib;
using Talks.C2DF.NotSoSuperLib.Lib;

namespace Talks.CodeToDiFor.ConsoleApp
{
	class Program
	{

	//	Application -> Sender -> Cost Calc -> Encrypter -> Send (with Retry)
	//  <- SendResponse

		static void Main(string[] args)
		{
			Console.WriteLine(" ** Starting App **");
			Console.Write("Enter Message:");
			var msg = Console.ReadLine();

			var senderApp = new NotSoGreatApp();
			var result = senderApp.Send(msg);


			Console.Write(" ** Complete **");
			Console.ReadLine();
		}
	}
}
