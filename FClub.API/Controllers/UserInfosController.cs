﻿using FClub.Business.Service;
using FClub.Data.Database;
using FClub.Data.Helper;
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
        [HttpGet("fields")]
        public IActionResult GetUsers([FromQuery] UserParameter user, [FromQuery] PagingParameter param)
        {
            var data = _userInforService.GetUsersInfor(user, param);
            var metadata = new
            {
                data.TotalCount,
                data.PageSize,
                data.CurrentPage,
                data.TotalPages,
                data.HasNext,
                data.HasPrevious
            };
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
            return Ok(data);
        }
        //GET All User  
        [HttpGet]
        public ActionResult<List<UserInfo>> GetAllUsers()
        {
            var data = _userInforService.GetAllUsersInfor();
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