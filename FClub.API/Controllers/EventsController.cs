using FClub.Business.Service;
using FClub.Data.Database;
using FClub.Data.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
namespace FClub.API.Controllers
{
    [Route("api/v1/events")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly EventInfoService _eventService;

        public EventsController(EventInfoService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet()]
        public IActionResult GetAllEvent([FromQuery] PagingParameter paging, [FromQuery] EventInfoParameter eventInfo)
        {
            var data = _eventService.GetEvents(eventInfo, paging);
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
        public IActionResult GetEventById(int id)
        {
            var data = _eventService.GetEventById(id);
            
            return Ok(data);
        }

        [HttpPost()]
        public IActionResult AddEvent(EventInfo eventinfo)
        {
            if (_eventService.Add(eventinfo))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }


        [HttpPut()]
        public IActionResult UpdateEvent(EventInfo eventinfo)
        {
            if(_eventService.UpdateEvent(eventinfo))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEvent(int id)
        {
            if (_eventService.DeleteEvent(id))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

    }
}
