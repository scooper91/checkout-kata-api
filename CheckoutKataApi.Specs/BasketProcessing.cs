using System;
using System.IO;
using System.Net;
using System.Web.Script.Serialization;
using NUnit.Framework;

namespace CheckoutKataApi.Specs
{
	public class BasketProcessing
	{
		//public Uri BasketUri;
		private HttpWebResponse _webResponse;

		public Uri CreateBasket(string basketContents)
		{
			var webRequest = WebRequest.Create("http://checkout-kata.local/baskets");
			webRequest.Method = "POST";
			webRequest.ContentLength = 0;
			_webResponse = (HttpWebResponse)webRequest.GetResponse();

			Assert.That(_webResponse.StatusCode, Is.EqualTo(HttpStatusCode.Created));

			return new Uri(_webResponse.GetResponseHeader("Location"));
		}

		public void GetBasket(Uri requestUri)
		{
			Get(requestUri);

			Assert.That(_webResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
		}

		private void Get(Uri requestUri)
		{
			var webRequest = WebRequest.Create(requestUri);
			_webResponse = (HttpWebResponse) webRequest.GetResponse();
		}

		public void AssertPriceIsCorrect(int expectedPrice)
		{
			var body = GetResponseBody();

			var serializer = new JavaScriptSerializer();
			var basket = serializer.Deserialize<Basket>(body);

			Assert.That(basket.Price, Is.EqualTo(expectedPrice));
		}

		private string GetResponseBody()
		{
			using (var responseStream = _webResponse.GetResponseStream())
			{
				Assert.NotNull(responseStream);
				using (var streamReader = new StreamReader(responseStream))
				{
					return streamReader.ReadToEnd();
				}
			}
		}
	}
}