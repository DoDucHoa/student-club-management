using FClub.Data.Database;
using FClub.Data.Helper;
using FClub.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FClub.Data.Repository
{

    public class EventRepository : Repository<EventInfo>, IEventRepository 
    {

        readonly ApplicationDbContext _dbContext;
        public EventRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }

        public void DisableEvent(int id)
        {
            var eventinfo = _dbContext.EventInfos.FirstOrDefault(s => s.Id == id);
            eventinfo.Status = false;
            _dbContext.EventInfos.Update(eventinfo);
            _dbContext.SaveChanges();
        }
    }
}
