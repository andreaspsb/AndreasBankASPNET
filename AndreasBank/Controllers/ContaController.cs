using AndreasBank.Models;
using AndreasBank.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AndreasBank.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContaController : ControllerBase
    {
        private readonly ContaService _contaService;

        public ContaController(ContaService contaService)
        {
            _contaService = contaService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Conta>>> GetAll()
        {
            return await _contaService.GetAllAsync();
        }

        [HttpGet("{numero}")]
        public async Task<ActionResult<Conta>> GetByNumero(string numero)
        {
            var conta = await _contaService.GetByNumeroAsync(numero);
            if (conta == null) return NotFound();
            return conta;
        }

        [HttpPost]
        public async Task<ActionResult> Add(Conta conta)
        {
            await _contaService.AddAsync(conta);
            return CreatedAtAction(nameof(GetByNumero), new { numero = conta.Numero }, conta);
        }

        [HttpPut]
        public async Task<ActionResult> Update(Conta conta)
        {
            await _contaService.UpdateAsync(conta);
            return NoContent();
        }

        [HttpDelete("{numero}")]
        public async Task<ActionResult> Delete(string numero)
        {
            await _contaService.DeleteAsync(numero);
            return NoContent();
        }
        [HttpGet("cliente/{cpf}")]
        public async Task<ActionResult<List<Conta>>> GetByCliente(string cpf)
        {
            var contas = await _contaService.GetByClienteAsync(cpf);
            if (contas == null || contas.Count == 0) return NotFound();
            return contas;
        }
        [HttpGet("agencia/{agenciaNumero}")]
        public async Task<ActionResult<List<Conta>>> GetByAgencia(string agenciaNumero)
        {
            var contas = await _contaService.GetByAgenciaAsync(agenciaNumero);
            if (contas == null || contas.Count == 0) return NotFound();
            return contas;
        }
        [HttpPost("transferir")]
        public async Task<ActionResult> Transferir(string numeroContaOrigem, string numeroContaDestino, decimal valor)
        {
            try
            {
                await _contaService.TransferirAsync(numeroContaOrigem, numeroContaDestino, valor);
                return NoContent();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("sacar")]
        public async Task<ActionResult> Sacar(string numeroConta, decimal valor)
        {
            try
            {
                await _contaService.SacarAsync(numeroConta, valor);
                return NoContent();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("depositar")]
        public async Task<ActionResult> Depositar(string numeroConta, decimal valor)
        {
            try
            {
                await _contaService.DepositarAsync(numeroConta, valor);
                return NoContent();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("verificar-saldo-suficiente")]
        public async Task<ActionResult<bool>> VerificarSaldoSuficiente(string numeroConta, decimal valor)
        {
            try
            {
                var resultado = await _contaService.VerificarSaldoSuficienteAsync(numeroConta, valor);
                return Ok(resultado);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
