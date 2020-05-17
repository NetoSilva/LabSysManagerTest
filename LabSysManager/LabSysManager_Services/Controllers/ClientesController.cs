using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LabSysManager_Services.ViewModels;
using LabSysManager_Services.Services;
using AutoMapper;
using LabSysManager_Infra.Context;

namespace LabSysManager_Services.Controllers
{
    /// <summary>
    /// API para exibição dos dados dos Clientes LabSysmanager
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class ClientesController : ControllerBase
    {
        private readonly ClienteAppService clienteAppService;
        /// <summary>
        /// Construtor
        /// </summary>
        public ClientesController(LabSysManagerContext dbContext, IMapper mapper)
        {
            clienteAppService = new ClienteAppService(dbContext, mapper);
        }

        /// <summary>
        /// Action para obter todos os clientes por idade.
        /// </summary>
        /// <param name="idade">Idade dos clientes</param>
        [HttpGet("{idade}")]
        public async Task<ActionResult<List<ClienteViewModel>>> ObterTodosPorIdade(long idade)
        {
            var clientes = await clienteAppService.ObterTodosPorIdade(idade);
            return clientes;
        }

        /// <summary>
        /// Action para obter todos os clientes por estado.
        /// </summary>
        /// <param name="estado">UF dos clientes</param>
     
        [HttpGet("{estado}")]
        public async Task<ActionResult<List<ClienteViewModel>>> ObterTodosPorEstado(string estado)
        {
            var clientes = await clienteAppService.ObterTodosPorEstado(estado);
            return clientes;
        }

        /// <summary>
        /// Action para obter todos os clientes por cidade..
        /// </summary>
        /// <param name="cidade">Cidade dos clientes</param>

        [HttpGet("{cidade}")]
        public async Task<ActionResult<List<ClienteViewModel>>> ObterTodosPorCidade(string cidade)
        {
            var clientes = await clienteAppService.ObterTodosPorCidade(cidade);
            return clientes;
        }

        /// <summary>
        /// Action para obter peso médio de todos os clientes por estado.
        /// </summary>
        /// <param name="estado" >UF dos clientes</param>

        [HttpGet("{estado}")]
        public async Task<ActionResult<long>> ObterPesoMedioPorEstado(string estado)
        {
            var pesoMedio = await clienteAppService.ObterPesoMedioPorEstado(estado);
            return pesoMedio;
        }

        /// <summary>
        /// Action para obter peso médio de todos os clientes por idade.
        /// </summary>
        /// <param name="idade">Idade dos clientes</param>

        [HttpGet("{idade}")]
        public async Task<ActionResult<long>> ObterPesoMedioPorIdade(long idade)
        {
            var pesoMedio = await clienteAppService.ObterPesoMedioPorIdade(idade);
            return pesoMedio;
        }
    }
}
