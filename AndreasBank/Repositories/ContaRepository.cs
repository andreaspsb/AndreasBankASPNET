using AndreasBank.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AndreasBank.Repositories
{
    public class ContaRepository
    {
        private readonly BancoContext _context;

        public ContaRepository(BancoContext context)
        {
            _context = context;
        }

        public async Task<List<Conta>> GetAllAsync()
        {
            return await _context.Contas.Include(c => c.Agencia).ToListAsync();
        }

        public async Task<Conta> GetByNumeroAsync(string numero)
        {
            return await _context.Contas.Include(c => c.Agencia).FirstOrDefaultAsync(c => c.Numero == numero);
        }

        public async Task AddAsync(Conta conta)
        {
            _context.Contas.Add(conta);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Conta conta)
        {
            _context.Contas.Update(conta);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string numero)
        {
            var conta = await GetByNumeroAsync(numero);
            if (conta != null)
            {
                _context.Contas.Remove(conta);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<List<Conta>> GetByClienteAsync(string cpf)
        {
            return await _context.Contas
                .Include(c => c.Agencia)
                .Where(c => c.Titular.Cpf == cpf)
                .ToListAsync();
        }
        //GetByAgenciaAsync
        public async Task<List<Conta>> GetByAgenciaAsync(string agenciaNumero)
        {
            return await _context.Contas
                .Include(c => c.Agencia)
                .Where(c => c.Agencia.Numero == agenciaNumero)
                .ToListAsync();
        }
        public async Task TransferirAsync(string numeroContaOrigem, string numeroContaDestino, decimal valor)
        {
            var contaOrigem = await GetByNumeroAsync(numeroContaOrigem);
            var contaDestino = await GetByNumeroAsync(numeroContaDestino);

            if (contaOrigem != null && contaDestino != null && contaOrigem.Saldo >= valor)
            {
                contaOrigem.Saldo -= valor;
                contaDestino.Saldo += valor;

                _context.Contas.Update(contaOrigem);
                _context.Contas.Update(contaDestino);
                await _context.SaveChangesAsync();
            }
        }
        public async Task SacarAsync(string numeroConta, decimal valor)
        {
            var conta = await GetByNumeroAsync(numeroConta);
            if (conta != null && conta.Saldo >= valor)
            {
                conta.Saldo -= valor;
                _context.Contas.Update(conta);
                await _context.SaveChangesAsync();
            }
        }
        public async Task DepositarAsync(string numeroConta, decimal valor)
        {
            var conta = await GetByNumeroAsync(numeroConta);
            if (conta != null)
            {
                conta.Saldo += valor;
                _context.Contas.Update(conta);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<bool> VerificarSaldoSuficienteAsync(string numeroConta, decimal valor)
        {
            var conta = await GetByNumeroAsync(numeroConta);
            return conta != null && conta.Saldo >= valor;
        }

    }
}
