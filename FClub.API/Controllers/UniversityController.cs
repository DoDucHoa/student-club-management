/*using FClub.Business.Service;
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
    [Route("api/[controller]")]
    [ApiController]
    public class UniversityController : ControllerBase
    {
        private readonly UniversityService _universityService;

        private readonly IRepository<University> _repository;

        public UniversityController(IRepository<University> University, UniversityService UniversityService)
        {
            _universityService = UniversityService;
            _repository = University;

        }
        //Add User  
        [HttpPost("AddUniversity")]
        public async Task<Object> AddUniversity([FromBody] University university)
        {
            try
            {
                await _universityService.AddUniversity(university);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        //Delete User  
        [HttpDelete("DeleteUniversityByName")]
        public bool DeleteUniversityByName(string name)
        {
            try
            {
                _universityService.DeleteUniversityByName(name);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        //Delete User  
        [HttpPut("UpdateUniversity")]
        public bool UpdateUniversity(University Object)
        {
            try
            {
                _universityService.UpdateUniversity(Object);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        //GET All User by Name  
        [HttpGet("GetAllUniversityByName")]
        public Object GetAllUniversityByName(string name)
        {
            var data = _universityService.GetUniversityByName(name);
            var json = JsonConvert.SerializeObject(data, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                }
            );
            return json;
        }
        //GET All User  
        [HttpGet("GetAllUniversity")]
        public Object GetAllUniversity()
        {
            var data = _universityService.GetAllUniversity();
            var json = JsonConvert.SerializeObject(data, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                }
            );
            return json;
        }

        [HttpGet("GetUniversityById")]
        public Object GetUniversityById(string id)
        {
            var data = _universityService.GetUniversityById(id);
            var json = JsonConvert.SerializeObject(data, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                }
            );
            return json;
        }
    }
}
*/