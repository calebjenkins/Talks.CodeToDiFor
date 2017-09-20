using System;
using System.Linq;
using Talks.C2DF.Interfaces;

namespace Talks.C2DF.NotSoSuperLib.Lib
{
	public class CostCalculator: ICostCalculator
	{
		public int CalculatePrice(string message)
		{
			Console.Write("CostCalculator");

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
			return price;
		}
	}
}
