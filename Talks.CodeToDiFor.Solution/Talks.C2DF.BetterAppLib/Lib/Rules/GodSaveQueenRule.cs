using System;
using System.Linq;
using Talks.C2DF.Interfaces;

namespace Talks.C2DF.BetterApp.Lib.Rules
{
	public class GodSaveQueenRule: ICostRule
	{
		public string RuleName => "God Save the Queen";

		public bool AppliesTo(string message)
		{
			return (message.Contains("GodSaveTheQueen"));
		}

		public int Apply(string Message, int currentCost)
		{
			return 0;
		}
	}
}
