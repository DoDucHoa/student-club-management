using System;
using System.Collections.Generic;

#nullable disable

namespace FClub.Data.Database
{
    public partial class Participant
    {
        public Participant()
        {
            EventTickets = new HashSet<EventTicket>();
        }

        public int Id { get; set; }
        public int EventId { get; set; }
        public int MemberId { get; set; }
        public DateTime? RegisDate { get; set; }
        public decimal? BonusPoint { get; set; }
        public bool? Attendance { get; set; }

        public virtual EventInfo Event { get; set; }
        public virtual Member Member { get; set; }
        public virtual ICollection<EventTicket> EventTickets { get; set; }
    }
}
