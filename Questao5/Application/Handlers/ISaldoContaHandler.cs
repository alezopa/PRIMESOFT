﻿using Questao5.Application.Commands.Requests;
using Questao5.Application.Commands.Responses;

namespace Questao5.Application.Handlers
{
    public interface ISaldoContaHandler
    {

        SaldoResponse HandleSaldo(string request);

        bool HandleMovimentacao(MovimentacaoRequest request);
    }
}
