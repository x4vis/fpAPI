using System;
using System.Collections.Generic;

#nullable disable

namespace fpAPI.Access.DbCtx
{
    public partial class Client
    {
        public Client()
        {
            Sales = new HashSet<Sale>();
        }

        public uint Id { get; set; }
        public uint OfficeFk { get; set; }
        public uint? ClientFiscalFk { get; set; }
        public string FirstNames { get; set; }
        public string LastNames { get; set; }
        public string Email { get; set; }
        public string Landline { get; set; }
        public string MobilePhone { get; set; }
        public DateTime? CreationDate { get; set; }

        public virtual FiscalClient ClientFiscalFkNavigation { get; set; }
        public virtual Office OfficeFkNavigation { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
    }
}
