namespace DddInPractice.Logic
{
    public sealed class Money
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
    }
}