using System.Linq;
using fpAPI.Access.Own;
using fpAPI.Access.DbCtx;

namespace fpAPI.Logic
{
    public class LogicProviders
    {
        /// <summary>
        ///     Filters the providers by the name field
        /// </summary>
        /// <param name="search"></param>
        /// <returns>
        ///     IQueryable of providers
        /// </returns>
        public static IQueryable<Provider> GetProviderQuery(string search)
        {
            if (string.IsNullOrEmpty(search))
            {
                search = "";
            }

            search = search.Trim().ToLower();
            return ProviderAccess.FilterProviders(search);
        }
    }
}
