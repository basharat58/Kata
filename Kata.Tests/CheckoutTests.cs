using AutoFixture;
using FluentAssertions;
using Kata.Core;
using Kata.Core.Entities;
using Moq.AutoMock;
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
            var item = AutoFixture.Create<Item>();

            // Act
            subject.Scan(item);
            var result = subject.Total();

            // Assert
            result.Should().Be(item.Quantity * item.UnitPrice);
        }
    }
}
