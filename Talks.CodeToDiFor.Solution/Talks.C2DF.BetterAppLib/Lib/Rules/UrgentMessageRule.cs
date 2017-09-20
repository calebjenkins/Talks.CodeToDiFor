using System;
using System.Linq;
using Talks.C2DF.Interfaces;

namespace Talks.C2DF.BetterApp.Rules
{
	public class UrgentMessageRule: ICostRule
	{
		public string RuleName => "Urgent Mmessage Rule";

		public bool AppliesTo(string message)
		{
			return (message.Contains("!") && !message.Contains("!!!"));
		}

		public int Apply(string Message, int currentCost)
		{
			return currentCost * 2;
		}
	}
}
