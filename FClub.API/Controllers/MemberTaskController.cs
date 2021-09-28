using FClub.Data.Database;
using FClub.Business.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FClub.API.Controllers
{
    [Route("api/memberTasks")]
    [ApiController]
    public class MemberTaskController : ControllerBase
    {
        private readonly MemberTaskService _memberTaskService;

        public MemberTaskController(MemberTaskService memberTaskService)
        {
            _memberTaskService = memberTaskService;
        }

        [HttpGet("{id}")]
        public Object GetMemberTaskById(int id)
        {
            var data = _memberTaskService.GetMemberTaskById(id);
            var json = JsonConvert.SerializeObject(data, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                }
            );
            return json;
        }

        [HttpGet]
        public Object GetList()
        {
            var data = _memberTaskService.GetList();
            var json = JsonConvert.SerializeObject(data, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                }
            );
            return json;
        }

        [HttpPost]
        public void AddMemberTask(MemberTask memberTask)
        {
            try
            {
                _memberTaskService.Add(memberTask);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message.ToString());
            }
        }


        [HttpPut]
        public void UpdateMemberTask(MemberTask memberTask)
        {
            try
            {
                _memberTaskService.Update(memberTask);
            }
            catch (Exception e)
            {
                e.Message.ToString();
            }
        }

        [HttpDelete("{id}")]
        public bool DeleteMemberTaskById(int id)
        {
            try
            {
                _memberTaskService.DeleteById(id);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
