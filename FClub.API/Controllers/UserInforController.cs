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
    public class UserInforController : ControllerBase
    {
        private readonly UserInforService _userInforService;

        public UserInforController(UserInforService UsertService)
        {
            _userInforService = UsertService;
        }
        //Add User  
        [HttpPost("AddUser")]
        public bool AddUser([FromBody] UserInfo user)
        {
            try
            {
                _userInforService.AddUserInfo(user);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        //Delete User  
        [HttpDelete("DeleteUser")]
        public bool DeleteUser(UserInfo _object)
        {
            return _userInforService.DeleteUser(_object);
        }
        //Delete User  
        [HttpPut("UpdateUser")]
        public bool UpdateUser(UserInfo Object)
        {
            return _userInforService.UpdateUser(Object);
        }
        //GET All User by Name  
        [HttpGet("GetAllUserByName")]
        public Object GetAllUserByName(string name)
        {
            var data = _userInforService.GetUsersByName(name);
            var json = JsonConvert.SerializeObject(data, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                }
            );
            return json;
        }
        //GET All User  
        [HttpGet("GetAllUsers")]
        public Object GetAllUsers()
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
        //Check Login
        [HttpGet("CheckLogin")]
        public Object CheckLogin(string email, string password)
        {
            var data = _userInforService.CheckLogin(email, password);
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
