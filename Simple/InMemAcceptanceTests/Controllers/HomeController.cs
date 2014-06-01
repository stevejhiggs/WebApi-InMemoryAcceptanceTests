using System.Web.Http;

namespace Simple.Controllers
{
    public class HomeController : ApiController
    {
		public string Get(string id = null)
		{
			if (string.IsNullOrWhiteSpace(id))
			{ 
				return "Hello world";
			}
			else
			{
				return id.ToUpperInvariant();
			}
		}

    }
}
