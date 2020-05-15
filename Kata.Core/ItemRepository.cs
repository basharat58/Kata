using Kata.Core.Entities;
using System.Collections.Generic;

namespace Kata.Core
{
    public class ItemRepository : IItemRepository
    {
        public List<Item> GetSpecialOffers()
        {
            return new List<Item>()
            {
                new Item { SKU = "A99", Quantity = 3, UnitPrice = 1.30m },
                new Item { SKU = "B15", Quantity = 2, UnitPrice = 0.45m }
            };
        }
    }
}
