using System;
using System.Collections.Generic;

#nullable disable

namespace FClub.Data.Database
{
    public partial class Task
    {
        public Task()
        {
            MemberTasks = new HashSet<MemberTask>();
        }

        public int Id { get; set; }
        public string TypeId { get; set; }
        public int CreatorId { get; set; }
        public decimal? AwardPoint { get; set; }
        public decimal? PennaltyPoint { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime DueDate { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int? LimitJoin { get; set; }
        public bool? Status { get; set; }

        public virtual Member Creator { get; set; }
        public virtual TaskType Type { get; set; }
        public virtual ICollection<MemberTask> MemberTasks { get; set; }
    }
}
