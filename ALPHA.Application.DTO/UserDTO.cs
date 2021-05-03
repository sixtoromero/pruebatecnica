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
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public int RolId { get; set; }
        public DateTime Date { get; set; }

        public string Token { get; set; }

        public List<ContactDTO> Contacts { get; set; }
        public List<CorrespondenceDTO> Correspondences { get; set; }
        public RolDTO Roles { get; set; }
    }
}
