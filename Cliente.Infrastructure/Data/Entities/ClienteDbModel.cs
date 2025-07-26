using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Entities
{
    [Table("clientes")]
    public class ClienteDbModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; }
    
        [Required]
        [EmailAddress]
        public string CorreoElectronico { get; set; }

        [Required]
        [MaxLength(20)]
        public string Telefono { get; set; }
    }
}
