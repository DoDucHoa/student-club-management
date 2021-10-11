using System;
using System.Collections.Generic;

#nullable disable

namespace FClub.Data.Database
{
    public partial class EventTicket
    {
        public int Id { get; set; }
        public int ParticipantId { get; set; }
        public string TicketTypeId { get; set; }

        public virtual Participant Participant { get; set; }
        public virtual TicketType TicketType { get; set; }
    }
}
