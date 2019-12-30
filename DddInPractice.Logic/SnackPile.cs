using System;

namespace DddInPractice.Logic
{
    public sealed class SnackPile : ValueObject<SnackPile>
    {
        public Snack Snack { get; }
        public int Quantity { get; }
        public decimal Price { get; }

        public SnackPile()
        {
            
        }

        public SnackPile(Snack snack, int quantity, decimal price) : this()
        {
            if(quantity < 0)
                throw new InvalidOperationException();
            if(price < 0)
                throw new InvalidOperationException();
            if(price % 0.01m > 0)
                throw new InvalidOperationException();

            Snack = snack;
            Quantity = quantity;
            Price = price;
        }

        protected override bool EqualsCore(SnackPile other)
        {
            return Snack == other.Snack
                   && Quantity == other.Quantity
                   && Price == other.Price;
        }

        protected override int GetHashCodeCore()
        {
            unchecked
            {
                int hashcode = Snack.GetHashCode();
                hashcode = (hashcode * 397) ^ Quantity;
                hashcode = (hashcode * 397) ^ Price.GetHashCode();
                return hashcode;
            }
        }

        public SnackPile SubtractOne()
        {
            return new SnackPile(Snack, Quantity - 1, Price);
        }
    }
}