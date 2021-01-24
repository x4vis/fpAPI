using System;
using System.Collections.Generic;

#nullable disable

namespace fpAPI.Access.DbCtx
{
    public partial class Office
    {
        public Office()
        {
            Clients = new HashSet<Client>();
            OfficeProducts = new HashSet<OfficeProduct>();
            OfficeProviders = new HashSet<OfficeProvider>();
            Users = new HashSet<User>();
        }

        public uint Id { get; set; }
        public string Name { get; set; }
        public DateTime? CreationDate { get; set; }

        public virtual ICollection<Client> Clients { get; set; }
        public virtual ICollection<OfficeProduct> OfficeProducts { get; set; }
        public virtual ICollection<OfficeProvider> OfficeProviders { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
