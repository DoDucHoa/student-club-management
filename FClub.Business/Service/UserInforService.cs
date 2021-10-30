using FClub.Data.Database;
using FClub.Data.Helper;
using FClub.Data.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FClub.Business.Service
{
    public class UserInforService
    {
        private readonly IUserInfoRepository _userInfo;
        private readonly MemberService _memberService;

        public UserInforService(IUserInfoRepository userInfo, IConfiguration configuration, MemberService member)
        {
            _userInfo = userInfo;
            _memberService = member;
        }

        //GET All User Details   
        public List<UserInfo> GetAllUsersInfor()
        {
            return _userInfo.GetAll().ToList();
        }

        //Get Users by User Name  
        public PagedList<UserInfo> GetUsersInfor(UserParameter user, PagingParameter paging)
        {

            var values = _userInfo.GetAll(includeProperties: user.includeProperties);

            if (user.id != null)
            {
                values = values.Where(x => x.Id == user.id);
            }
            if (!string.IsNullOrWhiteSpace(user.name))
            {
                values = values.Where(x => x.Name.Contains(user.name, StringComparison.InvariantCultureIgnoreCase));
            }
            if (!string.IsNullOrWhiteSpace(user.email))
            {
                values = values.Where(x => x.Email.Contains(user.email, StringComparison.InvariantCultureIgnoreCase));
            }
            if (!string.IsNullOrWhiteSpace(user.phone))
            {
                values = values.Where(x => x.Phone.Equals(user.phone));
            }
            if (user.IsAdmin)
            {
                values = values.Where(x => x.IsAdmin == true);
            }
            if (!user.Status)
            {
                values = values.Where(x => x.Status == false);
            }

            if (!string.IsNullOrWhiteSpace(user.sort))
            {
                switch (user.sort)
                {
                    case "Id":
                        if (user.dir == "asc")
                            values = values.OrderBy(d => d.Id);
                        else if (user.dir == "desc")
                            values = values.OrderByDescending(d => d.Id);
                        break;
                }
            }

            return PagedList<UserInfo>.ToPagedList(values.AsQueryable(),
            paging.PageNumber,
            paging.PageSize);
        }
        //Get Users by User Id
        public UserInfo GetUsersById(int id)
        {
            return _userInfo.GetAll().Where(x => x.Id == id).FirstOrDefault();
        }
        //Add User
        public void AddUserInfo(UserInfo _object)
        {
            _userInfo.Add(_object);
            _userInfo.SaveDbChange();
        }
        //Delete User   
        public bool DeleteUser(UserInfo _object)
        {

            try
            {
                _userInfo.Remove(_object);
                _userInfo.SaveDbChange();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        //Update User Details  
        public bool UpdateUser(UserInfo user)
        {
            try
            {
                var userDB = _userInfo.GetFirstOrDefault(x => x.Id == user.Id);
                userDB.UniversityId = user.UniversityId;
                userDB.Email = user.Email;
                userDB.Password = user.Password;
                userDB.Name = user.Name;
                userDB.Phone = user.Phone;
                userDB.Birthday = user.Birthday;
                userDB.Gender = user.Gender;
                userDB.Photo = user.Photo;
                userDB.Bio = user.Bio;
                userDB.IsAdmin = user.IsAdmin;
                userDB.Status = user.Status;
                _userInfo.Update(userDB);
                _userInfo.SaveDbChange();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public IEnumerable GetUserJoinClubRank()
        {
            Hashtable hashtable = new Hashtable();

            var users = _userInfo.GetAll();

            foreach (UserInfo user in users) {
                user.Members = null;
                hashtable.Add(user, _memberService.CountByUserId(user.Id));
            };

            var listRank = hashtable.Cast<DictionaryEntry>().OrderByDescending(entry => entry.Value);

            var fiveUser = listRank.Take(5);

            return fiveUser;
        }
    }
}