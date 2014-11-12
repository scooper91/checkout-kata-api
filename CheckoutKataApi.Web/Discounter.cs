using System.Collections.Generic;
using System.Linq;

namespace CheckoutKataApi.Web
{
	public static class Discounter
	{
		public static int CalculateDiscount(int aItems, int bItems)
		{
			var discountParameters = new Dictionary<char, DiscountDetails>
				{
					{'A', new DiscountDetails {ItemQuantity = aItems, QuantityRequired = 3, DiscountAmount = 20}},
					{'B', new DiscountDetails {ItemQuantity = bItems, QuantityRequired = 2, DiscountAmount = 15}}
				};

			return discountParameters
				.Select(item => item.Key)
				.Select(
					currentItem => 
						(discountParameters[currentItem].ItemQuantity
						/discountParameters[currentItem].QuantityRequired)
						*discountParameters[currentItem].DiscountAmount)
				.Sum();
		}
	}
}