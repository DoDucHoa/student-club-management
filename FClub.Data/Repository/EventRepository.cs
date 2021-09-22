using FClub.Data.Database;
using FClub.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FClub.Data.Repository
{

    public class EventRepository : IRepository<EventInfo>
    {

        ApplicationDbContext _dbContext;
        public EventRepository(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
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

        public EventInfo GetById(int Id)
        {
            return _dbContext.EventInfos.Where(x => x.Id.Equals(Id)).FirstOrDefault();
        }

        public void Update(EventInfo _object)
        {
            _dbContext.EventInfos.Update(_object);
            _dbContext.SaveChanges();
        }
    }
}
