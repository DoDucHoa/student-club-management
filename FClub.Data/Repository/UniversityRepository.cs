using FClub.Data.Database;
using FClub.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FClub.Data.Repository
{

    public class UniversityRepository : Repository<University> , IUniversityRepository
    {

        ApplicationDbContext _dbContext;
        public UniversityRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }

        public void Create(University _object)
        {
            _dbContext.Universities.AddAsync(_object);
            _dbContext.SaveChanges();
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

        public University GetById(string Id)
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