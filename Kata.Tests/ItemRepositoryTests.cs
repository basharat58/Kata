using FluentAssertions;
using Kata.Core;
using Kata.Core.Entities;
using Moq.AutoMock;
using System.Collections.Generic;
using Xunit;

namespace Kata.Tests
{
    public class ItemRepositoryTests
    {
        private AutoMocker Mocker { get; }

        public ItemRepositoryTests()
        {            
            Mocker = new AutoMocker();
        }

        [Fact]
        public void WhenGetSpecialOffers()
        {
            // Arrange
            var subject = Mocker.CreateInstance<ItemRepository>();   
            var specialOffers = new List<Item>()
            {
                new Item { SKU = "A99", Quantity = 3, UnitPrice = 1.30m },
                new Item { SKU = "B15", Quantity = 2, UnitPrice = 0.45m }
            };

            // Act
            var result = subject.GetSpecialOffers();

            // Assert
            result.Should().BeEquivalentTo(specialOffers);
        }        
    }
}
