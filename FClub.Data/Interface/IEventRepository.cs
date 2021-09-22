using FClub.Data.Database;
using FClub.Data.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace FClub.Data.Interface
{
    interface IEventRepository : IRepository<EventInfo>
    {
        PagedList<EventInfo> getAllEvents(IEnumerable<EventInfo> events);
        EventInfo GetEventById(int id);
        EventInfo GetEventInDetailById(int id);
        void AddEvent(EventInfo eventinfo);
        void UpdateEvent(EventInfo eventinfo);
        void RemoveMajor(EventInfo eventinfo);
    }
}
