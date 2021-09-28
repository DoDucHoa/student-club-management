using FClub.Data.Database;
using FClub.Data.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace FClub.Business.Service
{
    public class ClubService
    {
        private readonly IClubRepository _clubRepository;

        public ClubService(IClubRepository clubRepository)
        {
            _clubRepository = clubRepository;
        }

        public void Upsert(Club club)
        {
            bool checkExist = _clubRepository.CheckIdExistance(club.Id);
            if (!checkExist)
            {
                _clubRepository.Add(club);
            }
            else
            {
                _clubRepository.Update(club);
            }
            _clubRepository.SaveDbChange();
        }

        public void Add(Club club)
        {
            bool checkExist = _clubRepository.CheckIdExistance(club.Id);
            if (!checkExist)
            {
                _clubRepository.Add(club);
                _clubRepository.SaveDbChange();
            }

        }
       /* public bool CheckClubExist(string id)
        {
            return _clubRepository.CheckIdExistance(id);
        }*/
        public void Update(Club club)
        {
            bool checkExist = _clubRepository.CheckIdExistance(club.Id);
            if (checkExist)
            {
                _clubRepository.Update(club);
                _clubRepository.SaveDbChange();
            }
        }

        public bool DeleteById(string id)
        {
            var objFromDb = _clubRepository.Get(id);
            if(objFromDb == null)
            {
                return false;
            }
            _clubRepository.Remove(id);
            _clubRepository.SaveDbChange();
            return true;
        }

        public Club GetClubById(string id)
        {
            var club = _clubRepository.Get(id);
            return club;
        }

        public IEnumerable<Club> GetList()
        {
            var clubList = _clubRepository.GetAll();
            return clubList;
        }
    }
}
