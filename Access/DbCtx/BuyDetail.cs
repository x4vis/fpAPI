using System;
using System.Collections.Generic;

#nullable disable

namespace fpAPI.Access.DbCtx
{
    public partial class BuyDetail
    {
        public uint Id { get; set; }
        public uint BuyFk { get; set; }
        public uint ProductFk { get; set; }
        public decimal Iva { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Total { get; set; }

        public virtual Buy BuyFkNavigation { get; set; }
        public virtual Product ProductFkNavigation { get; set; }
    }
}
