using System;
using System.Collections.Generic;

#nullable disable

namespace fpAPI.Access.DbCtx
{
    public partial class OfficeProductHistory
    {
        public uint Id { get; set; }
        public uint OfficeProductFk { get; set; }
        public decimal SellPrice { get; set; }
        public decimal Utility { get; set; }
        public DateTime? PriceUpdate { get; set; }

        public virtual OfficeProduct OfficeProductFkNavigation { get; set; }
    }
}
