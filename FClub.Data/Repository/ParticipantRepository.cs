using FClub.Data.Database;
using FClub.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FClub.Data.Repository
{
    public class ParticipantRepository : Repository<Participant>, IParticipantRepository
    {

        ApplicationDbContext _dbContext;
        public ParticipantRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }

        public IEnumerable<Participant> GetParticipantByAttendance(bool Attended)
        {
            return _dbContext.Participants.Where(p => p.Attendance == Attended).ToList();
        }

        public IEnumerable<Participant> GetParticipantByEvent(int eventId)
        {
            return _dbContext.Participants.Where(p => p.EventId == eventId).ToList();
        }
    }
}
