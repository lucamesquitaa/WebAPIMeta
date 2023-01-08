using System;

namespace WebAPIMeta.Models.DTOs
{
    public class ContasDTOInclusao
    {
        public string Nome { get; set; }
        public double ValorOriginal { get; set; }
        public DateTime DataVencimento { get; set; }
        public DateTime DataPagamento { get; set; }
    }
}
