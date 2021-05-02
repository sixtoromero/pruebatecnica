using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ALPHA.Domain.Entity
{
    public class Correspondence
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(10)]
        public string Consecutive { get; set; }
        /// <summary>
        /// Identifica si es una correspondencia interna o externa (CI = Interna, CE = Externa)
        /// </summary>
        [Required]
        [MaxLength(2)]        
        public string Type { get; set; }
        /// <summary>
        /// Hace referencia al usuario que remite
        /// </summary>
        [Required]
        public int SenderId { get; set; }
        /// <summary>
        /// Hace referencia al usuario destinatario
        /// </summary>
        [Required]
        public int AddresseeId { get; set; }
        [Required]
        [MaxLength(80)]
        public string Subject { get; set; }
        [Required]
        public string Body { get; set; }
        [Required]
        public bool Ready { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public int UserId { get; set; }

        [NotMapped]
        public string Sender { get; set; }
        [NotMapped]
        public string Addressee { get; set; }

    }
}
