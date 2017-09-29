using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talks.C2DF.Interfaces;
using Talks.C2DF.Interfaces.Models;

namespace Talks.C2DF.BetterApp.Lib.Rules
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
