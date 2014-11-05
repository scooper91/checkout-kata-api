namespace CheckoutKataApi.Web
{
	public class PriceCalculator
	{
		public int GetPriceOf(string items)
		{
			var runningTotal = 0;
			var aItems = 0;
			var bItems = 0;
			var priceForItems = ItemPrices.ItemPrice();

			foreach (var item in items)
			{
				runningTotal += priceForItems[item];

				if (item == 'A')
				{
					aItems += 1;
				}
				if (item == 'B')
				{
					bItems += 1;
				}
			}

			runningTotal = Discounter.CalculateDiscount(aItems, runningTotal, bItems);

			return runningTotal;
		}
	}
}