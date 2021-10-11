using System;
using System.Collections.Generic;

#nullable disable

namespace FClub.Data.Database
{
    public partial class Member
    {
        public Member()
        {
            EventInfos = new HashSet<EventInfo>();
            MemberTasks = new HashSet<MemberTask>();
            Participants = new HashSet<Participant>();
            Tasks = new HashSet<Task>();
            Wallets = new HashSet<Wallet>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public string ClubId { get; set; }
        public int RoleId { get; set; }
        public bool? Status { get; set; }

        public virtual Club Club { get; set; }
        public virtual Role Role { get; set; }
        public virtual UserInfo User { get; set; }
        public virtual ICollection<EventInfo> EventInfos { get; set; }
        public virtual ICollection<MemberTask> MemberTasks { get; set; }
        public virtual ICollection<Participant> Participants { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
        public virtual ICollection<Wallet> Wallets { get; set; }
    }
}
