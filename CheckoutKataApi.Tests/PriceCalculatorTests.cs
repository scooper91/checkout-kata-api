using CheckoutKataApi.Web;
using NUnit.Framework;

namespace CheckoutKataApi.Tests
{
	class PriceCalculatorTests
	{
		private PriceCalculator _calculator;

		[SetUp]
		public void SetUp()
		{
			_calculator = new PriceCalculator();
		}

		[TestCase("", 0)]
		[TestCase("A", 50)]
		[TestCase("B", 30)]
		[TestCase("C", 20)]
		[TestCase("D", 15)]
		public void Should_return_expected_price_for_single_item(string items, int expectedPrice)
		{
			Assert.That(_calculator.GetPriceOf(items), Is.EqualTo(expectedPrice));
		}

		[TestCase("AA", 100)]
		[TestCase("CC", 40)]
		[TestCase("DD", 30)]
		[TestCase("AB", 80)]
		public void Should_return_expected_price_for_two_items(string items, int expectedPrice)
		{
			Assert.That(_calculator.GetPriceOf(items), Is.EqualTo(expectedPrice));
		}

		[TestCase("AAA", 130)]
		[TestCase("BB", 45)]
		[TestCase("AAAA", 180)]
		[TestCase("BBB", 75)]
		public void Should_return_price_for_discounted_items(string items, int expectedPrice)
		{
			Assert.That(_calculator.GetPriceOf(items), Is.EqualTo(expectedPrice));
		}

		[TestCase("AAAAAA", 260)]
		[TestCase("BBBB", 90)]
		[TestCase("AAABB", 175)]
		public void Should_return_price_when_multiple_discounts_have_been_reached_for_one_item(
			string items, int expectedPrice)
		{
			Assert.That(_calculator.GetPriceOf(items), Is.EqualTo(expectedPrice));
		}
	}
}
