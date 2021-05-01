using System;
using System.Collections.Generic;
using System.Text;

namespace ALPHA.Application.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Names { get; set; }
        public string Surnames { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public string Rol { get; set; }
        public DateTime Date { get; set; }
    }
}
