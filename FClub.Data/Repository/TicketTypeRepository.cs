using FClub.Data.Database;
using FClub.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FClub.Data.Repository
{
    public class TicketTypeRepository : Repository<TicketType>, ITicketTypeRepository
    {
        ApplicationDbContext _dbContext;
        public TicketTypeRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }

        public int getBonusPointById(string id)
        {
            return _dbContext.TicketTypes.FirstOrDefault(e => e.Id.Equals(id)).BonusPoint;
        }
    }
}
