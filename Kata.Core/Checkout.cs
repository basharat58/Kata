using Kata.Core.Entities;
using System.Collections.Generic;

namespace Kata.Core
{
    public class Checkout : ICheckout
    {
        private Dictionary<string, Item> _items = new Dictionary<string, Item>();

        public void Scan(Item item)
        {
            if (_items.ContainsKey(item.SKU))
            {
                _items[item.SKU].Quantity += item.Quantity;
            }
            else
                _items.Add(item.SKU, item);
        }

        public decimal Total()
        {
            var total = 0m;

            foreach(var item in _items)
            {
                total += item.Value.Quantity * item.Value.UnitPrice;
            }
            return total;
        }
    }
}
