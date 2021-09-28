using FClub.Data.Database;
using FClub.Data.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace FClub.Data.Repository
{
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        ApplicationDbContext _dbContext;

        public RoleRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }
    }
}
