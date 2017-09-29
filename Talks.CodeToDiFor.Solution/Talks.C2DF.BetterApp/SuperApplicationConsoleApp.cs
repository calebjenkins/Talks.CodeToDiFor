using System;
using System.Linq;
using Talks.C2DF.BetterApp.Lib.Console;
using Talks.C2DF.Interfaces;

namespace Talks.C2DF.BetterApp
{
	public class SuperApplicationConsoleApp
	{

		readonly ISuperApplication _senderApp;
		readonly IConsole console;

		public SuperApplicationConsoleApp(ISuperApplication senderApp, IConsole consuleWriter)
		{
			_senderApp = senderApp ?? throw new ArgumentNullException(nameof(senderApp), $"{nameof(senderApp)} is null.");
			console = consuleWriter ?? throw new ArgumentNullException(nameof(consuleWriter), $"{nameof(consuleWriter)} is null.");
		}

		public void Run()
		{
			ConsoleKey key = ConsoleKey.Enter;

			while (key != ConsoleKey.Spacebar)
			{
				var startColor = console.ForegroundColor;

				console.WriteLine(" ** Starting App ** DI Friendly Lib **");
				console.Write("Enter Message:");
				var msg = console.ReadLine();

				console.WriteLine();
				console.WriteLine("Output:");
				console.ForegroundColor = ConsoleColor.Blue;

				var result = _senderApp.Send(msg);

				console.ForegroundColor = startColor;

				console.WriteLine();
				console.WriteLine($"Result: {result.Price} ");
				console.WriteLine($"    Price: {result.Price} ");
				console.WriteLine($"    Message: {result.Message} ");
				console.WriteLine($"    Result Message: {result.ResultMessage} ");


				console.WriteLine(" ** Complete **");
				console.WriteLine(" ** Space bar to Exit **");

				key = console.ReadKey().Key;

				console.Clear();
			}
		}
	}
}
