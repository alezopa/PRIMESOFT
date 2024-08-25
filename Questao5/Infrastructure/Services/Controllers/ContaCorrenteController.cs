using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Questao5.Application.Commands.Requests;
using Questao5.Application.Commands.Responses;
using Questao5.Application.Handlers;
using Questao5.Domain.Entities;


namespace Questao5.Infrastructure.Services.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContaCorrenteController : ControllerBase
    {
        
        private readonly ILogger<ContaCorrenteController> _logger;
        private readonly ISaldoContaHandler _saldoContaHandler;

        public ContaCorrenteController(ILogger<ContaCorrenteController> logger, ISaldoContaHandler saldoContaHandler)
        {
            _logger = logger;
            _saldoContaHandler = saldoContaHandler;

        }

        [HttpGet(Name = "ContaCorrente")]
        public IEnumerable<ContaCorrente> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new ContaCorrente
            {
                
            })
            .ToArray();
        }


        [HttpGet("SaldoConta/{idConta}")]
        public async Task<ActionResult<SaldoResponse>> Get(string idConta)
        {


            var _resultado =  _saldoContaHandler.HandleSaldo(idConta);
  

            return Ok(_resultado);
        }


        [HttpPost("Movimentacao")]
        public async Task<IActionResult> PostMovimentacao([FromBody] MovimentacaoRequest movimentacao)
        {
            if (movimentacao == null)
            {
                return BadRequest("Moviemntacao é null");
            }

            var _resultado = _saldoContaHandler.HandleMovimentacao(movimentacao);

            return Ok(_resultado);
        }
    }
}