using BAL_CRUD.Service;
using DAL_CRUD.Interface;
using DAL_CRUD.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace club_management_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserInforController : ControllerBase
    {
        private readonly UserInforService _userInforService;

        private readonly IRepository<UserInfo> _UserInfor;

        public UserInforController(IRepository<UserInfo> UserInfor, UserInforService UsertService)
        {
            _userInforService = UsertService;
            _UserInfor = UserInfor;

        }
        //Add User  
        [HttpPost("AddPerson")]
        public async Task<Object> AddPerson([FromBody] UserInfo user)
        {
            try
            {
                await _userInforService.AddPerson(user);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        //Delete User  
        [HttpDelete("DeletePerson")]
        public bool DeletePerson(string email)
        {
            try
            {
                _userInforService.DeleteUser(email);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        //Delete User  
        [HttpPut("UpdatePerson")]
        public bool UpdatePerson(UserInfo Object)
        {
            try
            {
                _userInforService.UpdateUser(Object);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        //GET All User by Name  
        [HttpGet("GetAllPersonByName")]
        public Object GetAllPersonByName(string name)
        {
            var data = _userInforService.GetUserByName(name);
            var json = JsonConvert.SerializeObject(data, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                }
            );
            return json;
        }
        //GET All User  
        [HttpGet("GetAllPersons")]
        public Object GetAllPersons()
        {
            var data = _userInforService.GetAllUsersInfor();
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
