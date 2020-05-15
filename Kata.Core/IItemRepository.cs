using Kata.Core.Entities;
using System.Collections.Generic;

namespace Kata.Core
{
    public interface IItemRepository
    {
        List<Item> GetSpecialOffers();
    }
}
