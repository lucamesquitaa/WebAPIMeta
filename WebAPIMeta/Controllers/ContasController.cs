using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIMeta.Models;
using WebAPIMeta.Models.Context;
using WebAPIMeta.Models.DTOs;
using WebAPIMeta.Services.Interfaces;

namespace WebAPIMeta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContasController : ControllerBase
    {

        private readonly IContasService _service;

        public ContasController(IContasService service)
        {
            _service = service;
        }

        // GET: api/Contas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContasDTOVisualizacao>>> GetContas()
        {
            var response = await _service.GetAll();
            if (response == null)
                return BadRequest();

            return Ok(response);
        }

        // POST: api/Contas
        [HttpPost]
        public async Task<ActionResult<ContasDTOInclusao>> PostContas(ContasDTOInclusao contas)
        {

            var response = await _service.Create(contas);
            if (response == null)
                return BadRequest();

            return Ok(response);
        }

    }
}
