using System;
using NHibernate.Proxy;

namespace DddInPractice.Logic
{
    public abstract class Entity
    {
        public virtual long Id { get; protected set; }

        public override bool Equals(object obj)
        {
            var other = obj as Entity;

            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            //if (other.GetType() != this.GetType()) return false;
            if (other.GetRealType() != this.GetRealType()) return false;
            if (Id == 0 || other.Id == 0) return false;

            return Id == other.Id;
        }

        public override int GetHashCode()
        {
            //return (GetType().ToString() + Id).GetHashCode();
            return (GetRealType().ToString() + Id).GetHashCode();
        }

        public static bool operator ==(Entity left, Entity right)
        {
            if (left is null && right is null)
                return true;

            if (left is null || right is null)
                return false;

            return left.Equals(right);
        }

        public static bool operator !=(Entity left, Entity right)
        {
            return !(left == right);
        }

        private Type GetRealType()
        {
            return NHibernateProxyHelper.GetClassWithoutInitializingProxy(this);
        }
    }
}