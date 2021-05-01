using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ALPHA.Domain.Entity
{
    public class Contact
    {
        public int Id { get; set; }
        [Required]
        public int IdUserContact { get; set; }
        [Required]
        public DateTime Date { get; set; }        
        [Required]
        public int UserId { get; set; }
    }
}
