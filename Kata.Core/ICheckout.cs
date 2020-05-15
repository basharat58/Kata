using Kata.Core.Entities;

namespace Kata.Core
{
    interface ICheckout
    {
        decimal Total();
        void Scan(Item item);
    }
}
