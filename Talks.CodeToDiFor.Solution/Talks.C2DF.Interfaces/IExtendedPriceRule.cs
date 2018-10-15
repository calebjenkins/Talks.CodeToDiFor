using System;
using Talks.C2DF.Models;

namespace Talks.C2DF.Interfaces
{
	public interface IExtendedPriceRule
	{
		string RuleName { get; }
		bool AppliesTo(MessageForProcessing Message);
		int Apply(MessageForProcessing Message);
	}
}
