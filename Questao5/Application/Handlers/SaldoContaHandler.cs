using Dapper;
using Microsoft.Data.Sqlite;
using Questao5.Application.Commands.Requests;
using Questao5.Application.Commands.Responses;
using Questao5.Domain.Entities;
using System.Data;

namespace Questao5.Application.Handlers
{
    public class SaldoContaHandler : ISaldoContaHandler
    {
        public bool HandleMovimentacao(MovimentacaoRequest request)
        {


   
            var parametros = new DynamicParameters();
            parametros.Add("idcontacorrente", request.IdContaCorrente, DbType.String);
            parametros.Add("tipomovimento", request.TipoMovimento, DbType.AnsiString);
            parametros.Add("datamovimento", DateTime.Now.ToShortDateString(), DbType.String); 
            parametros.Add("valor  ", request.Valor, DbType.Double);




            using var con = new SqliteConnection("Data Source = database.sqlite");
            con.Open();


            var query = "Insert into movimento (idcontacorrente,datamovimento,tipomovimento ,valor ) " +
              " Values (" +  "'" + request.IdContaCorrente + "'" + "," + "'" +  DateTime.Now.ToShortDateString() + "'" + "," + "'" + request.TipoMovimento  + "'" + "," + request.Valor.ToString() + ")";




            var res = con.Execute(query);


            con.Close();

                return true;    


        }

        public SaldoResponse HandleSaldo(string request)
        {
            SaldoResponse _saldo = new SaldoResponse();
   
            using var con = new SqliteConnection("Data Source = database.sqlite");
            con.Open();


            var res = con.QueryAsync<Movimento>("select * from movimento").Result.ToList();


            if (res.Count() == 0)
              return  _saldo;


            var _credito = res.Where(c => c.TipoMovimento == "C" && c.IdContaCorrente == request).Sum(s => s.Valor);

            var _debito = res.Where(c => c.TipoMovimento == "D" && c.IdContaCorrente == request).Sum(s => s.Valor);
           
            _saldo.Saldo = _credito - _debito; 


            con.Close();


            return _saldo;

        }


    }
}
