using FClub.Business.Service;
using FClub.Data.Database;
using FClub.Data.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FClub.API.Controllers
{
    [Route("api/members")]
    [ApiController]
    [Authorize]
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
            return _service.GetBy(member, paging);
        }

        [HttpGet("{id}")]
        public ActionResult<Member> Get(int id)
        {
            return _service.GetById(id);
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
        public IActionResult Update(Member _object)
        {
            if (_service.GetById(_object.Id) == null)
            {
                return NotFound();
            }
            _service.Delete(_object);
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(Member _object)
        {
            if (_service.GetById(_object.Id) == null)
            {
                return NotFound();
            }
            _service.Delete(_object);
            return Ok();
        }
    }
}
