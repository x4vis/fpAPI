using System;
using System.Collections.Generic;

#nullable disable

namespace fpAPI.Access.DbCtx
{
    public partial class ProviderProductHistory
    {
        public uint Id { get; set; }
        public uint ProviderProductFk { get; set; }
        public decimal SellPrice { get; set; }
        public DateTime? PriceUpdate { get; set; }

        public virtual ProviderProduct ProviderProductFkNavigation { get; set; }
    }
}
