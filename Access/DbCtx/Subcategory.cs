using System;
using System.Collections.Generic;

#nullable disable

namespace fpAPI.Access.DbCtx
{
    public partial class Subcategory
    {
        public Subcategory()
        {
            Products = new HashSet<Product>();
        }

        public uint Id { get; set; }
        public uint CategoryFk { get; set; }
        public string Name { get; set; }

        public virtual Category CategoryFkNavigation { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
