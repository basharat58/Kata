using Kata.Core.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Kata.Core
{
    public class Checkout : ICheckout
    {
        private readonly IItemRepository _itemRepository;

        public Checkout(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        private List<Item> _items = new List<Item>();

        public void Scan(Item item)
        {
            if (_items.Any(i => i.SKU == item.SKU))
            {
                _items.Where(i => i.SKU == item.SKU)
                    .Select(i => i.Quantity = i.Quantity + item.Quantity);
            }
            else
                _items.Add(item);
        }

        public decimal Total()
        {
            var total = 0m;
            var specialOffers = _itemRepository.GetSpecialOffers();

            foreach (var item in _items)
            {
                var offer = specialOffers.FirstOrDefault(so => so.SKU == item.SKU);
                if (offer != null && (item.Quantity >= offer.Quantity))
                {
                    var normalCost = (item.Quantity % offer.Quantity) * item.UnitPrice;
                    var offerCost = (item.Quantity / offer.Quantity) * offer.UnitPrice;
                    total += normalCost + offerCost; 
                }
            }
            return total;
        }
    }
}
