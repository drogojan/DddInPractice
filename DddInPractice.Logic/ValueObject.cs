namespace DddInPractice.Logic
{
    public abstract class ValueObject<T>
        where T : ValueObject<T>
    {
        public override bool Equals(object obj)
        {
            var valueObject = obj as T;

            if (ReferenceEquals(obj, null))
                return false;

            return EqualsCore(valueObject);
        }

        public override int GetHashCode()
        {
            return GetHashCodeCore();  
        }

        public static bool operator ==(ValueObject<T> left, ValueObject<T> right)
        {
            if (left is null && right is null)
                return true;

            if (left is null || right is null)
                return false;

            return left.Equals(right);
        }

        public static bool operator !=(ValueObject<T> left, ValueObject<T> right)
        {
            return !(left == right);
        }

        protected abstract bool EqualsCore(T other);

        protected abstract int GetHashCodeCore();

    }
}