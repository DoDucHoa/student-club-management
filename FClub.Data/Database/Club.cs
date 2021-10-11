using System;
using System.Collections.Generic;

#nullable disable

namespace FClub.Data.Database
{
    public partial class Club
    {
        public Club()
        {
            Members = new HashSet<Member>();
        }

        public string Id { get; set; }
        public string UniversityId { get; set; }
        public string Name { get; set; }
        public decimal? Balance { get; set; }
        public string Logo { get; set; }
        public string About { get; set; }

        public virtual University University { get; set; }
        public virtual ICollection<Member> Members { get; set; }
    }
}
