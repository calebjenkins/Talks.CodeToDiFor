using System;
using notThisWay = Talks.C2DF.NotSoSuperLib;

namespace Talks.CodeToDiFor.ConsoleApp
{
	class Program
	{

	//	Application -> Sender -> Cost Calc -> Encryptor -> Send (with Retry)
	//  <- SendResponse

		static void Main(string[] args)
		{
			TraditionalConsoleApp();
		}

		static void TraditionalConsoleApp()
		{
			var app = new notThisWay.NotSoGreatConsoleApp();
			app.Run();
		}

		static void CompositeRootConsoleApp()
		{
			
		}
	}
}
