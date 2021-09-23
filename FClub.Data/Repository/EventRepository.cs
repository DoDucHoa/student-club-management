using FClub.Data.Database;
using FClub.Data.Helper;
using FClub.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FClub.Data.Repository
{

    public class EventRepository : Repository<EventInfo>, IEventRepository 
    {

        ApplicationDbContext _dbContext;
        public EventRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }

        public void AddEvent(EventInfo eventinfo)
        {
            throw new NotImplementedException();
        }

        public async Task<EventInfo> Create(EventInfo _object)
        {
            var obj = await _dbContext.EventInfos.AddAsync(_object);
            _dbContext.SaveChanges();
            return obj.Entity;
        }

        public void Delete(EventInfo _object)
        {
            _dbContext.Remove(_object);
            _dbContext.SaveChanges();
        }

        public IEnumerable<EventInfo> GetAll()
        {
            return _dbContext.EventInfos.ToList();
        }

        public PagedList<EventInfo> getAllEvents(IEnumerable<EventInfo> events)
        {
            throw new NotImplementedException();
        }

        public EventInfo GetById(int Id)
        {
            return _dbContext.EventInfos.Where(x => x.Id.Equals(Id)).FirstOrDefault();
        }

        public EventInfo GetEventById(int id)
        {
            throw new NotImplementedException();
        }

        public EventInfo GetEventInDetailById(int id)
        {
            throw new NotImplementedException();
        }

        public void RemoveMajor(EventInfo eventinfo)
        {
            throw new NotImplementedException();
        }

        public void Update(EventInfo _object)
        {
            _dbContext.EventInfos.Update(_object);
            _dbContext.SaveChanges();
        }

        public void UpdateEvent(EventInfo eventinfo)
        {
            throw new NotImplementedException();
        }
    }
}
