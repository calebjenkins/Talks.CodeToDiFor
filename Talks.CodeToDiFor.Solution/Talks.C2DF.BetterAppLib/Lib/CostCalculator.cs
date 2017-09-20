using System;
using System.Collections.Generic;
using System.Linq;
using Talks.C2DF.Interfaces;

namespace Talks.C2DF.BetterApp.Lib
{
	public class CostCalculator: ICostCalculator
	{
		IList<ICostRule> _costRules;
		public CostCalculator(IList<ICostRule> costRules)
		{
			_costRules = costRules;
		}

		public int CalculatePrice(string message)
		{
			int price = 0;
			foreach (var costRule in _costRules)
			{
				if (costRule.AppliesTo(message))
				{
					Console.WriteLine($"Applying Rule: {costRule.RuleName}");
					price = costRule.Apply(message, price);
				}
			}

			return price;
		}
	}
}
