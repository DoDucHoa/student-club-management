using FClub.Data.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace FClub.Data.Interface
{
    public interface IClubRepository : IRepository<Club>
    {
        void Update(Club club);
        bool CheckIdExistance(String id);
    }
}
