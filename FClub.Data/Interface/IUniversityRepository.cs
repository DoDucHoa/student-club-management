using FClub.Data.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace FClub.Data.Interface
{
    public interface IUniversityRepository : IRepository<University>
    {
        void Update(University _object);
    }
}
