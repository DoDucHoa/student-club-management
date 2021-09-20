using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL_CRUD.Models
{
    [Table("UserInfo", Schema = "dbo")]
    public class UserInfo 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Column("university_id")]
        public string universityId { get; set; }

        [Required]
        public string email { get; set; }

        [Required]
        public string password { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public string phone { get; set; }

        public DateTime birthday { get; set; }

        [Required]
        public int gender { get; set; }

        public string photo { get; set; }
    }
}
