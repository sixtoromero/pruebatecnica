using System;
using System.Collections.Generic;
using System.Text;

namespace ALPHA.Application.DTO
{
    public class AuditLogDTO
    {
        public int IdAudit { get; set; }
        public string TableName { get; set; }
        public int RegisterId { get; set; }
        public string Action { get; set; }
        public string Data { get; set; }
        public DateTime Date { get; set; }
        public int IdUser { get; set; }
    }
}
