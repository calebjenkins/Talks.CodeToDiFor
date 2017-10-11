using System;
using System.Linq;
using Talks.C2DF.Interfaces;
using Talks.C2DF.Interfaces.Models;

namespace Talks.C2DF.BetterApp.Lib.Rules
{
	public class GodSaveQueenExtendedPriceRule : IExtendedPriceRule
	{
		public string RuleName => "God Save the Queen";

		public bool AppliesTo(MessageForProcessing Message)
		{
			return (Message.Text.Contains("GodSaveTheQueen"));
		}

		public int Apply(MessageForProcessing Message)
		{
			return 0;
		}
	}
}
