using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IClienteService
    {
        Task<IEnumerable<ClienteDTO>> GetAllAsync();
        Task<ClienteDTO?> GetByIdAsync(Guid id);
        Task<ClienteDTO> CreateAsync(ClienteDTO clienteDto);
        Task<ClienteDTO> UpdateAsync(ClienteDTO clienteDto);
        Task DeleteAsync(Guid id);
    }
}
