using System.ComponentModel.DataAnnotations;

namespace Questao5.Application.Commands.Requests
{
    public class SaldoRequest
    {
        [Required]
        public string IdContaCorrente { get; set; }

    }
}
