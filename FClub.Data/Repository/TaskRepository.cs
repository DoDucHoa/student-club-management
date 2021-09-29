using FClub.Data.Database;
using FClub.Data.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace FClub.Data.Repository
{
    public class TaskRepository : Repository<Task>, ITaskRepository
    {
        ApplicationDbContext _dbContext;

        public TaskRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }
    }
}
