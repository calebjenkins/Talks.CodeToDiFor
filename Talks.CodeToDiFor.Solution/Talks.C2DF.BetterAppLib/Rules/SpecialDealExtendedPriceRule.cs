using System;
using System.Linq;
using Talks.C2DF.Interfaces;
using Talks.C2DF.Models;

namespace Talks.C2DF.BetterAppLib.Rules
{
	public class SpecialDealExtendedPriceRule : IExtendedPriceRule
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
