using System;
using System.Collections.Generic;

#nullable disable

namespace fpAPI.Access.DbCtx
{
    public partial class OfficeProduct
    {
        public OfficeProduct()
        {
            OfficeProductHistories = new HashSet<OfficeProductHistory>();
        }

        public uint Id { get; set; }
        public uint OfficeFk { get; set; }
        public uint ProductFk { get; set; }
        public decimal Stock { get; set; }
        public decimal SellPrice { get; set; }
        public decimal Utility { get; set; }

        public virtual Office OfficeFkNavigation { get; set; }
        public virtual Product ProductFkNavigation { get; set; }
        public virtual ICollection<OfficeProductHistory> OfficeProductHistories { get; set; }
    }
}
