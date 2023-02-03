using Talks.C2DF.Interfaces;
using Talks.C2DF.Models;

namespace Talks.C2DF.BetterAppLib.Rules;

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
