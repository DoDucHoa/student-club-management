using System;
using System.Collections.Generic;

#nullable disable

namespace FClub.Data.Database
{
    public partial class UserInfo
    {
        public UserInfo()
        {
            Members = new HashSet<Member>();
        }

        public int Id { get; set; }
        public string UniversityId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public DateTime? Birthday { get; set; }
        public int? Gender { get; set; }
        public string Photo { get; set; }
        public string Bio { get; set; }

        public virtual University University { get; set; }
        public virtual ICollection<Member> Members { get; set; }
    }
}
