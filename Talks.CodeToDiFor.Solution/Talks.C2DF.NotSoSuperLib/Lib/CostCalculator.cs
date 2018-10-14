using System;
using System.Collections.Generic;
using System.Text;
using Talks.C2DF.ExternalLoggingLib;
using Talks.C2DF.Interfaces;

namespace Talks.C2DF.NotSoSuperLib.Lib
{
	public class CostCalculator : ICostCalculator
	{
		ILogger _logger;
		public CostCalculator()
		{
			_logger = new Logger();
		}
		public int CalculatePrice(string message)
		{
			Console.WriteLine("CostCalculator");
			_logger.Info("Entering Cost Calculator");

			int price = 0;

			if (message.Length > 10)
				price += 10;
			else if (message.Length > 5)
				price += 5;
			else if (message.Length > 0)
				price += 4;

			if (message.Contains("!!!"))
				price *= 3;
			else if (message.Contains("!"))
				price *= 2;

			if (message.Contains("GodSaveTheQueen"))
				price = 0;

			if (message.Contains("DEAL"))
				price = price / 2;


			Console.WriteLine(" - Price: " + price);
			_logger.Info($"Cost Calculator - Price: {price}");
			return price;
		}
	}
}
