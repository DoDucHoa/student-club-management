using FClub.Data.Database;
using FClub.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FClub.Business.Service
{
    public class EventInfoService
    {
        private readonly IEventRepository _eventRepo;

        public EventInfoService(IEventRepository eventRepo)
        {
            _eventRepo = eventRepo;
        }
        //GET All Event Details  
        public IEnumerable<EventInfo> getAll()
        {
            return _eventRepo.GetAll().ToList();
        }

        //Get Event by event id  
        public EventInfo GetEventById(int id)
        {
            return _eventRepo.GetAll().FirstOrDefault(e => e.Id == id);
        }
        //Add Event
        public void Add(EventInfo eventInfo)
        {
            _eventRepo.Add(eventInfo);
            _eventRepo.SaveDbChange();
        }
        //Disable Event 
        public void DisableEventById(int id)
        {
            _eventRepo.DisableEvent(id);
            _eventRepo.SaveDbChange();
        }
        //Update Event Details  
        public void UpdateEvent(EventInfo eventInfo)
        {
            _eventRepo.Update(eventInfo);
            _eventRepo.SaveDbChange();
        }
    }
}
