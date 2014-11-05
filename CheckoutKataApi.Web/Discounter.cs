namespace CheckoutKataApi.Web
{
	public class Discounter
	{
		public static int CalculateDiscount(int aItems, int price, int bItems)
		{
			if (aItems >= 3)
			{
				var aItemDiscountAmount = aItems/3;
				price -= (20*aItemDiscountAmount);
			}
			if (bItems >= 2)
			{
				var bItemDiscountAmount = bItems/2;
				price -= (15*bItemDiscountAmount);
			}
			return price;
		}
	}
}