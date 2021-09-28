using FClub.Data.Database;
using FClub.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FClub.Data.Repository
{
    public class UserInforRepository : Repository<UserInfo>, IUserInfoRepository
    {
        readonly ApplicationDbContext _dbContext;

        public UserInforRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }

    }
}
