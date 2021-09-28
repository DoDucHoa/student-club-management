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
    [Route("api/transactionDetails")]
    [ApiController]
    public class TransactionDetailController : ControllerBase
    {
        private readonly TransactionDetailService _transactionDetailService;

        public TransactionDetailController(TransactionDetailService transactionDetailService)
        {
            _transactionDetailService = transactionDetailService;
        }

        [HttpGet("{id}")]
        public Object GetTransactionDetailById(int id)
        {
            var data = _transactionDetailService.GetTransactionDetailById(id);
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
            var data = _transactionDetailService.GetList();
            var json = JsonConvert.SerializeObject(data, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                }
            );
            return json;
        }

        [HttpPost]
        public void AddTransactionDetail(TransactionDetail transactionDetail)
        {
            try
            {
                _transactionDetailService.Add(transactionDetail);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message.ToString());
            }
        }


        [HttpPut]
        public void UpdateTransactionDetail(TransactionDetail transactionDetail)
        {
            try
            {
                _transactionDetailService.Update(transactionDetail);
            }
            catch (Exception e)
            {
                e.Message.ToString();
            }
        }

        [HttpDelete("{id}")]
        public bool DeleteTransactionDetailById(int id)
        {
            try
            {
                _transactionDetailService.DeleteById(id);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
