using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Entities;

namespace WebApi.Helpers
{
    public class EntityComparer<T> : IEqualityComparer<T>  where T:BaseEntity
    {
        public bool Equals(T x, T y)
        {
            //Check whether the compared objects reference the same data.
            if (Object.ReferenceEquals(x, y)) return true;

            //Check whether any of the compared objects is null.
            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                return false;

            //Check whether the products' properties are equal.
            return x.Pk == y.Pk && x.Pk == y.Pk;
        }

        public int GetHashCode(T obj)
        {
            //Check whether the object is null
            if (Object.ReferenceEquals(obj, null)) return 0;

            //Get hash code for the Name field if it is not null.
            //Calculate the hash code for the product.
            return obj.Pk.GetHashCode();
        }
    }
}
