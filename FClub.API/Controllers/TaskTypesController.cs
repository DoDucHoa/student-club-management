﻿using FClub.Business.Service;
using FClub.Data.Database;
using FClub.Data.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FClub.API.Controllers
{
    [Route("api/v1/task-types")]
    [ApiController]
    public class TaskTypesController : ControllerBase
    {
        private readonly TaskTypeService _service;

        public TaskTypesController(TaskTypeService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<PagedList<TaskType>> Get([FromQuery] TaskTypeParameter taskType, [FromQuery] PagingParameter paging)
        {
            var data = _service.GetBy(taskType, paging);
            var metadata = new
            {
                data.TotalCount,
                data.PageSize,
                data.CurrentPage,
                data.TotalPages,
                data.HasNext,
                data.HasPrevious
            };
            return Ok(data);
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
