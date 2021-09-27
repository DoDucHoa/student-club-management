﻿using FClub.Data.Database;
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

        public EventInfoService(IEventRepository eventInfo)
        {
            _eventRepo = eventInfo;
        }
        //GET All Event Details  
        public IEnumerable<EventInfo> getAll()
        {
            return _eventRepo.GetAllEvent();
        }

        //Get Event by event id  
        public EventInfo GetEventById(int id)
        {
            return _eventRepo.GetEventById(id);
        }
        //Add Event
        public void Add(EventInfo eventInfo)
        {
            _eventRepo.AddEvent(eventInfo);
        }
        //Disable Event 
        public void DisableEventById(int id)
        {
            _eventRepo.DisableEvent(id);           
        }
        //Update Event Details  
        public void UpdateEvent(EventInfo eventInfo)
        {
            _eventRepo.UpdateEvent(eventInfo);
        }
    }
}
