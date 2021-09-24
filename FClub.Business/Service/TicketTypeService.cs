using FClub.Data.Database;
using FClub.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FClub.Business.Service
{
    public class TicketTypeService
    {
        private readonly ITicketTypeRepository _ticketTypeRepo;
        
        public TicketTypeService(ITicketTypeRepository ticketTypeRepo)
        {
            _ticketTypeRepo = ticketTypeRepo;
        }

        //GET All Ticket Type  
        public IEnumerable<TicketType> getAll()
        {
            return _ticketTypeRepo.GetAll().ToList();
        }

        //Get Ticket Type by id  
        public TicketType GetTicketTypeById(string id)
        {
            return _ticketTypeRepo.GetAll().FirstOrDefault(e => e.Id.Equals(id));
        }
        //Add Ticket Type
        public void Add(TicketType ticketType)
        {
            _ticketTypeRepo.Add(ticketType);
            _ticketTypeRepo.SaveDbChange();
        }
        //Delete Ticket Type 
        public void Delete(TicketType ticketType)
        {
            _ticketTypeRepo.Remove(ticketType);
            _ticketTypeRepo.SaveDbChange();
        }
        //Update Ticket Type  
        public void Update(TicketType ticketType)
        {
            _ticketTypeRepo.Update(ticketType);
            _ticketTypeRepo.SaveDbChange();
        }
    }
}
