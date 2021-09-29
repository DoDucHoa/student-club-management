using FClub.Data.Database;
using FClub.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FClub.Data.Repository
{
    public class UserInforRepository : IRepository<UserInfo>
    {

        ApplicationDbContext _dbContext;
        public UserInforRepository(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }
        public async Task<UserInfo> Create(UserInfo _object)
        {
            var obj = await _dbContext.UserInfos.AddAsync(_object);
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
            return _dbContext.UserInfos.ToList();
        }

        public UserInfo GetById(int Id)
        {
            return _dbContext.UserInfos.Where(x => x.Id == Id).FirstOrDefault();
        }

        public void Update(UserInfo _object)
        {
            _dbContext.UserInfos.Update(_object);
            _dbContext.SaveChanges();
        }
    }
}
