using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Talks.C2DF.BetterApp.Lib;
using Talks.C2DF.BetterApp.Lib.Logging;
using Talks.C2DF.Interfaces;
using Talks.C2DF.Interfaces.Models;

namespace Talks.C2DF.Tests.BetterAppLibTests
{
	[TestClass]
	public class When_CostCalculator_Calculates_It_
	{

		IList<IBasePriceRule> basePriceRules;
		IList<IExtendedPriceRule> extPriceRules;
		IAppLogger _logger;
		MessageForProcessing message;

		[TestInitialize]
		public void SetUp()
		{
			basePriceRules = new List<IBasePriceRule>();
			extPriceRules = new List<IExtendedPriceRule>();
			_logger = new Mock<IAppLogger>().Object;

			message = new MessageForProcessing() { CurrentPrice = 0, Text = "Hello World", Weight = 0 };
		}


		[TestMethod]
		public void Should_Use_BasePriceRules_When_Applies_To_Is_True()
		{
			var expectedPrice = 10;
			var validRuleMock = new Mock<IBasePriceRule>();
			validRuleMock.Setup(x => x.RuleName).Returns("ValidRule").Verifiable();
			validRuleMock.Setup(x => x.AppliesTo(It.Is<MessageForProcessing>((msg) => msg.Text == message.Text)))
				.Returns(true)
				.Verifiable();
			validRuleMock.Setup(x => x.Apply(It.Is<MessageForProcessing>((msg) => msg.Text == message.Text)))
				.Returns(expectedPrice)
				.Verifiable();
			basePriceRules.Add(validRuleMock.Object);

			var invalidRuleMock = new Mock<IBasePriceRule>();
			invalidRuleMock.Setup(x => x.RuleName).Returns("InvalidRule").Verifiable();
			invalidRuleMock.Setup(x => x.AppliesTo(It.Is<MessageForProcessing>((msg) => msg.Text == message.Text)))
				.Returns(false);
			basePriceRules.Add(invalidRuleMock.Object);

			var sut = new CostCalculator(basePriceRules, extPriceRules, _logger);
			var result = sut.CalculatePrice(message.Text);

			Assert.IsTrue(result == expectedPrice);
			validRuleMock.VerifyAll();
		}

		[TestMethod]
		public void Should_Not_Apply_BasePriceRules_When_AppliesTo_Is_False()
		{
			var expectedPrice = 0;

			var invalidRuleMock = new Mock<IBasePriceRule>();
			invalidRuleMock.Setup(x => x.RuleName).Returns("InvalidRule").Verifiable();
			invalidRuleMock.Setup(x => x.AppliesTo(It.Is<MessageForProcessing>((msg) => msg.Text == message.Text)))
				.Returns(false)
				.Verifiable();
			basePriceRules.Add(invalidRuleMock.Object);

			var sut = new CostCalculator(basePriceRules, extPriceRules, _logger);
			var result = sut.CalculatePrice(message.Text);

			Assert.IsTrue(result == expectedPrice);
			invalidRuleMock.Verify(x => x.RuleName, Times.Never);
		}

		[TestMethod]
		public void Should_Use_ExtendedPriceRules_When_Applies_To_Is_True()
		{
			var expectedPrice = 10;
			var validRuleMock = new Mock<IExtendedPriceRule>();
			validRuleMock.Setup(x => x.RuleName).Returns("ValidRule").Verifiable();
			validRuleMock.Setup(x => x.AppliesTo(It.Is<MessageForProcessing>((msg) => msg.Text == message.Text)))
				.Returns(true)
				.Verifiable();
			validRuleMock.Setup(x => x.Apply(It.Is<MessageForProcessing>((msg) => msg.Text == message.Text)))
				.Returns(expectedPrice)
				.Verifiable();
			extPriceRules.Add(validRuleMock.Object);

			var invalidRuleMock = new Mock<IExtendedPriceRule>();
			invalidRuleMock.Setup(x => x.RuleName).Returns("InvalidRule").Verifiable();
			invalidRuleMock.Setup(x => x.AppliesTo(It.Is<MessageForProcessing>((msg) => msg.Text == message.Text)))
				.Returns(false);
			extPriceRules.Add(invalidRuleMock.Object);

			var sut = new CostCalculator(basePriceRules, extPriceRules, _logger);
			var result = sut.CalculatePrice(message.Text);

			Assert.IsTrue(result == expectedPrice);
			validRuleMock.VerifyAll();
			invalidRuleMock.Verify(x => x.RuleName, Times.Never);
		}

		[TestMethod]
		public void Weight_Is_Calculated_by_Message_Length()
		{
			var result = CostCalculator.CalculateWeight(message.Text);
			Assert.IsTrue(result == message.Text.Length);

		}

		[TestMethod]
		public void Should_DebugLog_RuleName()
		{
			var expectedPrice = 10;
			var ruleName = "Valid Rule is Awesome";
			var validRuleMock = new Mock<IExtendedPriceRule>();
			validRuleMock.Setup(x => x.RuleName).Returns(ruleName).Verifiable();
			validRuleMock.Setup(x => x.AppliesTo(It.Is<MessageForProcessing>((msg) => msg.Text == message.Text)))
				.Returns(true)
				.Verifiable();
			validRuleMock.Setup(x => x.Apply(It.Is<MessageForProcessing>((msg) => msg.Text == message.Text)))
				.Returns(expectedPrice)
				.Verifiable();
			extPriceRules.Add(validRuleMock.Object);

			var logMock = new Mock<IAppLogger>();
			logMock.Setup(x => x.Debug(It.Is<string>((str) => str.Contains(ruleName)))).Verifiable();

			var sut = new CostCalculator(basePriceRules, extPriceRules, logMock.Object);
			var result = sut.CalculatePrice(message.Text);

			Assert.IsTrue(result == expectedPrice);
			validRuleMock.VerifyAll();
			logMock.VerifyAll();
		}
	}
}
