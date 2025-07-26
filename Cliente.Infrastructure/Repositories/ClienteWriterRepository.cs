using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Adapters;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ClienteWriterRepository : IClienteWriterRepository
    {
        private readonly AppDbContext _context;

        public ClienteWriterRepository(AppDbContext context) {
            _context = context;
        }

        public async Task AddAsync(Cliente cliente)
        {
            var dbModel = ClienteAdapter.ToEntitiy(cliente);

            await _context.Clientes.AddAsync(dbModel);
            await _context.SaveChangesAsync();
            cliente.Id = dbModel.Id;
        }

        public async Task UpdateAsync(Cliente cliente)
        {
            var dbModel = ClienteAdapter.ToEntitiy(cliente);
            _context.Entry(dbModel).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var dbModel = await _context.Clientes.FindAsync(id);
            if (dbModel != null)
            {
                _context.Clientes.Remove(dbModel);
                await _context.SaveChangesAsync();
            }
        }

       
    }
}
