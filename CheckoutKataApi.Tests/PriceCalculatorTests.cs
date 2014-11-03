using CheckoutKataApi.Web;
using NUnit.Framework;

namespace CheckoutKataApi.Tests
{
	class PriceCalculatorTests
	{
		[TestCase("", 0)]
		[TestCase("A", 50)]
		public void Should_return_expected_price(string items, int expectedPrice)
		{
			var calculator = new PriceCalculator();

			Assert.That(calculator.GetPriceOf(items), Is.EqualTo(expectedPrice));
		}

	}
}
