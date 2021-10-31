﻿using FClub.Business.Service;
using FClub.Data.Database;
using FClub.Data.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FClub.API.Controllers
{
    [Route("api/v1/events")]
    [ApiController]
    [Authorize]
    public class EventsController : ControllerBase
    {
        private readonly EventInfoService _eventService;
        private readonly FCMService _noti;
        private readonly MemberService _memberService;
        private readonly ClubService _clubService;
        private readonly UserInforService _userService;
        public EventsController(EventInfoService eventService, FCMService noti, MemberService memberService, ClubService clubService, UserInforService userService)
        {
            _eventService = eventService;
            _noti = noti;
            _memberService = memberService;
            _clubService = clubService;
            _userService = userService;
        }

        [HttpGet()]
        public IActionResult GetAllEvent([FromQuery] PagingParameter paging, [FromQuery] EventInfoParameter eventInfo)
        {
            var data = _eventService.GetEvents(eventInfo, paging);
            var metadata = new
            {
                data.TotalCount,
                data.PageSize,
                data.CurrentPage,
                data.TotalPages,
                data.HasNext,
                data.HasPrevious
            };
            //Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
            return Ok(new { data, metadata });
        }

        [HttpPost()]
        public IActionResult AddEvent(EventInfo eventinfo)
        {
            int id = -1;
            if ((id = _eventService.Add(eventinfo)) != -1)
            {
                Club club = _clubService.GetClubById(_memberService.GetById(eventinfo.CreatorId).ClubId);

                var members = _memberService.Get().Where(x => x.ClubId.EndsWith(club.Id));

                List<string> registrationTokens = new List<string>();

                foreach (var item in members)
                {
                    var deviceId = _userService.GetUsersById(item.UserId).DeviceId;
                    registrationTokens.Add(deviceId);

                }
                
                //registrationTokens.Add("csgoZF1BTLKWX8z1ldqGnn:APA91bG9aJAz88dH84X1bPGCMWWptdcPVZijpdjWyM-xUf8Kwtv7iA959xXE1k8UNZyYl6B5OPOtcRoscvagI8SZRblwWBtzxkEo3M-KUkslMez_vq36nggFYT1RWT9MWTSHyhVP9WIA");
                //registrationTokens.Add("dYe7INjeQm2bmIf6AUypKM:APA91bGRQPU7vWYqt_jTezFCjncLcMb0LfovTtMtXIuxEOPg3TLbxTWCVfJpZpUinhzUGGGbQFzKRxGlLhKrUwb6bdBC32Y7ZIkY-A1oNe7Kc7snIEXyuvNRf5vdt9bTV9lgv88pIwEZ");

                Dictionary<string, string> data = new Dictionary<string, string>();
                data.Add("Id", id+"");
                data.Add("Title", eventinfo.Title);
                data.Add("Content", eventinfo.Content);

                string clubname = club.Name;

                _noti.SendNoti(registrationTokens, data, "New Event!!!", "New Event Just Created From " + clubname);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }


        [HttpPut()]
        public IActionResult UpdateEvent(EventInfo eventinfo)
        {
            if(_eventService.UpdateEvent(eventinfo))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEvent(int id)
        {
            if (_eventService.DeleteEvent(id))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

    }
}
