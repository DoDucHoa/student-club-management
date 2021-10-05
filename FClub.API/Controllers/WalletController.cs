﻿using FClub.Data.Database;
using FClub.Business.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FClub.Data.Helper;
using Microsoft.AspNetCore.Authorization;

namespace FClub.API.Controllers
{
    [Route("api/v1/wallets")]
    [ApiController]
    public class WalletController : ControllerBase
    {
        private readonly WalletService _walletService;

        public WalletController(WalletService walletService)
        {
            _walletService = walletService;
        }

        [HttpGet("{id}")]
        public ActionResult<Wallet> GetWalletById(int id)
        {
            var data = _walletService.GetWalletById(id);
            return data;
        }

        [HttpGet]
        public ActionResult<PagedList<Wallet>> GetWallets([FromQuery] WalletParameter wallet, [FromQuery] PagingParameter paging)
        {
            var data = _walletService.GetAllWallet(wallet, paging);
            return data;
        }

        [HttpPost]
        public IActionResult AddWallet(Wallet wallet)
        {
            if(_walletService.Add(wallet))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }


        [HttpPut]
        public IActionResult UpdateWallet(Wallet wallet)
        {
            if (_walletService.Update(wallet))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteWalletById(int id)
        {
            if (_walletService.DeleteById(id))
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
