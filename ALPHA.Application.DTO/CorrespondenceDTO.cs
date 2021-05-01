using System;
using System.Collections.Generic;
using System.Text;

namespace ALPHA.Application.DTO
{
    public class CorrespondenceDTO
    {
        public int Id { get; set; }
        public string Consecutive { get; set; }
        public string Type { get; set; }
        public int SenderId { get; set; }
        public int AddresseeId { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public bool Ready { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        
        public string Sender { get; set; }        
        public string Addressee { get; set; }
    }
}
