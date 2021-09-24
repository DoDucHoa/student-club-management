using FClub.Data.Database;
using System.Collections.Generic;

namespace FClub.Data.Interface
{
    public interface IEventTicketRepository : IRepository<EventTicket>
    {
        EventTicket GetById(int id);
        IEnumerable<EventTicket> GetByParticipant(int parId);
        IEnumerable<EventTicket> GetByType(string typeId);
    }
}
