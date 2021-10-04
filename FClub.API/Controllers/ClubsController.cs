﻿using FClub.Business.Service;
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

        [HttpGet]
        public ActionResult<PagedList<Club>> GetClubs([FromQuery] ClubParameter club, [FromQuery] PagingParameter paging)
        {
            var data = _clubService.GetAllClub(club, paging);
            return data;
        }

        [HttpPost]
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


        [HttpPut]
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

        [HttpDelete("{id}")]
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
