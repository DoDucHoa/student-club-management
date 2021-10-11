using System;
using System.Collections.Generic;

#nullable disable

namespace FClub.Data.Database
{
    public partial class Role
    {
        public Role()
        {
            Members = new HashSet<Member>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Member> Members { get; set; }
    }
}
