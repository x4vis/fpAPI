using System;
using System.Collections.Generic;

#nullable disable

namespace fpAPI.Access.DbCtx
{
    public partial class ProviderBank
    {
        public uint Id { get; set; }
        public uint ProviderFk { get; set; }
        public string Name { get; set; }
        public string AccountNumber { get; set; }
        public ulong Clabe { get; set; }
        public string AccountHolder { get; set; }

        public virtual Provider ProviderFkNavigation { get; set; }
    }
}
