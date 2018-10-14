using System;
using System.Linq;
using Talks.C2DF.Interfaces;
using Talks.C2DF.Interfaces.Models;

namespace Talks.C2DF.BetterApp.Lib.Rules
{
	public class LargerSizedBasePriceRule: IBasePriceRule
	{
		public string RuleName => "Larger Sized Rule";

		public bool AppliesTo(MessageForProcessing Message)
		{
			return (Message.Weight > 9);
		}

		public int Apply(MessageForProcessing Message)
		{
			return 10;
		}
	}
}
