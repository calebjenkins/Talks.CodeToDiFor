using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talks.C2DF.Interfaces;

namespace Talks.C2DF.BetterApp.Rules
{
	public class SmallSizeRule : ICostRule
	{
		public string RuleName => "Small Size Rule";

		public bool AppliesTo(string message)
		{
			return (message.Length < 5);
		}

		public int Apply(string Message, int currentCost)
		{
			return 4;
		}
	}
}
