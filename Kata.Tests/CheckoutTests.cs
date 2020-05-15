using AutoFixture;
using FluentAssertions;
using Kata.Core;
using Kata.Core.Entities;
using Moq.AutoMock;
using System.Linq;
using Xunit;

namespace Kata.Tests
{
    public class CheckoutTests
    {
        private Fixture AutoFixture { get; }
        private AutoMocker Mocker { get; }

        public CheckoutTests()
        {
            AutoFixture = new Fixture();
            Mocker = new AutoMocker();
        }

        [Fact]
        public void WhenGetTotal()
        {
            // Arrange
            var subject = Mocker.CreateInstance<Checkout>();
            var items = AutoFixture.Create<Item[]>().ToList();
            var specialOffers = items.Select(i => new Item
                {
                    SKU = i.SKU,
                    Quantity = AutoFixture.Create<int>(),
                    UnitPrice = AutoFixture.Create<decimal>()
                }
            ).ToList();
            var total = 0m;
            Mocker.GetMock<IItemRepository>()
                .Setup(ir => ir.GetSpecialOffers())
                .Returns(specialOffers);

            foreach (var item in items)
            {
                
                var offer = specialOffers.FirstOrDefault(so => so.SKU == item.SKU);
                if (offer != null && (item.Quantity >= offer.Quantity))
                {
                    var normalCost = (item.Quantity % offer.Quantity) * item.UnitPrice;
                    var offerCost = (item.Quantity / offer.Quantity) * offer.UnitPrice;
                    total += normalCost + offerCost;
                }
            }
            foreach (var item in items)
            {
                subject.Scan(item);
            }

            // Act
            var result = subject.Total();

            // Assert
            result.Should().Be(total);
        }
    }
}
