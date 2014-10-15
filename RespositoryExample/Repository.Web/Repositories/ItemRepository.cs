using System;
using System.Collections.Generic;

namespace Repository.Web.Repositories
{
    public interface IItemRepository
    {
        IList<string> GetItemNames();
    }

    public class ItemRepository : IItemRepository
    {
        public IList<string> GetItemNames()
        {
            return new List<string> {
                "Eggs",
                "Bacon",
                "Sausage",
                "SPAM",
                "SPAM",
                "SPAM",
                "SPAM",
                "SPAM"
            };
        }
    }
}
