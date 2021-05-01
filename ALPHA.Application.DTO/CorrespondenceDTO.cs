using System;
using System.Collections.Generic;
using System.Text;

namespace ALPHA.Application.DTO
{
    public class CorrespondenceDTO
    {
        public string Consecutive { get; set; }
        public string Type { get; set; }
        public int Sender { get; set; }
        public int Addressee { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public bool Ready { get; set; }
        public DateTime Date { get; set; }
        public int IdUser { get; set; }
    }
}
