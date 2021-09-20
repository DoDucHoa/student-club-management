using DAL_CRUD.Data;
using DAL_CRUD.Interface;
using DAL_CRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_CRUD.Repository
{
    public class UserInforRepository : IRepository<UserInfo>
    {

        ApplicationDBContext _dbContext;
        public UserInforRepository(ApplicationDBContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }
        public async Task<UserInfo> Create(UserInfo _object)
        {
            var obj = await _dbContext.UserInfo.AddAsync(_object);
            _dbContext.SaveChanges();
            return obj.Entity;
        }

        public void Delete(UserInfo _object)
        {
            _dbContext.Remove(_object);
            _dbContext.SaveChanges();
        }

        public IEnumerable<UserInfo> GetAll()
        {
            return _dbContext.UserInfo.ToList();
        }

        public UserInfo GetById(int Id)
        {
            return _dbContext.UserInfo.Where(x => x.Id == Id).FirstOrDefault();
        }

        public void Update(UserInfo _object)
        {
            _dbContext.UserInfo.Update(_object);
            _dbContext.SaveChanges();
        }
    }
}
