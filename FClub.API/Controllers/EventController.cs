using FClub.Business.Service;
using FClub.Data.Database;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
namespace FClub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly EventInfoService _eventService;

        public EventController(EventInfoService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet()]
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

        [HttpGet("{id}")]
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

        [HttpPost()]
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


        [HttpPut()]
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

        [HttpPut("{id}")]
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
