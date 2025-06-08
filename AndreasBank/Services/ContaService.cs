using AndreasBank.Models;
using AndreasBank.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AndreasBank.Services
{
    public class ContaService
    {
        private readonly ContaRepository _contaRepository;

        public ContaService(ContaRepository contaRepository)
        {
            _contaRepository = contaRepository;
        }

        public Task<List<Conta>> GetAllAsync() => _contaRepository.GetAllAsync();
        public Task<Conta> GetByNumeroAsync(string numero) => _contaRepository.GetByNumeroAsync(numero);
        public Task AddAsync(Conta conta) => _contaRepository.AddAsync(conta);
        public Task UpdateAsync(Conta conta) => _contaRepository.UpdateAsync(conta);
        public Task DeleteAsync(string numero) => _contaRepository.DeleteAsync(numero);

        public Task<List<Conta>> GetByAgenciaAsync(string agenciaNumero)
        {
            return _contaRepository.GetByAgenciaAsync(agenciaNumero);
        }
        public Task<List<Conta>> GetByClienteAsync(string clienteCpf)
        {
            return _contaRepository.GetByClienteAsync(clienteCpf);
        }

        public Task TransferirAsync(string numeroContaOrigem, string numeroContaDestino, decimal valor)
        {
            return _contaRepository.TransferirAsync(numeroContaOrigem, numeroContaDestino, valor);
        }
        public Task SacarAsync(string numeroConta, decimal valor)
        {
            return _contaRepository.SacarAsync(numeroConta, valor);
        }
        public Task DepositarAsync(string numeroConta, decimal valor)
        {
            return _contaRepository.DepositarAsync(numeroConta, valor);
        }
        public Task<bool> VerificarSaldoSuficienteAsync(string numeroConta, decimal valor)
        {
            return _contaRepository.VerificarSaldoSuficienteAsync(numeroConta, valor);
        }
        

    }
}
