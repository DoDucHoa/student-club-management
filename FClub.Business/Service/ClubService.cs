using FClub.Data.Database;
using FClub.Data.Helper;
using FClub.Data.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FClub.Business.Service
{
    public class ClubService
    {
        private readonly IClubRepository _clubRepository;
        private readonly MemberService _memberService;

        public ClubService(IClubRepository clubRepository, MemberService memberService)
        {
            _clubRepository = clubRepository;
            _memberService = memberService;
        }

        public IEnumerable<Club> GetClubByName(String clubName)
        {
            return _clubRepository.GetAll(filter: x => x.Name == clubName);
        }

        public PagedList<Club> GetAllClub(ClubParameter club, PagingParameter paging)
        {
            var values = _clubRepository.GetAll(includeProperties: club.includeProperties);

            if (!string.IsNullOrWhiteSpace(club.id))
            {
                values = values.Where(x => x.Id == club.id);
            }
            if (!string.IsNullOrWhiteSpace(club.name))
            {
                values = values.Where(x => x.Name.Contains(club.name, StringComparison.InvariantCultureIgnoreCase));
            }
            if (!string.IsNullOrWhiteSpace(club.universityID))
            {
                values = values.Where(x => x.UniversityId == club.universityID);
            }
            if (!club.Status)
            {
                values = values.Where(x => x.Status == false);
            }

            if (!string.IsNullOrWhiteSpace(club.sort))
            {
                switch (club.sort)
                {
                    case "Id":
                        if (club.dir == "asc")
                            values = values.OrderBy(d => d.Id);
                        else if (club.dir == "desc")
                            values = values.OrderByDescending(d => d.Id);
                        break;
                    case "Name":
                        if (club.dir == "asc")
                            values = values.OrderBy(d => d.Name);
                        else if (club.dir == "desc")
                            values = values.OrderByDescending(d => d.Name);
                        break;
                }
            }

            return PagedList<Club>.ToPagedList(values.AsQueryable(),
            paging.PageNumber,
            paging.PageSize);
        }

        public bool Add(Club club)
        {
            try
            {
                _clubRepository.Add(club);
                _clubRepository.SaveDbChange();
                return true;
            }
            catch { return false; }

        }

        public bool Update(Club club)
        {
            try
            {   
                _clubRepository.Update(club);
                _clubRepository.SaveDbChange();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteById(string id)
        {
            try
            {
                var objFromDb = _clubRepository.Get(id);
                if (objFromDb != null)
                {
                    _clubRepository.Remove(id);
                    _clubRepository.SaveDbChange();
                    return true;
                }
            }
            catch
            {
                return false;
            }
            return false;
        }

        public Club GetClubById(string id)
        {
            var club = _clubRepository.Get(id);
            return club;
        }

        public IEnumerable GetClubAmountMemberRank()
        {
            Hashtable hashtable = new Hashtable();

            var clubs = _clubRepository.GetAll();
            
            foreach (Club club in clubs)
            {
                hashtable.Add(club, _memberService.CountByClub(club.Id));
            };

            foreach (DictionaryEntry item in hashtable)
            {
                var club = (Club) item.Key;
                club.Members = null;
            }

            var listRank = hashtable.Cast<DictionaryEntry>().OrderByDescending(entry => entry.Value);

            return listRank;
        }
    }
}
