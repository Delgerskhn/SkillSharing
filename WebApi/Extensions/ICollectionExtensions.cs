using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Entities;
using WebApi.Helpers;

namespace WebApi.Extensions
{
    public static class ICollectionExtensions
    {
        public static ICollection<T> LeftExcept<T>(this IEnumerable<T> left, IEnumerable<T> right) where T:BaseEntity
        {
            IEnumerable<T> intersection = left.Intersect(right,new EntityComparer<T>());
            return left.Except(intersection, new EntityComparer<T>()).ToList();
        }
    }
}
