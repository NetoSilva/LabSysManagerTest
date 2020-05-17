using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LabSysManager_Services.ViewModels;
using LabSysManager_Services.Services;
using AutoMapper;
using LabSysManager_Infra.Context;

namespace LabSysManager_Services.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly ClienteAppService clienteAppService;
        public ClientesController(LabSysManagerContext dbContext, IMapper mapper)
        {
            clienteAppService = new ClienteAppService(dbContext, mapper);
        }

        // GET: api/Clientes/ObterTodosPorIdade/{idade}

        [HttpGet("{idade}")]
        public async Task<ActionResult<List<ClienteViewModel>>> ObterTodosPorIdade(long idade)
        {
            var clientes = await clienteAppService.ObterTodosPorIdade(idade);
            return clientes;
        }

        [HttpGet("{estado}")]
        public async Task<ActionResult<List<ClienteViewModel>>> ObterTodosPorEstado(string estado)
        {
            var clientes = await clienteAppService.ObterTodosPorEstado(estado);
            return clientes;
        }

        [HttpGet("{cidade}")]
        public async Task<ActionResult<List<ClienteViewModel>>> ObterTodosPorCidade(string cidade)
        {
            var clientes = await clienteAppService.ObterTodosPorCidade(cidade);
            return clientes;
        }

        [HttpGet("{estado}")]
        public async Task<ActionResult<long>> ObterPesoMedioPorEstado(string estado)
        {
            var pesoMedio = await clienteAppService.ObterPesoMedioPorEstado(estado);
            return pesoMedio;
        }

        [HttpGet("{idade}")]
        public async Task<ActionResult<long>> ObterPesoMedioPorIdade(long idade)
        {
            var pesoMedio = await clienteAppService.ObterPesoMedioPorIdade(idade);
            return pesoMedio;
        }
    }
}
