using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public record ClienteDTO
    {
        public Guid? Id = null;
        public string? Nombre;
        public string? CorreoElectronico;
        public string? Telefono;
    }
}
