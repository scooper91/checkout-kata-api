﻿using System;
using System.Net;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace CheckoutKataApi.Specs
{
    [Binding]
    public class BasketSteps
    {
	    private Uri _basketUri;

		private Uri CreateBasket(string items)
		{
			var webRequest = WebRequest.Create("http://checkout-kata.local/baskets");
			webRequest.Method = "POST";
			webRequest.ContentLength = 0;
			var webResponse = (HttpWebResponse)webRequest.GetResponse();

			Assert.That(webResponse.StatusCode, Is.EqualTo(HttpStatusCode.Created));

			return new Uri(webResponse.GetResponseHeader("Location"));
		}


        [Given(@"I have an empty basket")]
        public void GivenIHaveAnEmptyBasket()
        {
	        _basketUri = CreateBasket("");
        }

	    [When(@"I check my basket")]
        public void WhenICheckMyBasket()
	    {
		    var webRequest = WebRequest.Create("http://checkout-kata.local/baskets/1");
		    var webResponse = (HttpWebResponse) webRequest.GetResponse();

			Assert.That(webResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
	    }
        
        [Then(@"the price should be (.*)")]
        public void ThenThePriceShouldBe(int p0)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
