using FClub.Data.Database;
using FClub.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FClub.Data.Repository
{

    public class UniversityRepository : IRepository<University>
    {

        ApplicationDbContext _dbContext;
        public UniversityRepository(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }

        public async Task<University> Create(University _object)
        {
            var obj = await _dbContext.Universities.AddAsync(_object);
            _dbContext.SaveChanges();
            return obj.Entity;
        }

        public void Delete(University _object)
        {
            _dbContext.Remove(_object);
            _dbContext.SaveChanges();
        }

        public IEnumerable<University> GetAll()
        {
            return _dbContext.Universities.ToList();
        }

        public University GetById(int Id)
        {
            return _dbContext.Universities.Where(x => x.Id.Equals(Id)).FirstOrDefault();
        }

        public void Update(University _object)
        {
            _dbContext.Universities.Update(_object);
            _dbContext.SaveChanges();
        }
    }
}
