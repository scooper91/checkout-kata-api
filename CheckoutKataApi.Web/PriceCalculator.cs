using System.Linq;

namespace CheckoutKataApi.Web
{
	public class PriceCalculator
	{
		public int GetPriceOf(string items)
		{
			var priceForItems = ItemPrices.ItemPrice();

			var aItems = items.Count(item => item == 'A');
			var bItems = items.Count(item => item == 'B');

			var runningTotal = items.Sum(item => priceForItems[item]);
			var discountTotal = Discounter.CalculateDiscount(aItems, bItems);

			return runningTotal - discountTotal;
		}
	}
}