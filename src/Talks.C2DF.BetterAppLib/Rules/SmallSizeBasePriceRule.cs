using System;
using System.Linq;
using Talks.C2DF.Interfaces;
using Talks.C2DF.Models;

namespace Talks.C2DF.BetterAppLib.Rules
{
	public class SmallSizeBasePriceRule : IBasePriceRule
	{
		public string RuleName => "Small Size Rule";

		public bool AppliesTo(MessageForProcessing Message)
		{
			return (Message.Weight < 5);
		}

		public int Apply(MessageForProcessing Message)
		{
			return 4;
		}
	}
}
