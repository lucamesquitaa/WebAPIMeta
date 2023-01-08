using System;
using System.ComponentModel.DataAnnotations;

namespace WebAPIMeta.Models
{
    public class Contas
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public double ValorOriginal { get; set; }
        public double ValorCorrigido { get; set; }
        public DateTime DataVencimento { get; set; }
        public DateTime DataPagamento { get; set; }
        public int Atraso { get; set; }
    }
}
