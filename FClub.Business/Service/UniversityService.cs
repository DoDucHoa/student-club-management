using FClub.Data.Database;
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
        private readonly IUniversityRepository _university;

        public UniversityService(IUniversityRepository university)
        {
            _university = university;
        }
        //GET All University Details By Name
        public IEnumerable<University> GetUniversityByName(string name)
        {
            return _university.GetAll().Where(x => x.Name.Contains(name, StringComparison.CurrentCultureIgnoreCase)).ToList();
        }
        //GET All University Details   
        public IEnumerable<University> GetAllUniversity()
        {
            return _university.GetAll().ToList();
        }
        //Get University by University Id  
        public University GetUniversityById(string id)
        {
            return _university.GetAll().Where(x => x.Id.Equals(id)).FirstOrDefault();
        }
        //Add University
        public bool AddUniversity(University university)
        {
            try
            {
                _university.Add(university);
                _university.SaveDbChange();
                return true;
            } catch (Exception)
            {
                return false;
            }
        }
        //Delete University   
        public bool DeleteUniversityByName(string name)
        {

            try
            {
                var University = _university.GetAll().Where(x => x.Name.Equals(name)).FirstOrDefault();
                _university.Remove(University);
                _university.SaveDbChange();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        //Update University Details  
        public bool UpdateUniversity(University university)
        {
            try
            {
                _university.Update(university);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}