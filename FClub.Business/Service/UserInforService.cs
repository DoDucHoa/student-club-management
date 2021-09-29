using FClub.Data.Database;
<<<<<<< HEAD
=======
using FClub.Data.Helper;
>>>>>>> 06a398bc00f9aa0ce962b0e5e1661707d5b1dde6
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
<<<<<<< HEAD
        private readonly IRepository<UserInfo> _userInfo;

        public UserInforService(IRepository<UserInfo> userInfo)
=======
        private readonly IUserInfoRepository _userInfo;

        public UserInforService(IUserInfoRepository userInfo)
>>>>>>> 06a398bc00f9aa0ce962b0e5e1661707d5b1dde6
        {
            _userInfo = userInfo;
        }

<<<<<<< HEAD
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
=======
        //GET All User Details   
        public List<UserInfo> GetAllUsersInfor()
        {
            return _userInfo.GetAll().ToList();
        }

        //Get Users by User Name  
        public PagedList<UserInfo> GetUsersInfor(UserParameter user, PagingParameter paging)
        {

            var values = _userInfo.GetAll();

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
>>>>>>> 06a398bc00f9aa0ce962b0e5e1661707d5b1dde6
        {

            try
            {
<<<<<<< HEAD
                var DataList = _userInfo.GetAll().Where(x => x.Email == email).ToList();
                foreach (var item in DataList)
                {
                    _userInfo.Delete(item);
                }
=======
                _userInfo.Remove(_object);
                _userInfo.SaveDbChange();
>>>>>>> 06a398bc00f9aa0ce962b0e5e1661707d5b1dde6
                return true;
            }
            catch (Exception)
            {
<<<<<<< HEAD
                return true;
            }

        }
        //Update Person Details  
=======
                return false;
            }

        }
        //Update User Details  
>>>>>>> 06a398bc00f9aa0ce962b0e5e1661707d5b1dde6
        public bool UpdateUser(UserInfo user)
        {
            try
            {
                _userInfo.Update(user);
<<<<<<< HEAD
=======
                _userInfo.SaveDbChange();
>>>>>>> 06a398bc00f9aa0ce962b0e5e1661707d5b1dde6
                return true;
            }
            catch (Exception)
            {
<<<<<<< HEAD
                return true;
            }
        }
    }
}
=======
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
>>>>>>> 06a398bc00f9aa0ce962b0e5e1661707d5b1dde6
