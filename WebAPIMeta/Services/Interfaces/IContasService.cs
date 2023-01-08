using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPIMeta.Models.DTOs;
using WebAPIMeta.Models;

namespace WebAPIMeta.Services.Interfaces
{
    public interface IContasService
    {
        public Task<IEnumerable<ContasDTOVisualizacao>> GetAll();
        public Task<ContasDTOInclusao> Create(ContasDTOInclusao conta);
    }
}
