using Application.DTOs;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Adapters;
using Application.Interfaces;

namespace Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteReaderRepository _reader;
        private readonly IClienteWriterRepository _writer;

        public ClienteService(IClienteReaderRepository reader, IClienteWriterRepository writer)
        {
            _reader = reader;
            _writer = writer;
        }

        public async Task<IEnumerable<ClienteDTO>> GetAllAsync()
        {
            var clientes = await _reader.GetAllAsync();
            return clientes.Select(c => new ClienteDTO
            {
                Id = c.Id,
                Nombre = c.Nombre,
                CorreoElectronico = c.CorreoElectronico,
                Telefono = c.Telefono
            }).ToList();

        }


        public async Task<ClienteDTO?> GetByIdAsync(Guid id)
        {
            var cliente =  await _reader.GetByIdAsync(id);

            return new ClienteDTO
            {
                Id = cliente.Id,
                Nombre = cliente.Nombre,
                CorreoElectronico = cliente.CorreoElectronico,
                Telefono = cliente.Telefono
            };

        }

        public async Task<ClienteDTO> CreateAsync(ClienteDTO clienteDTO) 
        {
            ArgumentNullException.ThrowIfNull(clienteDTO);

            var cliente = new Cliente(
                clienteDTO.Nombre,
                clienteDTO.CorreoElectronico,
                clienteDTO.Telefono
                );

            await _writer.AddAsync(cliente);
            return clienteDTO with { Id = clienteDTO.Id };
        }

        public async Task<ClienteDTO> UpdateAsync(ClienteDTO clienteDto)
        {
            var cliente = new Cliente(
                    clienteDto.Nombre,
                    clienteDto.CorreoElectronico,
                    clienteDto.Telefono
                );
            cliente.Id = (Guid)clienteDto.Id!;

            await _writer.UpdateAsync(cliente);

            return new ClienteDTO
            {
                Id = cliente.Id,
                Nombre = cliente.Nombre,
                CorreoElectronico = cliente.CorreoElectronico,
                Telefono = cliente.Telefono
            };
        }

        public async Task DeleteAsync(Guid id)
        {
            await _writer.DeleteAsync(id);
        }

    }
}
