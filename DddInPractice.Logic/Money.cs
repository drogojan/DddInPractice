namespace DddInPractice.Logic
{
    public sealed class Money : ValueObject<Money>
    {
        public int OneCentCount { get; private set; }
        public int TenCentCount { get; private set; }
        public int QuarterCount { get; private set; }
        public int OneDollarCount { get; private set; }
        public int FiveDollarCount { get; private set; }
        public int TwentyDollarCount { get; private set; }

        public Money(
            int oneCentCount,
            int tenCentCount,
            int quarterCount,
            int oneDollarCount,
            int fiveDollarCount,
            int twentyDollarCount)
        {
            OneCentCount += oneCentCount;
            TenCentCount += tenCentCount;
            QuarterCount += quarterCount;
            OneDollarCount += oneDollarCount;
            FiveDollarCount += fiveDollarCount;
            TwentyDollarCount += twentyDollarCount;
        }

        public static Money operator +(Money firstAmount, Money secondAmount)
        {
            var sum = new Money(
                firstAmount.OneCentCount + secondAmount.OneCentCount,
                firstAmount.TenCentCount + secondAmount.TenCentCount,
                firstAmount.QuarterCount + secondAmount.QuarterCount,
                firstAmount.OneDollarCount + secondAmount.OneDollarCount,
                firstAmount.FiveDollarCount + secondAmount.FiveDollarCount,
                firstAmount.TwentyDollarCount + secondAmount.TwentyDollarCount
                );

            return sum;
        }

        protected override bool EqualsCore(Money other)
        {
            return OneCentCount == other.OneCentCount
                   && TenCentCount == other.TenCentCount
                   && QuarterCount == other.QuarterCount
                   && OneDollarCount == other.OneDollarCount
                   && FiveDollarCount == other.FiveDollarCount
                   && TwentyDollarCount == other.TwentyDollarCount;
        }

        protected override int GetHashCodeCore()
        {
            unchecked
            {
                int hashCode = OneCentCount;
                hashCode = (hashCode * 397) ^ TenCentCount;
                hashCode = (hashCode * 397) ^ QuarterCount;
                hashCode = (hashCode * 397) ^ OneDollarCount;
                hashCode = (hashCode * 397) ^ FiveDollarCount;
                hashCode = (hashCode * 397) ^ TwentyDollarCount;

                return hashCode;
            }
        }
    }
}