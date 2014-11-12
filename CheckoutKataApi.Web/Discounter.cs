using System.Collections.Generic;

namespace CheckoutKataApi.Web
{
	public static class Discounter
	{
		public static int CalculateDiscount(int aItems, int bItems)
		{
			var discountB = 0;
			var discountParameters = new Dictionary<char, DiscountDetails>
				{
					{'A', new DiscountDetails {ItemQuantity = aItems, QuantityRequired = 3, DiscountAmount = 20}},
					{'B', new DiscountDetails {ItemQuantity = bItems, QuantityRequired = 2, DiscountAmount = 15}}
				};

			foreach (var item in discountParameters)
			{
				char currentItem = item.Key;
				discountB += (
					discountParameters[currentItem].ItemQuantity 
					/ discountParameters[currentItem].QuantityRequired
					) * discountParameters[currentItem].DiscountAmount;
			}

			return discountB;
		}
	}
}