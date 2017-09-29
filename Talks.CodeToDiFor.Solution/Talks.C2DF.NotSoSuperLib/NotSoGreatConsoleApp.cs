using System;
using System.Linq;

namespace Talks.C2DF.NotSoSuperLib
{
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
				Console.ForegroundColor = ConsoleColor.Blue;

				var senderApp = new NotSoGreatApp();
				var result = senderApp.Send(msg);

				Console.ForegroundColor = startColor;

				Console.WriteLine();
				Console.WriteLine($"Result: {result.Price} ");
				Console.WriteLine($"    Price: {result.Price} ");
				Console.WriteLine($"    Message: {result.Message} ");
				Console.WriteLine($"    Result Message: {result.ResultMessage} ");


				Console.WriteLine(" ** Complete **");
				Console.WriteLine(" ** Space bar to Exit **");

				key = Console.ReadKey().Key;

				Console.Clear();
			}
		}
	}
}
