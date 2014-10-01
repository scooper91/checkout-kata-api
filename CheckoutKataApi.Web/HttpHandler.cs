using System.Web;

namespace CheckoutKataApi.Web
{
	public class HttpHandler : IHttpHandler
	{
		public void ProcessRequest(HttpContext context)
		{
			context.Response.Write("Hello World!");
		}

		public bool IsReusable { get; private set; }
	}
}