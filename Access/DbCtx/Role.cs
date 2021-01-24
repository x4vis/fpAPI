using System;
using System.Collections.Generic;

#nullable disable

namespace fpAPI.Access.DbCtx
{
    public partial class Role
    {
        public Role()
        {
            Users = new HashSet<User>();
        }

        public uint Id { get; set; }
        public string Name { get; set; }
        public byte Mask { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
