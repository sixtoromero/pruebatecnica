using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ALPHA.Domain.Entity
{
    public class Rol
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string RolName { get; set; }        
    }
}
