using System;
using System.Linq;
using Talks.C2DF.Interfaces;
using Talks.C2DF.Models;

namespace Talks.C2DF.BetterAppLib.Rules
{
	public class MediumSizedBasePriceRule : IBasePriceRule
	{
		public string RuleName => "Medium Sized Rule";

		public bool AppliesTo(MessageForProcessing Message)
		{
			return (Message.Weight > 4 && Message.Weight < 10);
		}

		public int Apply(MessageForProcessing Message)
		{
			return 5;
		}
	}
}
