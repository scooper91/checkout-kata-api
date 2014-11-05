using System.Collections.Generic;

namespace CheckoutKataApi.Web
{
	public class PriceCalculator
	{
		public int GetPriceOf(string items)
		{
			var price = 0;
			var aItems = 0;
			var bItems = 0;
			var priceForItems = new Dictionary<char, int>
				{
					{'A', 50},
					{'B', 30},
					{'C', 20},
					{'D', 15}
				};

			foreach (var item in items)
			{
				price += priceForItems[item];

				if (item == 'A')
				{
					aItems += 1;
				}
				if (item == 'B')
				{
					bItems += 1;
				}
			}

			if (aItems >= 3)
			{
				var aItemDiscountAmount = aItems/3;
				price -= (20 * aItemDiscountAmount);
			}
			if (bItems >= 2)
			{
				var bItemDiscountAmount = bItems/2;
				price -= (15 * bItemDiscountAmount);
			}

	return price;
		}
	}
}