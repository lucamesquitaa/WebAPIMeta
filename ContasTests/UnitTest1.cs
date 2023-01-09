using AutoFixture;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPIMeta.Controllers;
using WebAPIMeta.Models;
using WebAPIMeta.Models.DTOs;
using WebAPIMeta.Services;
using WebAPIMeta.Services.Interfaces;
using Xunit;
using AutoFixture;
using FakeItEasy;

namespace ContasTests
{
    public class UnitTest1
    {
        private readonly IFixture _fixture;
        private readonly Mock<IContasService> _contasServiceMock;
        private readonly ContasController _contasController;

        public UnitTest1()
        {
            _fixture = new Fixture();
            _contasServiceMock = _fixture.Freeze<Mock<IContasService>>();
            _contasController = new ContasController(_contasServiceMock.Object);
        }

        [Fact]
        public void Get_All_Null()
        {
            //arange
            var _contasMock = contasMockVisualizacao();
            _contasServiceMock.Setup(x => x.GetAll());
            //act
            var result = _contasController.GetContas().ConfigureAwait(false);
            //assert
            Assert.NotNull(result);
        }
        
        [Fact]
        public async Task Add_Conta_OK()
        {
            //arange
            var _contasMock = new ContasDTOInclusao { Nome = "luz", ValorOriginal = 100, DataPagamento = DateTime.Now, DataVencimento = DateTime.Now };
            _contasServiceMock.Setup(x => x.Create(_contasMock)).ReturnsAsync(_contasMock);
            //act
            var result = await _contasController.PostContas(_contasMock).ConfigureAwait(false);
            //assert
            Assert.NotNull(result);

        }

        [Fact]
        public async Task Add_Conta_Nome_Is_Empyt()
        {
            //arange
            var _contasMock = new ContasDTOInclusao { Nome = null, ValorOriginal = 100, DataPagamento = DateTime.Now, DataVencimento = DateTime.Now };
            _contasServiceMock.Setup(x => x.Create(_contasMock)).Verifiable();
            //act
            var result = await _contasController.PostContas(_contasMock).ConfigureAwait(false);
            //assert
            Assert.NotNull(result);
        }
        private IEnumerable<ContasDTOVisulizacao> contasMockVisualizacao()
        {
            var teste = new List<ContasDTOVisulizacao>();

            teste.Add(new ContasDTOVisulizacao { Nome = "luz", ValorOriginal = 100, ValorCorrigido = 170, DataPagamento = DateTime.Now, Atraso = 6 });
            teste.Add(new ContasDTOVisulizacao { Nome = "luz 2", ValorOriginal = 200, ValorCorrigido = 270, DataPagamento = DateTime.Now, Atraso = 6 });
            teste.Add(new ContasDTOVisulizacao { Nome = "luz 3", ValorOriginal = 300, ValorCorrigido = 370, DataPagamento = DateTime.Now, Atraso = 6 });
           
            return teste;
        }
       
    }
}
