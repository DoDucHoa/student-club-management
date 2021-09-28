using FClub.Data.Database;
using FClub.Data.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace FClub.Business.Service
{
    public class WalletService
    {
        private readonly IWalletRepository _walletRepository;

        public WalletService(IWalletRepository walletRepository)
        {
            _walletRepository = walletRepository;
        }


        public void Add(Wallet wallet)
        {
            _walletRepository.Add(wallet);
            _walletRepository.SaveDbChange();
           
        }

        public void Update(Wallet wallet)
        {
                _walletRepository.Update(wallet);
                _walletRepository.SaveDbChange();
        }

        public bool DeleteById(int id)
        {
            var objFromDb = _walletRepository.Get(id);
            if(objFromDb == null)
            {
                return false;
            }
            _walletRepository.Remove(id);
            _walletRepository.SaveDbChange();
            return true;
        }

        public Wallet GetWalletById(int id)
        {
            var wallet = _walletRepository.Get(id);
            return wallet;
        }

        public IEnumerable<Wallet> GetList()
        {
            var walletList = _walletRepository.GetAll();
            return walletList;
        }
    /*    public IEnumerable<Wallet> GetListDes()
        {
            var walletList = _walletRepository.GetAll(orderBy: x => x.);
            return walletList;
        }*/
    }
}
