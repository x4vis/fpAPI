using System;
using System.Collections.Generic;

#nullable disable

namespace fpAPI.Access.DbCtx
{
    public partial class Category
    {
        public Category()
        {
            Subcategories = new HashSet<Subcategory>();
        }

        public uint Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Subcategory> Subcategories { get; set; }
    }
}
