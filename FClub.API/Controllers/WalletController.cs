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
    [Route("api/wallets")]
    [ApiController]
    public class WalletController : ControllerBase
    {
        private readonly WalletService _walletService;

        public WalletController(WalletService walletService)
        {
            _walletService = walletService;
        }

        [HttpGet("{id}")]
        public Object GetWalletById(int id)
        {
            var data = _walletService.GetWalletById(id);
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
            var data = _walletService.GetList();
            var json = JsonConvert.SerializeObject(data, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                }
            );
            return json;
        }

        [HttpPost]
        public void AddWallet(Wallet wallet)
        {
            try
            {
                _walletService.Add(wallet);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message.ToString());
            }
        }


        [HttpPut]
        public void UpdateWallet(Wallet wallet)
        {
            try
            {
                _walletService.Update(wallet);
            }
            catch (Exception e)
            {
                e.Message.ToString();
            }
        }

        [HttpDelete("{id}")]
        public bool DeleteWalletById(int id)
        {
            try
            {
                _walletService.DeleteById(id);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
