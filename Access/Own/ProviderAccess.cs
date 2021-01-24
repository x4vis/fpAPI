using System.Linq;
using fpAPI.Access.DbCtx;

namespace fpAPI.Access.Own
{
    public class ProviderAccess
    {
        /// <summary>
        ///     Gets a provider searching by name
        /// </summary>
        /// <param name="search">the provider´s name</param>
        /// <returns>
        ///     A IQueryable of providers
        /// </returns>
        public static IQueryable<Provider> FilterProviders(string search)
        {
            IQueryable<Provider> query = EFCtx.Inv.Providers
                .Where(p => p.Name.Contains(search));

            return query;
        }
    }
}
