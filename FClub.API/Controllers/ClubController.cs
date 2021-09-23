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
    public class ClubController : ControllerBase
    {
        private readonly ClubService _clubService;

        public ClubController(ClubService clubService)
        {
            _clubService = clubService;
        }

        [HttpGet("GetClubById")]
        public Object GetClubById(string id)
        {
            var data = _clubService.GetClubById(id);
            var json = JsonConvert.SerializeObject(data, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                }
            );
            return json;
        }

        [HttpPost("AddClub")]
        public void AddClub(Club club)
        {
            try
            {
                _clubService.Add(club);
            }
            catch(Exception e)
            {
                e.Message.ToString();
            }
        }


        [HttpPut("UpdateClub")]
        public void UpdateClub(Club club)
        {
            try
            {
                _clubService.Update(club);
            }
            catch (Exception e)
            {
                e.Message.ToString();
            }
        }

        [HttpDelete("DeleteClubById")]
        public bool DeleteClubById(string id)
        {
            try
            {
                _clubService.DeleteById(id);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
