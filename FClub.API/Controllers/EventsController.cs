using FClub.Business.Service;
using FClub.Data.Database;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
namespace FClub.API.Controllers
{
    [Route("api/events")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly EventInfoService _eventService;

        public EventsController(EventInfoService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet("GetAllEvent")]
        public Object GetAllEvent()
        {
            var data = _eventService.getAll();
            var json = JsonConvert.SerializeObject(data, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                }
            );
            return json;
        }

        [HttpGet("GetEventById")]
        public Object GetEventById(int id)
        {
            var data = _eventService.GetEventById(id);
            var json = JsonConvert.SerializeObject(data, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                }
            );
            return json;
        }

        [HttpPost("AddEvent")]
        public void AddEvent(EventInfo eventinfo)
        {
            try
            {
                _eventService.Add(eventinfo);
            }
            catch (Exception e)
            {
                e.Message.ToString();
            }
        }


        [HttpPut("UpdateEvent")]
        public void UpdateEvent(EventInfo eventinfo)
        {
            try
            {
                _eventService.UpdateEvent(eventinfo);
            }
            catch (Exception e)
            {
                e.Message.ToString();
            }
        }

        [HttpPut("DisableEventById")]
        public bool DisableById(int id)
        {
            try
            {
                _eventService.DisableEventById(id);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
