using System;
using System.Net;
using System.Web.Script.Serialization;
using NUnit.Framework;

namespace CheckoutKataApi.Specs
{
	public class BasketProcessing
	{
		private readonly Browser _browser = new Browser();

		public Uri CreateBasket(string basketContents)
		{
			_browser.Post(new Uri("http://checkout-kata.local/baskets"), basketContents);

			Assert.That(_browser.WebResponse.StatusCode, Is.EqualTo(HttpStatusCode.Created));

			return _browser.GetLocationUri();
		}

		public void GetBasket(Uri requestUri)
		{
			_browser.Get(requestUri);

			Assert.That(_browser.WebResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
		}

		public void AssertPriceIsCorrect(int expectedPrice)
		{
			var body = _browser.GetResponseBody();

			var serializer = new JavaScriptSerializer();
			var basket = serializer.Deserialize<Basket>(body);

			Assert.That(basket.Price, Is.EqualTo(expectedPrice));
		}
	}
}