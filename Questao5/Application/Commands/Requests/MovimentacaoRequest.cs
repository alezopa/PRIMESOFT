namespace Questao5.Application.Commands.Requests
{
    public class MovimentacaoRequest
    {
        public int IdIdentificacao { get; set; }
        public int IdContaCorrente { get; set; }
        public decimal Valor { get; set; }
        public string TipoMovimento { get; set; }
    }
}
// (C = Credito, D = Débito).