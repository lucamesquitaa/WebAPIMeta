using System;

namespace WebAPIMeta.Repositories.Interfaces
{
    public interface ICalculator
    {
        public bool CalculaIsLate(DateTime dataVencimento, DateTime dataPagamento);
        public int CalculaDias(DateTime dataVencimento, DateTime dataPagamento);
        public double CalculaValor(DateTime dataVencimento, DateTime dataPagamento, double valorOriginal);
    }
}
