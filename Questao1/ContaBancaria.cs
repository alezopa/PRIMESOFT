using System.Globalization;

namespace Questao1
{


    public class ContaBancaria
    {

        public string Retorno { get; set; }
        public int Numero { get; set; }
        public string Titular { get; set; }
        public double? Saldo { get; set; }
        public  ContaBancaria(int numero, string titular, double? depositoInicial = null)
        {
            this.Numero = numero;
            this.Titular = titular;
            this.Saldo = depositoInicial ?? 0;
            Retorno =   "Conta: " + numero + ", Titular: " + titular + ", Saldo: $ " + (depositoInicial.HasValue ? depositoInicial.Value.ToString() : "0");

        }


        public ContaBancaria Deposito(double quantia,ContaBancaria conta)
        {
           
            conta.Saldo += quantia;

            conta.Retorno = "Conta: " + conta.Numero + ", Titular: " + conta.Titular + ", Saldo: $ " + conta.Saldo.ToString();
            return conta;
        }



        public ContaBancaria Saque(double quantia, ContaBancaria conta)
        {
            conta.Saldo -= quantia;

            conta.Retorno = "Conta: " + conta.Numero + ", Titular: " + conta.Titular + ", Saldo: $ " + conta.Saldo.ToString();

            return conta;
        }

    }

}
