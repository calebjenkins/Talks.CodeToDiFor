using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using Talks.C2DF.BetterAppLib;
using Talks.C2DF.Interfaces;
using Talks.C2DF.Models;

namespace Talks.C2DF.Tests.ShippingCostRules;

[TestClass]
public class CostCalculatorTests
{
	Mock<IAppLogger> _loggerMock;

	private const string message = "this is a test message";

	[TestInitialize]
	public void SetUp()
	{
		_loggerMock = new Mock<IAppLogger>();
	}

	[TestMethod]
	public void _should_determine_weight_based_on_message_length()
	{
		var shouldBe1 = "1";
		var shouldBe2 = "12";
		var shouldBe3 = "123";
		var shouldBe4 = "1234";

		Assert.AreEqual<int>(1, CostCalculator.CalculateWeight(shouldBe1));
		Assert.AreEqual<int>(2, CostCalculator.CalculateWeight(shouldBe2));
		Assert.AreEqual<int>(3, CostCalculator.CalculateWeight(shouldBe3));
		Assert.AreEqual<int>(4, CostCalculator.CalculateWeight(shouldBe4));
	}

	//[DataTestMethod]	// DataTestMethod doesn't seem to work in CORE yet 
	//[DataRow(1,2,3,4,5,10)]
	//[DataRow("1", "12", "123", "1234", "12345", "1234567890")]
	//public void _should_calculate_weight(int length, string message)
	//{
	//	Assert.AreEqual<int>(length, CostCalculator.CalculateWeight(message));
	//}

	[TestMethod]
	public void _should_price_Zero_if_no_rules_included()
	{
		var sut = new CostCalculator(new List<IBasePriceRule>(), new List<IExtendedPriceRule>(), _loggerMock.Object);
		var result = sut.CalculatePrice(message);
		//result.ShouldEqual<int>(0);
		Assert.AreEqual<int>(0, result);
	}

	[TestMethod]
	public void _should_loop_through_all_rules()
	{
		// ** Arrange **
		Mock<IBasePriceRule> _baseRuleMock = new Mock<IBasePriceRule>();
		_baseRuleMock.Setup(x => x.RuleName).Returns("Mock Base Rule").Verifiable();
		_baseRuleMock.Setup(x => x.AppliesTo(It.IsAny<MessageForProcessing>())).Returns(true).Verifiable();
		_baseRuleMock.Setup(x => x.Apply(It.IsAny<MessageForProcessing>())).Returns(10).Verifiable();
		var basePriceRules = new List<IBasePriceRule>() { _baseRuleMock.Object };

		Mock<IExtendedPriceRule> _extRuleMock = new Mock<IExtendedPriceRule>();
		_extRuleMock.Setup(x => x.AppliesTo(It.IsAny<MessageForProcessing>())).Returns(false);
		_extRuleMock.Setup(x => x.RuleName); // Never gets called
		_extRuleMock.Setup(x => x.Apply(It.IsAny<MessageForProcessing>())); // Never gets called in this test
		var extRules = new List<IExtendedPriceRule>() { _extRuleMock.Object };

		var sut = new CostCalculator(basePriceRules, extRules, _loggerMock.Object);

		// ** Act **
		var result = sut.CalculatePrice(message);

		// ** Assert **
		Assert.AreEqual<int>(10, result);
		_baseRuleMock.VerifyAll();

		_extRuleMock.Verify(x => x.AppliesTo(It.IsAny<MessageForProcessing>()), Times.Once);
		_extRuleMock.Verify(x => x.RuleName, Times.Never);
		_extRuleMock.Verify(x => x.Apply(It.IsAny<MessageForProcessing>()), Times.Never);
	}
}
