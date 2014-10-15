using Repository.Web.Repositories;
using System.Collections.Generic;

namespace Repository.Tests
{
    public class TestItemRepository : IItemRepository
    {

        public IList<string> GetItemNames()
        {
            return new List<string>() {
                "TestItem"
            };
        }
    }
}
