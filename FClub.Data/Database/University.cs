using System;
using System.Collections.Generic;

#nullable disable

namespace FClub.Data.Database
{
    public partial class University
    {
        public University()
        {
            Clubs = new HashSet<Club>();
            UserInfos = new HashSet<UserInfo>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public string Address { get; set; }

        public virtual ICollection<Club> Clubs { get; set; }
        public virtual ICollection<UserInfo> UserInfos { get; set; }
    }
}
