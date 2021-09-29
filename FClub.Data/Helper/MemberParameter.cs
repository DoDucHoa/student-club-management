using System;
using System.Collections.Generic;
using System.Text;

namespace FClub.Data.Helper
{
    public class MemberParameter
    {
        public int? Id { get; set; } = null;
        public int? UserId { get; set; } = null;
        public string ClubId { get; set; } = null;
        public int? RoleId { get; set; } = null;
        public string dir { get; set; } = "asc";
        public string sort { get; set; } = null;
        public string fields { get; set; } = null;
    }
}
