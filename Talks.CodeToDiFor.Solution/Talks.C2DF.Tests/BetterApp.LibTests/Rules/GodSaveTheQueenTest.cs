using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Talks.C2DF.BetterApp.Lib.Rules;
using Talks.C2DF.Interfaces.Models;

namespace Talks.C2DF.Tests.BetterAppLibTests.Rules
{
	[TestClass]
	public class GodSaveTheQueenTest
	{
		GodSaveQueenExtendedPriceRule rule;
		MessageForProcessing validMsg;
		MessageForProcessing invalidMsg;

		[TestInitialize]
		public void SetUp()
		{
			rule = new GodSaveQueenExtendedPriceRule();
			validMsg = new MessageForProcessing() { CurrentPrice = 10, Text = "GodSaveTheQueen", Weight = 10 };
			invalidMsg = new MessageForProcessing() { CurrentPrice = 20, Text = "This is a message", Weight = 30 };
		}

		[TestMethod]
		public void Should_Set_as_free_when_applies()
		{
			Assert.IsTrue(rule.AppliesTo(validMsg));
			Assert.IsTrue(0 == rule.Apply(validMsg));
		}

		[TestMethod]
		public void Should_not_apply_when_doesnt_apply()
		{
			Assert.IsFalse(rule.AppliesTo(invalidMsg));
		}
	}
}
