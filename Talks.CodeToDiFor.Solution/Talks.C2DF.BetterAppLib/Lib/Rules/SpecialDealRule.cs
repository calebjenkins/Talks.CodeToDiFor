using System;
using System.Linq;
using Talks.C2DF.Interfaces;

namespace Talks.C2DF.BetterApp.Rules
{
	public class SpecialDealRule: ICostRule
	{
		public string RuleName => "Half off Deal";

		public bool AppliesTo(string message)
		{
			return (message.Contains("DEAL"));
		}

		public int Apply(string Message, int currentCost)
		{
			return currentCost / 2;
		}
	}
}
