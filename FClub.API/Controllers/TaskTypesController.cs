using FClub.Business.Service;
using FClub.Data.Database;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FClub.API.Controllers
{
    [Route("api/tasktypes")]
    [ApiController]
    public class TaskTypesController : ControllerBase
    {
        private readonly TaskTypeService _service;

        public TaskTypesController(TaskTypeService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<TaskType>> Get()
        {
            return _service.Get();
        }

        [HttpGet("{id}")]
        public ActionResult<TaskType> Get(string id)
        {
            return _service.GetById(id);
        }

        [HttpPost]
        public IActionResult Create(TaskType _object)
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
        public IActionResult Update(TaskType _object)
        {
            if (_service.GetById(_object.Id) == null)
            {
                return NotFound();
            }
            _service.Delete(_object);
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(TaskType _object)
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
