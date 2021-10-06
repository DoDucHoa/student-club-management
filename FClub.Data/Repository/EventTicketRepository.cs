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

        readonly ApplicationDbContext _dbContext;
        public EventTicketRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }


    }
}