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

		public void Post(Uri requestUri, string body)
		{
			var webRequest = WebRequest.Create(requestUri);
			webRequest.Method = "POST";
			webRequest.ContentLength = body.Length;
			using (var requestStream = webRequest.GetRequestStream())
			{
				using (var streamWriter = new StreamWriter(requestStream))
				{
					streamWriter.Write(body);
				}
			}
			WebResponse = (HttpWebResponse) webRequest.GetResponse();
			ReadResponseBody(WebResponse);
		}

		public Uri GetLocationUri()
		{
			return new Uri(WebResponse.GetResponseHeader("Location"));
		}

		public string ReadResponseBody(WebResponse httpWebResponse)
		{
			using (var responseStream = httpWebResponse.GetResponseStream())
			{
				Assert.IsNotNull(responseStream);
				using (var streamReader = new StreamReader(responseStream))
				{
					return streamReader.ReadToEnd();
				}
			}
		}
	}
}