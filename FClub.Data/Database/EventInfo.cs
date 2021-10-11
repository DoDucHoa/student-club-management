using System;
using System.Collections.Generic;

#nullable disable

namespace FClub.Data.Database
{
    public partial class EventInfo
    {
        public EventInfo()
        {
            Participants = new HashSet<Participant>();
        }

        public int Id { get; set; }
        public int CreatorId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime RegisDate { get; set; }
        public DateTime EndRegisDate { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime DueDate { get; set; }
        public decimal? BonusPoint { get; set; }
        public int? LimitJoin { get; set; }
        public string Image { get; set; }
        public string Location { get; set; }
        public bool? Status { get; set; }

        public virtual Member Creator { get; set; }
        public virtual ICollection<Participant> Participants { get; set; }
    }
}
