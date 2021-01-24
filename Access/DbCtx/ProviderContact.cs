using System;
using System.Collections.Generic;

#nullable disable

namespace fpAPI.Access.DbCtx
{
    public partial class ProviderContact
    {
        public uint Id { get; set; }
        public uint ProviderFk { get; set; }
        public string FirstNames { get; set; }
        public string LastNames { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Position { get; set; }

        public virtual Provider ProviderFkNavigation { get; set; }
    }
}
