using FClub.Data.Database;
using FClub.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FClub.Data.Repository
{
    public class ClubRepository : Repository<Club>, IClubRepository
    {
        private readonly ApplicationDbContext _db;
        public ClubRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public bool CheckIdExistance(String id)
        {
            var objFromDb = _db.Clubs.FirstOrDefault(s => s.Id == id);
            if (objFromDb == null)
                return false;
            return true;
        }
    }
}
