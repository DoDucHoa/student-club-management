using FClub.Business.Service;
using FClub.Data.Database;
using FClub.Data.Helper;
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

        [HttpGet()]
        public IActionResult GetAllEvent([FromQuery] QueryStringParameters eventParameter)
        {
            var data = _eventService.GetEvents(eventParameter);
            var metadata = new
            {
                data.TotalCount,
                data.PageSize,
                data.CurrentPage,
                data.TotalPages,
                data.HasNext,
                data.HasPrevious
            };
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
            return Ok(data);
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

        [HttpGet("page/{pageId}")]
        public Object GetEventByPage(int pageId)
        {
            var data = _eventService.getByPage(pageId);
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
