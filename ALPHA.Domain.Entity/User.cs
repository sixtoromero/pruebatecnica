using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ALPHA.Domain.Entity
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Names { get; set; }
        [Required]
        [MaxLength(120)]
        public string Surnames { get; set; }
        [Required]
        [MaxLength(120)]
        public string Username { get; set; }
        [Required]
        [MaxLength(250)]
        public string Password { get; set; }
        [Required]
        [MaxLength(150)]
        public string Email { get; set; }
        /// <summary>
        /// El campo manejará los diferentes tipos de estado que puede tener un usuario los cuales son A = Activo I = Inactivo, R = Removido)
        /// </summary>
        [Required]
        [MaxLength(1)]
        public string Status { get; set; }
        [Required]
        public int RolId { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public List<Contact> Contacts { get; set; }
        public List<Correspondence> Correspondences { get; set; }
        public Rol Roles { get; set; }        

    }
}
