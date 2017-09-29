using System;
using System.Linq;
using Talks.C2DF.Interfaces;
using Talks.C2DF.Interfaces.Models;

namespace Talks.C2DF.BetterApp.Lib.Rules
{
	public class ReallyUrgentMessageExtendedPriceRule: IExtendedPriceRule
	{
		public string RuleName => "Really Urgent Cost Rule";

		public bool AppliesTo(MessageForProcessing Message)
		{
			return (Message.Text.Contains("!!!"));
		}

		public int Apply(MessageForProcessing Message)
		{
			return Message.CurrentPrice * 3;
		}
	}
}
