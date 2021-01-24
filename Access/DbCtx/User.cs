using System;
using System.Collections.Generic;

#nullable disable

namespace fpAPI.Access.DbCtx
{
    public partial class User
    {
        public User()
        {
            Buys = new HashSet<Buy>();
            Devolutions = new HashSet<Devolution>();
            ProductExpenses = new HashSet<ProductExpense>();
            Sales = new HashSet<Sale>();
        }

        public uint Id { get; set; }
        public uint RoleFk { get; set; }
        public uint OfficeFk { get; set; }
        public string FirstNames { get; set; }
        public string LastNames { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Street { get; set; }
        public string ExtNum { get; set; }
        public string IntNum { get; set; }
        public string Neighborhood { get; set; }
        public uint? Cp { get; set; }
        public byte[] Psw { get; set; }
        public DateTime? CreationDate { get; set; }

        public virtual Office OfficeFkNavigation { get; set; }
        public virtual Role RoleFkNavigation { get; set; }
        public virtual ICollection<Buy> Buys { get; set; }
        public virtual ICollection<Devolution> Devolutions { get; set; }
        public virtual ICollection<ProductExpense> ProductExpenses { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
    }
}
