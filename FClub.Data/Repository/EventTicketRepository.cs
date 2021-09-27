using FClub.Data.Database;
using FClub.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FClub.Data.Repository
{
    public class EventTicketRepository : Repository<EventTicket>, IEventTicketRepository
    {

        ApplicationDbContext _dbContext;
        public EventTicketRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }

        public EventTicket GetById(int id)
        {
            return _dbContext.EventTickets.FirstOrDefault(e => e.Id == id);
        }

        public IEnumerable<EventTicket>  GetByParticipant(int parId)
        {
            return _dbContext.EventTickets.Where(e => e.ParticipantId == parId).ToList();
        }

        public IEnumerable<EventTicket> GetByType(string typeId)
        {
            return _dbContext.EventTickets.Where(e => e.TicketTypeId.Equals(typeId)).ToList();
        }

    }
}