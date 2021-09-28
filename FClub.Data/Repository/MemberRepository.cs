using FClub.Data.Database;
using FClub.Data.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace FClub.Data.Repository
{
    public class MemberRepository : Repository<Member>, IMemberRepository
    {
        ApplicationDbContext _dbContext;

        public MemberRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }
    }
}
