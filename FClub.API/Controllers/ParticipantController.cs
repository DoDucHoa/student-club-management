using FClub.Business.Service;
using FClub.Data.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FClub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipantController : ControllerBase
    {
        private readonly ParticipantService _participantService;

        public ParticipantController(ParticipantService participantService)
        {
            _participantService = participantService;
        }


        [HttpGet("{eventId}")]
        public Object GetParticipantByEvent(int eventId)
        {
            var data = _participantService.GetParticipantByEvent(eventId);
            var json = JsonConvert.SerializeObject(data, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                }
            );
            return json;
        }

        [HttpGet("{attendance}")]
        public Object GetParticipantByAttendance(bool attended)
        {
            var data = _participantService.GetParticipantByAttendance(attended);
            var json = JsonConvert.SerializeObject(data, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                }
            );
            return json;
        }

        [HttpPost()]
        public void AddParticipant(Participant participant)
        {
            try
            {
                _participantService.Add(participant);
            }
            catch (Exception e)
            {
                e.Message.ToString();
            }
        }


        [HttpPut()]
        public void UpdateParticipant(Participant participant)
        {
            try
            {
                _participantService.Update(participant);
            }
            catch (Exception e)
            {
                e.Message.ToString();
            }
        }

        [HttpDelete("{id}")]
        public bool DeleteParticipant(int id)
        {
            try
            {
                Participant participant = _participantService.getAll().FirstOrDefault(p => p.Id == id);
                _participantService.Delete(participant);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
