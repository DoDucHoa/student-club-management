﻿using FClub.Business.Service;
using FClub.Data.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FClub.API.Controllers
{
    [Route("api/tasks")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly TaskService _service;

        public TasksController(TaskService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<Task>> Get()
        {
            return _service.Get();
        }

        [HttpGet("{id}")]
        public ActionResult<Task> Get(int id)
        {
            return _service.GetById(id);
        }

        [HttpPost]
        public IActionResult Create(Task _object)
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
        public IActionResult Update(Task _object)
        {
            if (_service.GetById(_object.Id) == null)
            {
                return NotFound();
            }
            _service.Delete(_object);
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(Task _object)
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