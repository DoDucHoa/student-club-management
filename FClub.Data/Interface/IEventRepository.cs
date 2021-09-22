using FClub.Data.Database;
using FClub.Data.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace FClub.Data.Interface
{
    public interface IEventRepository : IRepository<EventInfo>
    {
        EventInfo GetEventById(int id);
        void AddEvent(EventInfo eventinfo);
        void UpdateEvent(EventInfo eventinfo);
        void DisableEvent(int id);
        public IEnumerable<EventInfo> GetAllEvent();
    }
}
