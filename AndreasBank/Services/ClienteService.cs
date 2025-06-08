using AndreasBank.Models;
using AndreasBank.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AndreasBank.Services
{
    public class ClienteService
    {
        private readonly ClienteRepository _clienteRepository;

        public ClienteService(ClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public Task<List<Cliente>> GetAllAsync() => _clienteRepository.GetAllAsync();
        public Task<Cliente> GetByCpfAsync(string cpf) => _clienteRepository.GetByCpfAsync(cpf);
        public Task AddAsync(Cliente cliente) => _clienteRepository.AddAsync(cliente);
        public Task UpdateAsync(Cliente cliente) => _clienteRepository.UpdateAsync(cliente);
        public Task DeleteAsync(string cpf) => _clienteRepository.DeleteAsync(cpf);
    }
}
