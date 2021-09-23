using FClub.Data.Database;
using FClub.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FClub.Business.Service
{
    public class EventTicketService
    {
        private readonly IEventTicketRepository _ticketRepo;

        public EventTicketService(IEventTicketRepository eventTicket)
        {
            _ticketRepo = eventTicket;
        }
        //GET All Ticket 
        public IEnumerable<EventTicket> getAll()
        {
            return _ticketRepo.GetAll().ToList();
        }

        //Get Ticket by id  
        public EventTicket GetTicketById(int id)
        {
            return _ticketRepo.GetById(id);
        }

        //Get Ticket by participant id  
        public IEnumerable<EventTicket> GetTicketByParticipant(int parId)
        {
            return _ticketRepo.GetByParticipant(parId);
        }
        //Add Ticket
        public void Add(EventTicket ticket)
        {
            _ticketRepo.Add(ticket);
        }
        //Delete Ticket
        public void Delete(EventTicket ticket)
        {
            _ticketRepo.Remove(ticket);
        }
        //Update Ticket Details  
        public void Update(EventTicket ticket)
        {
            _ticketRepo.Update(ticket);
        }
    }
}
