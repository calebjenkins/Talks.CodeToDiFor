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

		[TestInitialize]
		public void SetUp()
		{
			_rule = new SmallSizeBasePriceRule();
		}

		[TestMethod]
		public void _should_accept_when_weight_less_than_5()
		{
			var msg = new MessageForProcessing() { Text = "123", CurrentPrice = 0, Weight = 4 };
			Assert.IsTrue(_rule.AppliesTo(msg));
		}

		[TestMethod]
		public void _should_not_accept_when_weight_5()
		{
			var msg = new MessageForProcessing() { Text = "123", CurrentPrice = 0, Weight = 5 };
			Assert.IsFalse(_rule.AppliesTo(msg));

		}

		[TestMethod]
		public void _should_not_accept_when_weight_greater_than_5()
		{
			var msg = new MessageForProcessing() { Text = "123", CurrentPrice = 0, Weight = 6 };
			Assert.IsFalse(_rule.AppliesTo(msg));
		}

		[TestMethod]
		public void _should_apply_base_price_of_4()
		{
			var msg = new MessageForProcessing() { Text = "123", CurrentPrice = 0, Weight = 0 };
			Assert.AreEqual<int>(4, _rule.Apply(msg));
		}

		[TestMethod]
		public void _should_return_correct_rule_name()
		{
			Assert.AreEqual<string>("Small Size Rule", _rule.RuleName);
		}
	}
}
