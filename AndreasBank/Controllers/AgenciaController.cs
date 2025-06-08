using AndreasBank.Models;
using AndreasBank.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AndreasBank.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AgenciaController : ControllerBase
    {
        private readonly AgenciaService _agenciaService;

        public AgenciaController(AgenciaService agenciaService)
        {
            _agenciaService = agenciaService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Agencia>>> GetAll()
        {
            return await _agenciaService.GetAllAsync();
        }

        [HttpGet("{numero}")]
        public async Task<ActionResult<Agencia>> GetByNumero(string numero)
        {
            var agencia = await _agenciaService.GetByNumeroAsync(numero);
            if (agencia == null) return NotFound();
            return agencia;
        }

        [HttpPost]
        public async Task<ActionResult> Add(Agencia agencia)
        {
            await _agenciaService.AddAsync(agencia);
            return CreatedAtAction(nameof(GetByNumero), new { numero = agencia.Numero }, agencia);
        }

        [HttpPut]
        public async Task<ActionResult> Update(Agencia agencia)
        {
            await _agenciaService.UpdateAsync(agencia);
            return NoContent();
        }

        [HttpDelete("{numero}")]
        public async Task<ActionResult> Delete(string numero)
        {
            await _agenciaService.DeleteAsync(numero);
            return NoContent();
        }
    }
}
