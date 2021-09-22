/*using FClub.Data.Database;
using FClub.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FClub.Business.Service
{
    public class UniversityService
    {
        private readonly IRepository<University> _university;

        public UniversityService(IRepository<University> university)
        {
            _university = university;
        }
        public IEnumerable<University> GetUniversityByName(string name)
        {
            return _university.GetAll().Where(x => x.Name.Contains(name, StringComparison.CurrentCultureIgnoreCase)).ToList();
        }
        //GET All Perso Details   
        public IEnumerable<University> GetAllUniversity()
        {
            return _university.GetAll().ToList();
        }
        //Get Person by Person Name  
        public University GetUniversityById(string id)
        {
            return _university.GetAll().Where(x => x.Id.Equals(id)).FirstOrDefault();
        }
        //Add Person
        public async Task<University> AddUniversity(University university)
        {
            return await _university.Create(university);
        }
        //Delete Person   
        public bool DeleteUniversityByName(string name)
        {

            try
            {
                var University = _university.GetAll().Where(x => x.Name.Equals(name)).FirstOrDefault();
                _university.Delete(University);
                return true;
            }
            catch (Exception)
            {
                return true;
            }

        }
        //Update Person Details  
        public bool UpdateUniversity(University university)
        {
            try
            {
                _university.Update(university);
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