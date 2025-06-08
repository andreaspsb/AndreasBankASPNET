using AndreasBank.Models;
using AndreasBank.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AndreasBank.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteService _clienteService;

        public ClienteController(ClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Cliente>>> GetAll()
        {
            return await _clienteService.GetAllAsync();
        }

        [HttpGet("{cpf}")]
        public async Task<ActionResult<Cliente>> GetByCpf(string cpf)
        {
            var cliente = await _clienteService.GetByCpfAsync(cpf);
            if (cliente == null) return NotFound();
            return cliente;
        }

        [HttpPost]
        public async Task<ActionResult> Add(Cliente cliente)
        {
            await _clienteService.AddAsync(cliente);
            return CreatedAtAction(nameof(GetByCpf), new { cpf = cliente.CPF }, cliente);
        }

        [HttpPut]
        public async Task<ActionResult> Update(Cliente cliente)
        {
            await _clienteService.UpdateAsync(cliente);
            return NoContent();
        }

        [HttpDelete("{cpf}")]
        public async Task<ActionResult> Delete(string cpf)
        {
            await _clienteService.DeleteAsync(cpf);
            return NoContent();
        }
    }
}
