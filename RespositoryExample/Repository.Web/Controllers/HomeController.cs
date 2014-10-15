using Repository.Web.Repositories;
using System.Collections.Generic;
using System.Web.Http;

namespace Repository.Web.Controllers
{
	public class HomeController : ApiController
	{
		private IItemRepository ItemRepository;

		public HomeController(IItemRepository itemRepository)
		{
			ItemRepository = itemRepository;
		}

		public IList<string> Get()
		{
			return ItemRepository.GetItemNames();
		}

	}
}
