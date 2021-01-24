using System;
using System.Collections.Generic;

#nullable disable

namespace fpAPI.Access.DbCtx
{
    public partial class MeasurementUnit
    {
        public MeasurementUnit()
        {
            Products = new HashSet<Product>();
        }

        public uint Id { get; set; }
        public string MuKey { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
