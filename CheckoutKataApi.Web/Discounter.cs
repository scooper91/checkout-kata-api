namespace CheckoutKataApi.Web
{
	public static class Discounter
	{
		public static int CalculateDiscount(int aItems, int bItems)
		{
			var discount = (aItems/3)*20;
			discount += (bItems/2)*15;

			return discount;
		}
	}
}