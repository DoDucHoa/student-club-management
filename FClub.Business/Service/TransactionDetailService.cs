using FClub.Data.Database;
using FClub.Data.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace FClub.Business.Service
{
    public class TransactionDetailService
    {
        private readonly ITransactionDetailRepository _transactionDetailRepository;

        public TransactionDetailService(ITransactionDetailRepository transactionDetailRepository)
        {
            _transactionDetailRepository = transactionDetailRepository;
        }


        public void Add(TransactionDetail transactionDetail)
        {
            _transactionDetailRepository.Add(transactionDetail);
            _transactionDetailRepository.SaveDbChange();
           
        }

        public void Update(TransactionDetail transactionDetail)
        {
                _transactionDetailRepository.Update(transactionDetail);
                _transactionDetailRepository.SaveDbChange();
        }

        public bool DeleteById(int id)
        {
            var objFromDb = _transactionDetailRepository.Get(id);
            if(objFromDb == null)
            {
                return false;
            }
            _transactionDetailRepository.Remove(id);
            _transactionDetailRepository.SaveDbChange();
            return true;
        }

        public TransactionDetail GetTransactionDetailById(int id)
        {
            var transactionDetail = _transactionDetailRepository.Get(id);
            return transactionDetail;
        }

        public IEnumerable<TransactionDetail> GetList()
        {
            var transactionDetailList = _transactionDetailRepository.GetAll();
            return transactionDetailList;
        }
    }
}
