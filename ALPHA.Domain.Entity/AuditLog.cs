using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ALPHA.Domain.Entity
{
    public class AuditLog
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string TableName { get; set; }
        [MaxLength(10)]
        [Required]
        public string RegisterId { get; set; }
        /// <summary>
        /// Se describe que tipo de acción se ejecutó en la tabla, (I = Insertar, U = Actualizar, E = Eliminar)
        /// </summary>
        [Required]
        [MaxLength(1)]
        public string Action { get; set; }
        [Required]
        public string Data { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}
