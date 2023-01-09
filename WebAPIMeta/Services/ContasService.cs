using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using WebAPIMeta.Models.Context;
using WebAPIMeta.Models.DTOs;
using WebAPIMeta.Models;
using WebAPIMeta.Repositories.Interfaces;
using WebAPIMeta.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace WebAPIMeta.Services
{
    public class ContasService : IContasService
    {
        private readonly ContasContext _context;
        private readonly ICalculator _calculator;
        public ContasService(ContasContext context, ICalculator calculator)
        {
            _context = context;
            _calculator = calculator;
        }
        public async Task<IEnumerable<ContasDTOVisualizacao>> GetAll()
        {
            try
            {
                var response = await _context.Contas.ToListAsync();
                List<ContasDTOVisualizacao> responseTratada = new List<ContasDTOVisualizacao>();

                foreach(var conta in response)
                {
                    var contaDTO = new ContasDTOVisualizacao
                    {
                        Nome = conta.Nome,
                        ValorOriginal = conta.ValorOriginal,
                        ValorCorrigido = conta.ValorCorrigido,
                        Atraso = conta.Atraso,
                        DataPagamento = conta.DataPagamento
                    };
                    responseTratada.Add(contaDTO);
                }

                return responseTratada;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<ContasDTOInclusao> Create(ContasDTOInclusao conta)
        {
            try
            {
                double valorOriginal = conta.ValorOriginal;
                DateTime dataVencimento = conta.DataVencimento;
                DateTime dataPagamento = conta.DataPagamento;

                double valorCorrigido = _calculator.CalculaValor(dataVencimento, dataPagamento, valorOriginal);

                int atraso = _calculator.CalculaDias(dataVencimento, dataPagamento);

                var response = new ContasDTOVisulizacao
                {
                    Nome = conta.Nome,
                    ValorOriginal = valorOriginal,
                    ValorCorrigido = valorCorrigido,
                    DataVencimento = dataVencimento,
                    DataPagamento = dataPagamento,
                    Atraso = atraso
                };

                _context.Contas.Add(response);
                await _context.SaveChangesAsync();
                return conta;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
    }
}
