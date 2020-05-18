using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LabSysManager_Services.ViewModels;
using LabSysManager_Services.Services;
using AutoMapper;
using LabSysManager_Infra.Context;
using LabSysManager_Infra.Repositories.Interfaces;
using LabSysManager_Domain.Models;
using LabSysManager_Infra.Repositories;
using LabSysManager_Infra.UoW.Interfaces;
using LabSysManager_Infra.UoW;

namespace LabSysManager_Services.Controllers
{
    /// <summary>
    /// API para exibição dos dados dos Clientes LabSysmanager
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class ClientesController : ControllerBase
    {
        private readonly ClienteAppService ClienteAppService;
        private readonly IRepository<Cliente> ClienteRepository;

        /// <summary>
        /// Construtor
        /// </summary>
        public ClientesController(LabSysManagerContext dbContext, IMapper mapper)
        {
            ClienteRepository = new ClienteRepository(dbContext);
            ClienteAppService = new ClienteAppService(ClienteRepository, mapper);
        }

        /// <summary>
        /// Obtem todos os clientes por idade.
        /// </summary>
        /// <param name="idade">Idade dos clientes</param>
        [HttpGet("{idade}")]
        public async Task<ActionResult<List<ClienteViewModel>>> ObterTodosPorIdade(long idade)
        {
            var clientes = await ClienteAppService.ObterTodosPorIdade(idade);
            return clientes;
        }

        /// <summary>
        /// Obtem todos os clientes por estado.
        /// </summary>
        /// <param name="estado">UF dos clientes</param>

        [HttpGet("{estado}")]
        public async Task<ActionResult<List<ClienteViewModel>>> ObterTodosPorEstado(string estado)
        {
            var clientes = await ClienteAppService.ObterTodosPorEstado(estado);
            return clientes;
        }

        /// <summary>
        /// Obtem todos os clientes por cidade..
        /// </summary>
        /// <param name="cidade">Cidade dos clientes</param>

        [HttpGet("{cidade}")]
        public async Task<ActionResult<List<ClienteViewModel>>> ObterTodosPorCidade(string cidade)
        {
            var clientes = await ClienteAppService.ObterTodosPorCidade(cidade);
            return clientes;
        }

        /// <summary>
        /// Obtem peso médio de todos os clientes por estado.
        /// </summary>
        /// <param name="estado" >UF dos clientes</param>

        [HttpGet("{estado}")]
        public async Task<ActionResult<long>> ObterPesoMedioPorEstado(string estado)
        {
            var pesoMedio = await ClienteAppService.ObterPesoMedioPorEstado(estado);
            return pesoMedio;
        }

        /// <summary>
        /// Obtem peso médio de todos os clientes por idade.
        /// </summary>
        /// <param name="idade">Idade dos clientes</param>

        [HttpGet("{idade}")]
        public async Task<ActionResult<long>> ObterPesoMedioPorIdade(long idade)
        {
            var pesoMedio = await ClienteAppService.ObterPesoMedioPorIdade(idade);
            return pesoMedio;
        }
    }
}
