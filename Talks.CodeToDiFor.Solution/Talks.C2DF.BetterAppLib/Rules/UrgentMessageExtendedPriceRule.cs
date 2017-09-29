using System;
using System.Linq;
using Talks.C2DF.Interfaces;
using Talks.C2DF.Interfaces.Models;

namespace Talks.C2DF.BetterApp.Lib.Rules
{
	public class UrgentMessageExtendedPriceRule: IExtendedPriceRule
	{
		public string RuleName => "Urgent Message Rule";

		public bool AppliesTo(MessageForProcessing Message)
		{
			return (Message.Text.Contains("!") && !Message.Text.Contains("!!!"));
		}

		public int Apply(MessageForProcessing Message)
		{
			return Message.CurrentPrice * 2;
		}
	}
}
