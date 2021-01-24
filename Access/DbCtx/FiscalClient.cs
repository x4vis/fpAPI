using System;
using System.Collections.Generic;

#nullable disable

namespace fpAPI.Access.DbCtx
{
    public partial class FiscalClient
    {
        public FiscalClient()
        {
            Clients = new HashSet<Client>();
        }

        public uint Id { get; set; }
        public string Rfc { get; set; }
        public string RazonSocial { get; set; }
        public string Email { get; set; }
        public string Street { get; set; }
        public string ExtNum { get; set; }
        public string IntNum { get; set; }
        public string Neighborhood { get; set; }
        public uint? Cp { get; set; }
        public string PhoneNumber { get; set; }
        public string Town { get; set; }
        public string State { get; set; }

        public virtual ICollection<Client> Clients { get; set; }
    }
}
