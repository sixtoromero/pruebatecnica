using System;
using System.Collections.Generic;
using System.Text;

namespace ALPHA.Application.DTO
{
    public class ContactDTO
    {
        public int IdContact { get; set; }
        public int IdUserContact { get; set; }
        public DateTime Date { get; set; }
        public int IdUser { get; set; }
    }
}
