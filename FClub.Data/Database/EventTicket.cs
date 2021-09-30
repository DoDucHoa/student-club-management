using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
<<<<<<< HEAD
using Microsoft.EntityFrameworkCore;

#nullable disable

=======
using FClub.Data.Database;
using Microsoft.EntityFrameworkCore;

>>>>>>> 06a398bc00f9aa0ce962b0e5e1661707d5b1dde6
namespace FClub.Data.Database
{
    [Table("EventTicket")]
    public partial class EventTicket
    {
        [Key]
        [Column("id")]
<<<<<<< HEAD
        [StringLength(32)]
        public string Id { get; set; }
=======
        public int Id { get; set; }
>>>>>>> 06a398bc00f9aa0ce962b0e5e1661707d5b1dde6
        [Column("participant_id")]
        public int ParticipantId { get; set; }
        [Required]
        [Column("ticket_type_id")]
        [StringLength(32)]
        public string TicketTypeId { get; set; }

        [ForeignKey(nameof(ParticipantId))]
        [InverseProperty("EventTickets")]
        public virtual Participant Participant { get; set; }
        [ForeignKey(nameof(TicketTypeId))]
        [InverseProperty("EventTickets")]
        public virtual TicketType TicketType { get; set; }
    }
}
