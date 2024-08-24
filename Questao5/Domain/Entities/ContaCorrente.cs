namespace Questao5.Domain.Entities
{
    public class ContaCorrente
    {

        public ContaCorrente() { }


        public int IdConta { get; set; }
        public int NumeroConta { get; set; }
        public string NomeTitular { get; set; }
        public bool Ativo { get; set; }



    }
}
