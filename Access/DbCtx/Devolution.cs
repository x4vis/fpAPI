using System;
using System.Collections.Generic;

#nullable disable

namespace fpAPI.Access.DbCtx
{
    public partial class Devolution
    {
        public Devolution()
        {
            DevolutionDetails = new HashSet<DevolutionDetail>();
        }

        public uint Id { get; set; }
        public uint UserFk { get; set; }
        public decimal Total { get; set; }
        public uint ProductsQty { get; set; }
        public string Reason { get; set; }
        public DateTime? CreationDate { get; set; }

        public virtual User UserFkNavigation { get; set; }
        public virtual ICollection<DevolutionDetail> DevolutionDetails { get; set; }
    }
}
