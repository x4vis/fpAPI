using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace fpAPI.Helpers
{
    public static class HttpContextExtensions
    {
        /// <summary>
        ///     Add queryable records and pageQty to headers
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="httpContext"></param>
        /// <param name="queryable"></param>
        /// <param name="qtyRecordsPerPage"></param>
        /// <returns></returns>
        public static async Task InsertPagionationParameters<T>
            (
                this HttpContext httpContext,
                IQueryable<T> queryable,
                int qtyRecordsPerPage
            )
        {
            double records = await queryable.CountAsync();
            double pageQty = Math.Ceiling(records / qtyRecordsPerPage);

            httpContext.Response.Headers.Add("totalRecords", records.ToString());
            httpContext.Response.Headers.Add("pageQty", pageQty.ToString());
        }
    }
}
