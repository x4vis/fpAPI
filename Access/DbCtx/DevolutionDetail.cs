using System;
using System.Collections.Generic;

#nullable disable

namespace fpAPI.Access.DbCtx
{
    public partial class DevolutionDetail
    {
        public uint Id { get; set; }
        public uint DevolutionFk { get; set; }
        public uint ProductFk { get; set; }
        public decimal Total { get; set; }

        public virtual Devolution DevolutionFkNavigation { get; set; }
        public virtual Product ProductFkNavigation { get; set; }
    }
}
