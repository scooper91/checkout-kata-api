using System.Collections.Generic;

namespace CheckoutKataApi.Web
{
	public static class ItemPrices
	{
		public static Dictionary<char, int> ItemPrice()
		{
			var priceForItems = new Dictionary<char, int>
				{
					{'A', 50},
					{'B', 30},
					{'C', 20},
					{'D', 15}
				};
			return priceForItems;
		}
	}
}