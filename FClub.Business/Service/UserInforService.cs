using FClub.Data.Database;
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
        public IEnumerable<UserInfo> GetAllUsersInfor()
        {
            return _userInfo.GetAll().ToList();
        }

        //Get Users by User Name  
        public IEnumerable<UserInfo> GetUsersByName(string name)
        {
            return _userInfo.GetAll().Where(x => x.Name.Contains(name, StringComparison.CurrentCultureIgnoreCase)).ToList();
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