using System;
using System.Collections.Generic;

#nullable disable

namespace fpAPI.Access.DbCtx
{
    public partial class OfficeProvider
    {
        public uint Id { get; set; }
        public uint OfficeFk { get; set; }
        public uint ProviderFk { get; set; }

        public virtual Office OfficeFkNavigation { get; set; }
        public virtual Provider ProviderFkNavigation { get; set; }
    }
}
