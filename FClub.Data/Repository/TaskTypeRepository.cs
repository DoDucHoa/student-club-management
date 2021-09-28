using FClub.Data.Database;
using FClub.Data.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace FClub.Data.Repository
{
    public class TaskTypeRepository : Repository<TaskType>, ITaskTypeRepository
    {
        ApplicationDbContext _dbContext;

        public TaskTypeRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }
    }
}
