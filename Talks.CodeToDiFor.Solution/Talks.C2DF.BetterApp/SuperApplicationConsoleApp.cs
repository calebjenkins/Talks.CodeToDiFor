using System;
using System.Linq;
using Talks.C2DF.BetterApp.Lib;
using Talks.C2DF.Interfaces;

namespace Talks.C2DF.BetterApp
{
	public class SuperApplicationConsoleApp
	{

		readonly ISuperApplication _senderApp;
		readonly IWriter console;

		public SuperApplicationConsoleApp(ISuperApplication senderApp, IWriter writer)
		{
			_senderApp = senderApp ?? throw new ArgumentNullException(nameof(senderApp), $"{nameof(senderApp)} is null.");
			console = writer ?? throw new ArgumentNullException(nameof(writer), $"{nameof(writer)} is null.");
		}

		public void Run()
		{
			ConsoleKey key = ConsoleKey.Enter;

			while (key != ConsoleKey.Spacebar)
			{
				var startColor = Console.ForegroundColor;

				console.WriteLine(" ** Starting App ** DI Friendly Lib **");
				console.Write("Enter Message:");
				var msg = Console.ReadLine();

				console.WriteLine();
				console.WriteLine("Output:");
				Console.ForegroundColor = ConsoleColor.Blue;

				var result = _senderApp.Send(msg);

				Console.ForegroundColor = startColor;

				console.WriteLine();
				console.WriteLine($"Result: {result.Price} ");
				console.WriteLine($"    Price: {result.Price} ");
				console.WriteLine($"    Message: {result.Message} ");
				console.WriteLine($"    Result Message: {result.ResultMessage} ");


				console.WriteLine(" ** Complete **");
				console.WriteLine(" ** Space bar to Exit **");

				key = Console.ReadKey().Key;

				Console.Clear();
			}
		}
	}
}
