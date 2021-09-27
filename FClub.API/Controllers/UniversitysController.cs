using FClub.Business.Service;
using FClub.Data.Database;
using FClub.Data.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FClub.API.Controllers
{
    [Route("api/universities")]
    [ApiController]
    public class UniversitysController : ControllerBase
    {
        private readonly UniversityService _universityService;

        public UniversitysController(UniversityService UniversityService)
        {
            _universityService = UniversityService;
        }
        //Add University  
        [HttpPost]
        public IActionResult AddUniversity([FromBody] University university)
        {
            if (_universityService.AddUniversity(university))
            {
                return Ok();
            }
            return BadRequest();
        }
        //Delete University  
        [HttpDelete]
        public IActionResult DeleteUniversity(University university)
        {
            if (_universityService.GetUniversityById(university.Id) == null)
            {
                return NotFound();
            }
            _universityService.DeleteUniversity(university);
            return Ok();
        }
        //Update University  
        [HttpPut]
        public IActionResult UpdateUniversity(University university)
        {
            if (_universityService.GetUniversityById(university.Id) == null)
            {
                return NotFound();
            }
            _universityService.UpdateUniversity(university);
            return Ok();
        }
        //GET All University  
        [HttpGet]
        public ActionResult<List<University>> GetAllUniversity()
        {
            var data = _universityService.GetAllUniversity();
            return data;
        }

        [HttpGet("{id}")]
        public ActionResult<University> GetUniversityById(string id)
        {
            var data = _universityService.GetUniversityById(id);
            return data;
        }
    }
}