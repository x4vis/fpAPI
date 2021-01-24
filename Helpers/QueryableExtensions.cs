using System;
using System.Linq;
using fpAPI.DTO;

namespace fpAPI.Helpers
{
    public static class QueryableExtensions
    {
        /// <summary>
        ///     Paginates the results from queryable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="queryable"></param>
        /// <param name="pagination"></param>
        /// <returns>
        ///     The qty results requested
        /// </returns>
        public static IQueryable<T> Paginate<T>
            (
                this IQueryable<T> queryable,
                Pagination pagination
            )
        {
            return queryable
                   .Skip((pagination.Page - 1) * pagination.ResourceQty)
                   .Take(pagination.ResourceQty);
        }
    }
}
