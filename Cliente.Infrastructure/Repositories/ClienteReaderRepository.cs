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
    public class ClienteReaderRepository : IClienteReaderRepository
    {
        private readonly AppDbContext _context;

        public ClienteReaderRepository(AppDbContext context) {
            _context = context;
        }

        public async Task<Cliente?> GetByIdAsync(Guid id)
        {
            var dbModel = await _context.Clientes.FindAsync(id);
            return dbModel != null ? ClienteAdapter.ToDomain(dbModel) : null;
        }
        public async Task<IEnumerable<Cliente>> GetAllAsync()
        {
            var dbModels = await _context.Clientes.ToListAsync();
            return dbModels.Select(ClienteAdapter.ToDomain);
        }

       
    }
}
