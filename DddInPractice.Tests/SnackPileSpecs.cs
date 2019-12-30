using System;
using DddInPractice.Logic;
using FluentAssertions;
using Xunit;

namespace DddInPractice.Tests
{
    public class SnackPileSpecs
    {
        [Fact]
        public void Cannot_create_a_snack_pile_with_negative_quantity()
        {
            Action action = () =>
            {
                new SnackPile(new Snack("Chips"), -1, 1m);
            };

            action.Should().Throw<InvalidOperationException>();
        }

        [Fact]
        public void Cannot_create_a_snack_pile_with_negative_price()
        {
            Action action = () =>
            {
                new SnackPile(new Snack("Chips"), 1, -1m);
            };

            action.Should().Throw<InvalidOperationException>();
        }

        [Fact]
        public void Cannot_create_a_snack_pile_with_a_price_less_than_one_cent()
        {
            Action action = () =>
            {
                new SnackPile(new Snack("Chips"), 1, 0.001m);
            };

            action.Should().Throw<InvalidOperationException>();
        }
    }
}