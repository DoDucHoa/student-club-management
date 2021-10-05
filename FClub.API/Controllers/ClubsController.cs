using FClub.Business.Service;
using FClub.Data.Database;
using Microsoft.AspNetCore.Authorization;
using FClub.Data.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FClub.API.Controllers
{
    [Route("api/clubs")]
    [ApiController]
    [Authorize]
    public class ClubsController : ControllerBase
    {
        private readonly ClubService _clubService;

        public ClubsController(ClubService clubService)
        {
            _clubService = clubService;
        }

        [HttpGet("{id}")]
        public ActionResult<Club> GetClubById(string id)
        {
            var data = _clubService.GetClubById(id);
            
            return data;
        }

        [HttpGet]
        public ActionResult<PagedList<Club>> GetClubs([FromQuery] ClubParameter club, [FromQuery] PagingParameter paging)
        {
            var data = _clubService.GetAllClub(club, paging);
            return data;
        }

        [HttpPost]
        public IActionResult AddClub(Club club)
        {
            if(_clubService.Add(club))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }


        [HttpPut]
        public IActionResult UpdateClub(Club club)
        {

            if (_clubService.Update(club))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteClubById(string id)
        {
            if (_clubService.DeleteById(id))
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
