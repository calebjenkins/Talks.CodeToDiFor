using System;
using System.Linq;
using Talks.C2DF.Interfaces;

namespace Talks.C2DF.BetterApp.Rules
{
	public class MediumSizedRule: ICostRule
	{
		public string RuleName => "Medium Sized Rule";

		public bool AppliesTo(string message)
		{
			return (message.Length > 4 && message.Length < 10);
		}

		public int Apply(string Message, int currentCost)
		{
			return 5;
		}
	}
}
