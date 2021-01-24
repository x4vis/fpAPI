using System;
using System.Collections.Generic;

#nullable disable

namespace fpAPI.Access.DbCtx
{
    public partial class Provider
    {
        public Provider()
        {
            Buys = new HashSet<Buy>();
            OfficeProviders = new HashSet<OfficeProvider>();
            ProviderBanks = new HashSet<ProviderBank>();
            ProviderContacts = new HashSet<ProviderContact>();
            ProviderProducts = new HashSet<ProviderProduct>();
        }

        public uint Id { get; set; }
        public string PersonType { get; set; }
        public string Name { get; set; }
        public string ComercialName { get; set; }
        public string Rfc { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Street { get; set; }
        public string ExtNum { get; set; }
        public string IntNum { get; set; }
        public string Neighborhood { get; set; }
        public uint? Cp { get; set; }
        public DateTime? CreationDate { get; set; }

        public virtual ICollection<Buy> Buys { get; set; }
        public virtual ICollection<OfficeProvider> OfficeProviders { get; set; }
        public virtual ICollection<ProviderBank> ProviderBanks { get; set; }
        public virtual ICollection<ProviderContact> ProviderContacts { get; set; }
        public virtual ICollection<ProviderProduct> ProviderProducts { get; set; }
    }
}
