using FClub.Data.Database;
using FClub.Data.Interface;
using FClub.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FClub.Data.Repository
{
    public class MemberTaskRepository : Repository<MemberTask>, IMemberTaskRepository
    {
        private readonly ApplicationDbContext _db;
        public MemberTaskRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
