/*using FClub.Data.Database;
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
        private readonly IRepository<UserInfo> _userInfo;

        public UserInforService(IRepository<UserInfo> userInfo)
        {
            _userInfo = userInfo;
        }

        public IEnumerable<UserInfo> GetPersonByUserId(string email)
        {
            return _userInfo.GetAll().Where(x => x.Email == email).ToList();
        }
        //GET All Perso Details   
        public IEnumerable<UserInfo> GetAllUsersInfor()
        {
            return _userInfo.GetAll().ToList();
        }
        //Get Person by Person Name  
        public UserInfo GetUserByName(string name)
        {
            return _userInfo.GetAll().Where(x => x.Name.Contains(name, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
        }
        //Add Person
        public async Task<UserInfo> AddPerson(UserInfo user)
        {
            return await _userInfo.Create(user);
        }
        //Delete Person   
        public bool DeleteUser(string email)
        {

            try
            {
                var DataList = _userInfo.GetAll().Where(x => x.Email == email).ToList();
                foreach (var item in DataList)
                {
                    _userInfo.Delete(item);
                }
                return true;
            }
            catch (Exception)
            {
                return true;
            }

        }
        //Update Person Details  
        public bool UpdateUser(UserInfo user)
        {
            try
            {
                _userInfo.Update(user);
                return true;
            }
            catch (Exception)
            {
                return true;
            }
        }
    }
}
*/