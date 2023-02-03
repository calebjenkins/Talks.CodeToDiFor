using System;

namespace Talks.C2DF.NotSoSuperLib;

public class NotSoGreatConsoleApp
{
	public void Run()
	{
		ConsoleKey key = ConsoleKey.Enter;

		while (key != ConsoleKey.Spacebar)
		{
			var startColor = Console.ForegroundColor;

			Console.WriteLine(" ** Starting App ** Not so great lib **");
			Console.Write("Enter Message:");
			var msg = Console.ReadLine();

			Console.WriteLine();
			Console.WriteLine("Output:");
			Console.ForegroundColor = ConsoleColor.Red;

			var senderApp = new NotSoGreatSendingMicroApp();
			var result = senderApp.Send(msg);

			Console.ForegroundColor = startColor;

			Console.WriteLine();
			Console.WriteLine($"Result: {result.Price} ");
			Console.WriteLine($"    Price: {result.Price} ");
			Console.WriteLine($"    Message: {result.Message} ");
			Console.WriteLine($"    Result Message: {result.ResultMessage} ");


			Console.WriteLine(" ** Complete **");
			Console.WriteLine(" ** Space bar to Exit **");

			var kInfo = Console.ReadKey();
			key = kInfo.Key;

			Console.Clear();
		}
	}
}
