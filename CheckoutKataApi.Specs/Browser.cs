using System;
using System.IO;
using System.Net;
using NUnit.Framework;

namespace CheckoutKataApi.Specs
{
	public class Browser
	{
		public HttpWebResponse WebResponse;

		public void Get(Uri requestUri)
		{
			var webRequest = WebRequest.Create(requestUri);
			WebResponse = (HttpWebResponse) webRequest.GetResponse();
		}

		public string GetResponseBody()
		{
			using (var responseStream = WebResponse.GetResponseStream())
			{
				Assert.NotNull(responseStream);
				using (var streamReader = new StreamReader(responseStream))
				{
					return streamReader.ReadToEnd();
				}
			}
		}

		public void Post(Uri requestUri)
		{
			var webRequest = WebRequest.Create(requestUri);
			webRequest.Method = "POST";
			webRequest.ContentLength = 0;
			WebResponse = (HttpWebResponse) webRequest.GetResponse();
		}

		public Uri GetLocationUri()
		{
			return new Uri(WebResponse.GetResponseHeader("Location"));
		}
	}
}