using FClub.Data.Database;
using FClub.Data.Helper;
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

        public EventTicketService(IEventTicketRepository eventTicketRepo)
        {
            _ticketRepo = eventTicketRepo;
        }
        //GET All Ticket 
        public IEnumerable<EventTicket> GetAll()
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
        //Get Ticket by type  
        public IEnumerable<EventTicket> GetTicketByType(string typeId)
        {
            return _ticketRepo.GetByType(typeId);
        }
        //Add Ticket
        public void Add(EventTicket ticket)
        {
            _ticketRepo.Add(ticket);
            _ticketRepo.SaveDbChange();
        }
        //Delete Ticket by id
        public void DeleteById(int id)
        {
            var ticket = _ticketRepo.GetById(id);
            _ticketRepo.Remove(ticket);
            _ticketRepo.SaveDbChange();
        }
        //Update Ticket Details  
        public void Update(EventTicket ticket)
        {
            _ticketRepo.Update(ticket);
            _ticketRepo.SaveDbChange();
        }

        public PagedList<EventTicket> GetBy(EventTicketParameter eventTicket, PagingParameter eventParameter)
        {
            var values = _ticketRepo.GetAll(includeProperties: eventTicket.includeProperties);

            if (eventTicket.Id != null)
            {
                values = values.Where(x => x.Id == eventTicket.Id);
            }
            if (eventTicket.ParticipantId != null)
            {
                values = values.Where(x => x.ParticipantId == eventTicket.ParticipantId);
            }
            if (!string.IsNullOrWhiteSpace(eventTicket.TicketTypeId))
            {
                values = values.Where(x => x.TicketTypeId.Equals(eventTicket.TicketTypeId));
            }

            if (!string.IsNullOrWhiteSpace(eventTicket.sort))
            {
                switch (eventTicket.sort)
                {
                    case "Id":
                        if (eventTicket.dir == "asc")
                            values = values.OrderBy(d => d.Id);
                        else if (eventTicket.dir == "desc")
                            values = values.OrderByDescending(d => d.Id);
                        break;
                }
            }

            return PagedList<EventTicket>.ToPagedList(_ticketRepo.GetAll().AsQueryable(),
            eventParameter.PageNumber,
            eventParameter.PageSize);
        }
    }
}
