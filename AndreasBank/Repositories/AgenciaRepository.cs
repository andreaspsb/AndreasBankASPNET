using AndreasBank.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AndreasBank.Repositories
{
    public class AgenciaRepository
    {
        private readonly BancoContext _context;

        public AgenciaRepository(BancoContext context)
        {
            _context = context;
        }

        public async Task<List<Agencia>> GetAllAsync()
        {
            return await _context.Agencias.ToListAsync();
        }

        public async Task<Agencia> GetByNumeroAsync(string numero)
        {
            return await _context.Agencias.FindAsync(numero);
        }

        public async Task AddAsync(Agencia agencia)
        {
            _context.Agencias.Add(agencia);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Agencia agencia)
        {
            _context.Agencias.Update(agencia);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string numero)
        {
            var agencia = await GetByNumeroAsync(numero);
            if (agencia != null)
            {
                _context.Agencias.Remove(agencia);
                await _context.SaveChangesAsync();
            }
        }
    }
}
