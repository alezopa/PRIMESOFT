﻿namespace Questao5.Domain.Entities
{
    public class Movimento
    {

        public Movimento() { }


        public int IdMovimento { get; set; }
        public int IdContaCorrente { get; set; }
        public string DataMovimento { get; set; }
        public string TipoMovimento { get; set; }

        public decimal Valor { get; set; }


        public ContaCorrente ContaCorrente { get; set; }
    }
}

