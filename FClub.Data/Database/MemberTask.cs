using System;
using System.Collections.Generic;

#nullable disable

namespace FClub.Data.Database
{
    public partial class MemberTask
    {
        public int Id { get; set; }
        public int TaskId { get; set; }
        public int MemberId { get; set; }
        public DateTime? CompleteDate { get; set; }
        public decimal? AwardPoint { get; set; }
        public string Evidence { get; set; }
        public bool? IsFinish { get; set; }

        public virtual Member Member { get; set; }
        public virtual Task Task { get; set; }
    }
}
