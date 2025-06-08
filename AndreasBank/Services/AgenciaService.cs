using AndreasBank.Models;
using AndreasBank.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AndreasBank.Services
{
    public class AgenciaService
    {
        private readonly AgenciaRepository _agenciaRepository;

        public AgenciaService(AgenciaRepository agenciaRepository)
        {
            _agenciaRepository = agenciaRepository;
        }

        public Task<List<Agencia>> GetAllAsync() => _agenciaRepository.GetAllAsync();
        public Task<Agencia> GetByNumeroAsync(string numero) => _agenciaRepository.GetByNumeroAsync(numero);
        public Task AddAsync(Agencia agencia) => _agenciaRepository.AddAsync(agencia);
        public Task UpdateAsync(Agencia agencia) => _agenciaRepository.UpdateAsync(agencia);
        public Task DeleteAsync(string numero) => _agenciaRepository.DeleteAsync(numero);
    }
}
