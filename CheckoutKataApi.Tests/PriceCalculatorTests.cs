using CheckoutKataApi.Web;
using NUnit.Framework;

namespace CheckoutKataApi.Tests
{
	class PriceCalculatorTests
	{
		[TestCase("", 0)]
		[TestCase("A", 50)]
		[TestCase("B", 30)]
		[TestCase("C", 20)]
		[TestCase("D", 15)]
		public void Should_return_expected_price_for_single_item(string items, int expectedPrice)
		{
			var calculator = new PriceCalculator();

			Assert.That(PriceCalculator.GetPriceOf(items), Is.EqualTo(expectedPrice));
		}

		[TestCase("AA", 100)]
		[TestCase("CC", 40)]
		[TestCase("DD", 30)]
		[TestCase("AB", 80)]
		public void Should_return_expected_price_for_two_items(string items, int expectedPrice)
		{
			var calculator = new PriceCalculator();

			Assert.That(PriceCalculator.GetPriceOf(items), Is.EqualTo(expectedPrice));
		}

		[TestCase("AAA", 130)]
		[TestCase("BB", 45)]
		public void Should_return_price_for_discounted_items(string items, int expectedPrice)
		{
			var calculator = new PriceCalculator();
			
			Assert.That(PriceCalculator.GetPriceOf(items), Is.EqualTo(expectedPrice));
		}
	}
}
