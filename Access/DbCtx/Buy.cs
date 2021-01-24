using System;
using System.Collections.Generic;

#nullable disable

namespace fpAPI.Access.DbCtx
{
    public partial class Buy
    {
        public Buy()
        {
            BuyDetails = new HashSet<BuyDetail>();
        }

        public uint Id { get; set; }
        public uint UserFk { get; set; }
        public uint ProviderFk { get; set; }
        public decimal Iva { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Total { get; set; }
        public uint ProductsQty { get; set; }
        public DateTime? CreationDate { get; set; }

        public virtual Provider ProviderFkNavigation { get; set; }
        public virtual User UserFkNavigation { get; set; }
        public virtual ICollection<BuyDetail> BuyDetails { get; set; }
    }
}
