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
        [HttpPost("AddUser")]
        public async Task<Object> AddUser([FromBody] UserInfo user)
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
        [HttpDelete("DeleteUser")]
        public bool DeleteUser(string email)
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
        [HttpPut("UpdateUser")]
        public bool UpdateUser(UserInfo Object)
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
        [HttpGet("GetAllUserByName")]
        public Object GetAllUserByName(string name)
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
    }
}
*/