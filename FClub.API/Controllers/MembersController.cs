﻿using FClub.Business.Service;
using FClub.Data.Database;
using FClub.Data.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FClub.API.Controllers
{
    [Route("api/v1/members")]
    [Authorize]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly MemberService _service;

        public MembersController(MemberService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<PagedList<Member>> Get([FromQuery] MemberParameter member, [FromQuery] PagingParameter paging)
        {
            var data = _service.GetBy(member, paging);
            var metadata = new
            {
                data.TotalCount,
                data.PageSize,
                data.CurrentPage,
                data.TotalPages,
                data.HasNext,
                data.HasPrevious
            };
            //Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
            return Ok(new { data, metadata });
        }

        [HttpGet]
        [Route("count")]
        public ActionResult<int> Count(string ClubId)
        {
            return Ok(_service.CountByClub(ClubId));
        }

        [HttpPost]
        public IActionResult Create(Member _object)
        {
            try
            {
                _service.Create(_object);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("approved")]
        public IActionResult Approved(int id)
        {
            var member = _service.GetById(id);
            if (member == null)
            {
                return NotFound();
            }
            member.IsApproved = true;
            _service.Update(member);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(Member _object)
        {
            if (_service.GetById(_object.Id) == null)
            {
                return NotFound();
            }
            _service.Update(_object);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_service.GetById(id) == null)
            {
                return NotFound();
            }
            _service.Delete(_service.GetById(id));
            return Ok();
        }
    }
}
