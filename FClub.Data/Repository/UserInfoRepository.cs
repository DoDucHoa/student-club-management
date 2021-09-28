using FClub.Data.Database;
using FClub.Data.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FClub.Data.Repository
{
    public class UserInfoRepository : Repository<UserInfo>, IUserInfoRepository
    {
        ApplicationDbContext _dbContext;

        public UserInfoRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }
    }
}
