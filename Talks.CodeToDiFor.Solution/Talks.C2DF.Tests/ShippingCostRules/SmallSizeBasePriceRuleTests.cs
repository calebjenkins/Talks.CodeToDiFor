using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talks.C2DF.BetterAppLib;
using Talks.C2DF.BetterAppLib.Rules;
using Talks.C2DF.Models;

namespace Talks.C2DF.Tests.ShippingCostRules
{
	[TestClass]
	public class SmallSizeBasePriceRuleTests
	{
		private SmallSizeBasePriceRule _rule;
		private MessageForProcessing _msg;

		[TestInitialize]
		public void SetUp()
		{
			_rule = new SmallSizeBasePriceRule();
		}

		[TestMethod]
		public void SmallSizeBasePriceRule_should_accept_less_than_5()
		{
			_msg = new MessageForProcessing() { Text = "123" };
		}
	}
}
