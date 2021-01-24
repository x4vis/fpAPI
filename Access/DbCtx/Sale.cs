using System;
using System.Collections.Generic;

#nullable disable

namespace fpAPI.Access.DbCtx
{
    public partial class Sale
    {
        public Sale()
        {
            SaleDetails = new HashSet<SaleDetail>();
        }

        public uint Id { get; set; }
        public uint UserFk { get; set; }
        public uint? ClientFk { get; set; }
        public uint TransactionNum { get; set; }
        public decimal Iva { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Total { get; set; }
        public uint ProductsQty { get; set; }
        public string Status { get; set; }
        public bool? OrderStatus { get; set; }
        public DateTime? CreationDate { get; set; }

        public virtual Client ClientFkNavigation { get; set; }
        public virtual User UserFkNavigation { get; set; }
        public virtual ICollection<SaleDetail> SaleDetails { get; set; }
    }
}
