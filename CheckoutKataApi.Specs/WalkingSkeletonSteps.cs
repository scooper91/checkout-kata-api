using System.IO;
using System.Net;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace CheckoutKataApi.Specs
{
    [Binding]
    public class WalkingSkeletonSteps
    {
	    private HttpWebResponse _response;

        [When(@"I make a request to the API")]
        public void WhenIMakeARequestToTheApi()
        {
			var request = WebRequest.Create("http://checkout-kata.local/");
			_response = (HttpWebResponse)request.GetResponse();
        }
        
        [Then(@"I get a response")]
        public void ThenIGetAResponse()
        {
	        var inputStream = _response.GetResponseStream();
			var streamReader = new StreamReader(inputStream);
			var responseStream = streamReader.ReadToEnd();

			Assert.That(_response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
			Assert.That(responseStream, Is.EqualTo("Hello World!"));
        }
    }
}
