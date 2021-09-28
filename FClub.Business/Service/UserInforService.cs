using FClub.Data.Database;
using FClub.Data.Helper;
using FClub.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FClub.Business.Service
{
    public class UserInforService
    {
        private readonly IUserInfoRepository _userInfo;

        public UserInforService(IUserInfoRepository userInfo)
        {
            _userInfo = userInfo;
        }

        //GET All User Details   
        public List<UserInfo> GetAllUsersInfor()
        {
            return _userInfo.GetAll().ToList();
        }

        //Get Users by User Name  
        public PagedList<UserInfo> GetUsersInfor(UserParameter user, PagingParameter paging)
        {
            Console.WriteLine("Run Service");

            var values = _userInfo.GetAll();

            if (user.id != null)
            {
                Console.WriteLine("GetID");
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
                _userInfo.Update(user);
                _userInfo.SaveDbChange();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        //Check Login
        public UserInfo CheckLogin(string email, string password)
        {
            return _userInfo.GetAll().Where(x => x.Email.Equals(email) && x.Password.Equals(password)).FirstOrDefault();
        }
    }
}