/*using FClub.Data.Database;
using FClub.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FClub.Business.Service
{
    class EventInfoService
    {
        private readonly IRepository<EventInfo> _eventInfo;

        public EventInfoService(IRepository<EventInfo> eventInfo)
        {
            _eventInfo = eventInfo;
        }
        //Get Event by event title  
        public IEnumerable<EventInfo> GetEventByTitle(string title)
        {
            return _eventInfo.GetAll().Where(x => x.Title.Contains(title, StringComparison.CurrentCultureIgnoreCase)).ToList();
        }
        //GET All Event Details   
        public IEnumerable<EventInfo> GetAllEvent()
        {
            return _eventInfo.GetAll().ToList();
        }
        //Get Event by event id  
        public EventInfo GetEventById(string id)
        {
            return _eventInfo.GetAll().Where(x => x.Id.Equals(id)).FirstOrDefault();
        }
        //Add Event
        public async Task<EventInfo> AddUniversity(EventInfo eventInfo)
        {
            return await _eventInfo.Create(eventInfo);
        }
        //Disable Event 
        public bool DisableUniversityById(int id)
        {

            try
            {
                var eventInfo = _eventInfo.GetAll().Where(x => x.Id == id).FirstOrDefault();
                eventInfo.Status = false;
                _eventInfo.Update(eventInfo);
                return true;
            }
            catch (Exception)
            {
                return true;
            }

        }
        //Update Event Details  
        public bool UpdateEvent(EventInfo eventInfo)
        {
            try
            {
                _eventInfo.Update(eventInfo);
                return true;
            }
            catch (Exception)
            {
                return true;
            }
        }
    }
}*/
