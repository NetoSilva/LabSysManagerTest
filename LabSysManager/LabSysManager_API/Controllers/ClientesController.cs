using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LabSysManager_Domain.Models;
using LabSysManager_Infra.Context;
using LabSysManager_Infra.Repositories;

namespace LabSysManager_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly LabSysManagerContext _context;
        private ClienteRepository clienteRepository;
        public ClientesController(LabSysManagerContext context)
        {
            _context = context;
            clienteRepository = new ClienteRepository(context);
        }

        // GET: api/Clientes
        [HttpGet]
        public async Task<IEnumerable<Cliente>> GetClientes()
        {
            var clientes = await clienteRepository.ReadAll();
            return clientes;
        }
    }
}
