using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Dynamic.Core;

namespace Webmaster.Application.Extentions
{
    public static class IQueryableExtentions
    {
        public static IQueryable<T> SortBy<T>(this IQueryable<T> source, string property, string direction)
        {
            if (string.IsNullOrEmpty(property))
                return source;

            if (string.IsNullOrEmpty(direction))
                direction = "asc";            

            source = source.OrderBy($"{property} {direction}");

            return source;
        }

        public static IQueryable<T> Paginate<T>(this IQueryable<T> source, int pageIndex, int pageSize)
        {
            source = source
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize);

            return source;
        }
    }
}
