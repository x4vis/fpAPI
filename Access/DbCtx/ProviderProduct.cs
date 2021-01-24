using System;
using System.Collections.Generic;

#nullable disable

namespace fpAPI.Access.DbCtx
{
    public partial class ProviderProduct
    {
        public ProviderProduct()
        {
            ProviderProductHistories = new HashSet<ProviderProductHistory>();
        }

        public uint Id { get; set; }
        public uint ProviderFk { get; set; }
        public uint ProductFk { get; set; }
        public decimal SellPrice { get; set; }

        public virtual Product ProductFkNavigation { get; set; }
        public virtual Provider ProviderFkNavigation { get; set; }
        public virtual ICollection<ProviderProductHistory> ProviderProductHistories { get; set; }
    }
}
