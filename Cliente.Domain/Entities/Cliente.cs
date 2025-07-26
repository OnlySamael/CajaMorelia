using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Cliente(string nombre, string correo, string telefono)
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Nombre { get; private set; } = nombre;
        public string CorreoElectronico { get; private set; } = correo;
        public string Telefono { get; private set; } = telefono;
    }
}
