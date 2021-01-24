using System;
using System.Collections.Generic;

#nullable disable

namespace fpAPI.Access.DbCtx
{
    public partial class SaleDetail
    {
        public uint Id { get; set; }
        public uint SaleFk { get; set; }
        public uint ProductFk { get; set; }
        public decimal Iva { get; set; }
        public decimal Subtotal { get; set; }
        public decimal TotaL { get; set; }

        public virtual Product ProductFkNavigation { get; set; }
        public virtual Sale SaleFkNavigation { get; set; }
    }
}
