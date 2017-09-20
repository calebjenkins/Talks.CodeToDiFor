using System;
using System.Linq;
using Talks.C2DF.Interfaces;

namespace Talks.C2DF.BetterApp.Rules
{
	public class LargerSizedRule: ICostRule
	{
		public string RuleName => "Larger Sized Rule";

		public bool AppliesTo(string message)
		{
			return (message.Length > 9);
		}

		public int Apply(string Message, int currentCost)
		{
			return 10;
		}
	}
}
