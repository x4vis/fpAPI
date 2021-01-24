using System;
using System.Collections.Generic;

#nullable disable

namespace fpAPI.Access.DbCtx
{
    public partial class Discount
    {
        public Discount()
        {
            Products = new HashSet<Product>();
        }

        public uint Id { get; set; }
        public decimal Qty { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
