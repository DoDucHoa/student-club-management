using FClub.Business.Service;
using FClub.Data.Database;
using FClub.Data.Helper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;

namespace FClub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketTypeController : ControllerBase
    {
        private readonly TicketTypeService _ticketTypeService;

        public TicketTypeController(TicketTypeService ticketTypeService)
        {
            _ticketTypeService = ticketTypeService;
        }

        [HttpGet]
        public IActionResult GetTicketType([FromQuery] TicketTypeParameter ticketType, [FromQuery] PagingParameter param)
        {
            var data = _ticketTypeService.GetBy(ticketType, param);
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
        public Object GetTypeById(string id)
        {
            var data = _ticketTypeService.GetTicketTypeById(id);
            var json = JsonConvert.SerializeObject(data, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                }
            );
            return json;
        }

        [HttpPost]
        public void AddType(TicketType ticketType)
        {
            try
            {
                _ticketTypeService.Add(ticketType);
            }
            catch (Exception e)
            {
                e.Message.ToString();
            }
        }


        [HttpPut]
        public void UpdateType(TicketType ticketType)
        {
            try
            {
                _ticketTypeService.Update(ticketType);
            }
            catch (Exception e)
            {
                e.Message.ToString();
            }
        }

        [HttpDelete("{id}")]
        public bool DeleteType(string id)
        {
            try
            {
                TicketType ticketType = _ticketTypeService.GetTicketTypeById(id);
                _ticketTypeService.Delete(ticketType);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
