using System;
using System.Collections.Generic;

#nullable disable

namespace FClub.Data.Database
{
    public partial class TicketType
    {
        public TicketType()
        {
            EventTickets = new HashSet<EventTicket>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public decimal? BonusPoint { get; set; }
        public decimal? Price { get; set; }

        public virtual ICollection<EventTicket> EventTickets { get; set; }
    }
}
