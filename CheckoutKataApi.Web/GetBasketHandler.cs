using System.Web;

namespace CheckoutKataApi.Web
{
	public class GetBasketHandler : IHttpHandler
	{
		public void ProcessRequest(HttpContext context)
		{}

		public bool IsReusable { get; private set; }
	}
}