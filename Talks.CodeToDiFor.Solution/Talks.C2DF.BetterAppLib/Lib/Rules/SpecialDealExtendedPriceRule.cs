using System;
using System.Linq;
using Talks.C2DF.Interfaces;
using Talks.C2DF.Interfaces.Models;

namespace Talks.C2DF.BetterApp.Rules
{
	public class SpecialDealExtendedPriceRule: IExtendedPriceRule
	{
		public string RuleName => "Half off Deal";

		public bool AppliesTo(MessageForProcessing Message)
		{
			return (Message.Text.Contains("DEAL"));
		}

		public int Apply(MessageForProcessing Message)
		{
			return Message.CurrentPrice / 2;
		}
	}
}
