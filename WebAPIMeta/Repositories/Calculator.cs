using System;
using WebAPIMeta.Repositories.Interfaces;

namespace WebAPIMeta.Repositories
{
    public class Calculator: ICalculator
    {
        public bool CalculaIsLate(DateTime dataVencimento, DateTime dataPagamento)
        {
            return dataPagamento > dataVencimento;
        }

        public int CalculaDias(DateTime dataVencimento, DateTime dataPagamento)
        {
            return (int)((dataPagamento - dataVencimento).TotalDays);
        }

        public double CalculaValor(DateTime dataVencimento, DateTime dataPagamento, double valorOriginal)
        {
            bool isLate = CalculaIsLate(dataVencimento, dataPagamento);

            if (isLate)
            {

                int days = CalculaDias(dataVencimento, dataPagamento);

                if (days <= 3)
                {
                    return ((valorOriginal * 1.02) + (days * 1.001));
                }
                else if (days > 3 && days <= 10)
                {
                    return ((valorOriginal * 1.03) + (days * 1.002));
                }
                else
                {
                    return ((valorOriginal * 1.05) + (days * 1.003));
                }

            }
            else
            {
                return 0;
            }
        }
    }
}
