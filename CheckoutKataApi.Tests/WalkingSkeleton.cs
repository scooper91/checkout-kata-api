using System.IO;
using System.Net;
using NUnit.Framework;

namespace CheckoutKataApi.Tests
{
	[TestFixture]

    public class WalkingSkeletonTests
    {
		[Test]
		public void Should_return_message()
		{
			var request = WebRequest.Create("http://checkout-kata.local/");
			var response = (HttpWebResponse) request.GetResponse();

			var inputStream = response.GetResponseStream();
			var streamReader = new StreamReader(inputStream);
			var responseStream = streamReader.ReadToEnd();

			Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
			Assert.That(responseStream, Is.EqualTo("Hello World!"));
		}
    }
}
