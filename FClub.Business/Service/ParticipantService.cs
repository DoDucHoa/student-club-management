using FClub.Data.Database;
using FClub.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FClub.Business.Service
{
    public class ParticipantService
    {
        private readonly IParticipantRepository _participantRepo;

        public ParticipantService(IParticipantRepository participantRepo)
        {
            _participantRepo = participantRepo;
        }

        //GET All Participant
        public IEnumerable<Participant> getAll()
        {
            return _participantRepo.GetAll().ToList();
        }

        //Get Participant By Event
        public IEnumerable<Participant> GetParticipantByEvent(int eventId)
        {
            return _participantRepo.GetParticipantByEvent(eventId);
        }
        //Get Participant By Attendance
        public IEnumerable<Participant> GetParticipantByAttendance(bool attended)
        {
            return _participantRepo.GetParticipantByAttendance(attended);
        }
        //Add Participant
        public void Add(Participant participant)
        {
            _participantRepo.Add(participant);
            _participantRepo.SaveDbChange();
        }
        //Delete Participant 
        public void Delete(Participant participant)
        {
            _participantRepo.Remove(participant);
            _participantRepo.SaveDbChange();
        }
        //Update Participant  
        public void Update(Participant participant)
        {
            _participantRepo.Update(participant);
            _participantRepo.SaveDbChange();
        }
    }
}
