using Microsoft.AspNetCore.Mvc;
using Questao5.Application.Commands.Requests;
using Questao5.Domain.Entities;


namespace Questao5.Infrastructure.Services.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContaCorrenteController : ControllerBase
    {
        
        private readonly ILogger<ContaCorrenteController> _logger;

        public ContaCorrenteController(ILogger<ContaCorrenteController> logger)
        {
            _logger = logger;
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
        public async Task<ActionResult<decimal>> Get(int idConta)
        {

            return Ok(100);
        }


        [HttpPost("Movimentacao")]
        public async Task<IActionResult> PostMovimentacao([FromBody] MovimentacaoRequest movimentacao)
        {
            if (movimentacao == null)
            {
                return BadRequest("Moviemntacao é null");
            }



            return Ok();
        }
    }
}