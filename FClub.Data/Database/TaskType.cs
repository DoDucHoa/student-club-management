using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
<<<<<<< HEAD
=======
using FClub.Data.Database;
>>>>>>> 06a398bc00f9aa0ce962b0e5e1661707d5b1dde6
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace FClub.Data.Database
{
    [Table("TaskType")]
    [Index(nameof(Id), Name = "i")]
    public partial class TaskType
    {
        public TaskType()
        {
            Tasks = new HashSet<Task>();
        }

        [Key]
        [Column("id")]
        [StringLength(32)]
        public string Id { get; set; }
        [Required]
        [Column("name")]
        [StringLength(256)]
        public string Name { get; set; }

        [InverseProperty(nameof(Task.Type))]
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
