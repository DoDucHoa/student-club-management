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
    [Route("api/users")]
    [ApiController]
    public class UserInfosController : ControllerBase
    {
        private readonly UserInforService _userInforService;

        public UserInfosController(UserInforService UsertService)
        {
            _userInforService = UsertService;
        }
        //Add User  
        [HttpPost]
        public IActionResult AddUser([FromBody] UserInfo user)
        {
            try
            {
                _userInforService.AddUserInfo(user);
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
        //Delete User  
        [HttpDelete]
        public IActionResult DeleteUser(UserInfo _object)
        {
            if (_userInforService.GetUsersById(_object.Id) == null)
            {
                return NotFound();
            }
            _userInforService.DeleteUser(_object);
            return Ok();
        }
        //Delete User  
        [HttpPut]
        public IActionResult UpdateUser(UserInfo _object)
        {
            if (_userInforService.GetUsersById(_object.Id) == null)
            {
                return NotFound();
            }
            _userInforService.UpdateUser(_object);
            return Ok();
        }
        //GET All User by Name  
        [HttpGet("{name}")]
        public ActionResult<List<UserInfo>> GetAllUserByName(string name)
        {
            var data = _userInforService.GetUsersByName(name);
            return data;
        }
        //GET All User  
        [HttpGet]
        public ActionResult<List<UserInfo>> GetAllUsers()
        {
            var data = _userInforService.GetAllUsersInfor();;
            return data;
        }
        //Check Login
        [HttpGet("{email}/{password}")]
        public ActionResult<UserInfo> CheckLogin(string email, string password)
        {
            var data = _userInforService.CheckLogin(email, password);
            return data;
        }
    }
}
