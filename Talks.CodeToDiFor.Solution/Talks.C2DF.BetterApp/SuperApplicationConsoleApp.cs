using System;
using Talks.C2DF.BetterAppLib.Console;
using Talks.C2DF.BetterAppLib.Logging;
using Talks.C2DF.Interfaces;
using Talks.C2DF.Models;

namespace Talks.C2DF.BetterApp
{
	public class SuperApplicationConsoleApp
	{

		readonly IMessageSendingMicroApp _senderApp;
		readonly IConsole _console;

		public SuperApplicationConsoleApp(IMessageSendingMicroApp senderApp, IConsole consoleWriter)
		{
			_senderApp = senderApp ?? throw new ArgumentNullException(nameof(senderApp), $"{nameof(senderApp)} is null.");
			_console = consoleWriter ?? throw new ArgumentNullException(nameof(consoleWriter), $"{nameof(consoleWriter)} is null.");
		}

		public void Run()
		{
			ConsoleKey key = ConsoleKey.Enter;

			while (key != ConsoleKey.Spacebar)
			{
				var startColor = _console.ForegroundColor;

				_console.WriteLine(" ** Starting App ** DI Friendly Lib **");
				_console.Write("Enter Message:");
				var msg = _console.ReadLine();

				_console.WriteLine();
				_console.WriteLine("Output:");
				_console.ForegroundColor = ConsoleColor.Cyan;

				var result = _senderApp.Send(msg);

				_console.ForegroundColor = startColor;

				_console.WriteLine();
				_console.WriteLine($"Result: {result.Price} ");
				_console.WriteLine($"    Price: {result.Price} ");
				_console.WriteLine($"    Message: {result.Message} ");
				_console.WriteLine($"    Result Message: {result.ResultMessage} ");


				_console.WriteLine(" ** Complete **");
				_console.WriteLine(" ** Space bar to Exit **");

				key = _console.ReadKey().Key;

				_console.Clear();
			}
		}
	}

	public class SuperSendingMicroApp : IMessageSendingMicroApp
	{
		readonly ICostCalculator _cost;
		readonly IMessageSender _sender;
		readonly IAppLogger _logger;

		public SuperSendingMicroApp(ICostCalculator cost, IMessageSender sender, IAppLogger logger)
		{
			_cost = cost ?? throw new ArgumentNullException(nameof(cost), $"{nameof(cost)} is null.");
			_sender = sender ?? throw new ArgumentNullException(nameof(sender), $"{nameof(sender)} is null.");
			_logger = logger ?? throw new ArgumentNullException(nameof(logger), $"{nameof(logger)} is null.");
		}

		public SendResponse Send(string message)
		{
			try
			{
				int price = _cost.CalculatePrice(message);
				_sender.Send(message);

				return new SendResponse()
				{
					Message = message,
					Price = price,
					ResultMessage = "Success"
				};
			}
			catch (Exception ex)
			{
				_logger.Error($"There was an error: {ex.Message}");

				return new SendResponse()
				{
					Message = string.Empty,
					Price = 0,
					ResultMessage = "Fail"
				};
			}
		}
	}
}
