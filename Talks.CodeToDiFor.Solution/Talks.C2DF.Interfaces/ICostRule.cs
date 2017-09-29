using System;
using System.Linq;
using Talks.C2DF.Interfaces.Models;

namespace Talks.C2DF.Interfaces
{
	public interface IBasePriceRule
	{
		string RuleName { get; }
		bool AppliesTo(MessageForProcessing Message);
		int Apply(MessageForProcessing Message);
	}

	public interface IExtendedPriceRule
	{
		string RuleName { get; }
		bool AppliesTo(MessageForProcessing Message);
		int Apply(MessageForProcessing Message);
	}
}
