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
    [Route("api/event-ticket")]
    [ApiController]
    public class EventTicketController : ControllerBase
    {
        private readonly EventTicketService _ticketService;

        public EventTicketController(EventTicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpGet("{id}")]
        public Object GetTicketById(int id)
        {
            var data = _ticketService.GetTicketById(id);
            var json = JsonConvert.SerializeObject(data, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                }
            );
            return json;
        }

        [HttpGet("participant/{parId}")]
        public Object GetTicketByParticipant(int parId)
        {
            var data = _ticketService.GetTicketByParticipant(parId);
            var json = JsonConvert.SerializeObject(data, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                }
            );
            return json;
        }

        [HttpGet("type/{typeId}")]
        public Object GetTicketByType(string typeId)
        {
            var data = _ticketService.GetTicketByType(typeId);
            var json = JsonConvert.SerializeObject(data, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                }
            );
            return json;
        }

        [HttpGet()]
        public Object GetAllTicket()
        {
            var data = _ticketService.GetAll();
            var json = JsonConvert.SerializeObject(data, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                }
            );
            return json;
        }

        [HttpPost()]
        public void AddTicket(EventTicket ticket)
        {
            try
            {
                _ticketService.Add(ticket);
            }
            catch (Exception e)
            {
                e.Message.ToString();
            }
        }


        [HttpPut()]
        public void UpdateTicket(EventTicket ticket)
        {
            try
            {
                _ticketService.Update(ticket);
            }
            catch (Exception e)
            {
                e.Message.ToString();
            }
        }

        [HttpDelete("{id}")]
        public bool DeleteTicket(int id)
        {
            try
            {
                _ticketService.DeleteById(id);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
