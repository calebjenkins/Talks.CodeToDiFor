using System;
using System.Linq;

namespace Talks.C2DF.Interfaces
{
	public interface ICostRule
	{
		string RuleName { get; }
		bool AppliesTo(string message);
		int Apply(string Message, int currentCost);
	}
}
