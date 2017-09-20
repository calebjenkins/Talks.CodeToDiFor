using System;
using System.Linq;
using Talks.C2DF.Interfaces;

namespace Talks.C2DF.BetterApp.Rules
{
	public class ReallyUrgentMessage: ICostRule
	{
		public string RuleName => "Really Urgent Cost Rule";

		public bool AppliesTo(string message)
		{
			return (message.Contains("!!!"));
		}

		public int Apply(string Message, int currentCost)
		{
			return currentCost * 3;
		}
	}
}
