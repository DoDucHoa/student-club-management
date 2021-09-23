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
    [Route("api/[controller]")]
    [ApiController]
    public class UniversityController : ControllerBase
    {
        private readonly UniversityService _universityService;

        public UniversityController(UniversityService UniversityService)
        {
            _universityService = UniversityService;
        }
        //Add University  
        [HttpPost("AddUniversity")]
        public bool AddUniversity([FromBody] University university)
        {
            return _universityService.AddUniversity(university);
        }
        //Delete University  
        [HttpDelete("DeleteUniversityByName")]
        public bool DeleteUniversityByName(string name)
        {
            return _universityService.DeleteUniversityByName(name);
        }
        //Update University  
        [HttpPut("UpdateUniversity")]
        public bool UpdateUniversity(University Object)
        {
            return _universityService.UpdateUniversity(Object);
        }
        //GET All University By Name  
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
        //GET All University  
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