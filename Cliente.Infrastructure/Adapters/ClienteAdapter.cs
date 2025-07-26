using Domain.Entities;
using Infrastructure.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Adapters
{
    public static class ClienteAdapter
    {
        public static ClienteDbModel ToEntitiy(this Cliente cliente) 
        {
            return new ClienteDbModel
            {
                Id = cliente.Id,
                Nombre = cliente.Nombre,
                CorreoElectronico = cliente.CorreoElectronico,
                Telefono = cliente.Telefono,
            };
        }

        public static Cliente ToDomain(this ClienteDbModel dbModel) 
        {
            return new Cliente(
                dbModel.Nombre,
                dbModel.CorreoElectronico,
                dbModel.Telefono
                )
                {
                    Id = dbModel.Id,
                };
        }
        //public static IEnumerable<Cliente> ToDomain(this ClienteDbModel dbModel)
        //{

        //    return new Cliente(
        //        dbModel.Nombre,
        //        dbModel.CorreoElectronico,
        //        dbModel.Telefono
        //        )
        //    {
        //        Id = dbModel.Id,
        //    };
        //}
    }
}
