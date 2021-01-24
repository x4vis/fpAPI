using System;
using System.Collections.Generic;

#nullable disable

namespace fpAPI.Access.DbCtx
{
    public partial class ProductExpense
    {
        public uint Id { get; set; }
        public uint UserFk { get; set; }
        public uint ProductFk { get; set; }
        public string Reason { get; set; }
        public bool? Decrease { get; set; }
        public bool? Consumable { get; set; }
        public DateTime? CreationDate { get; set; }

        public virtual Product ProductFkNavigation { get; set; }
        public virtual User UserFkNavigation { get; set; }
    }
}
