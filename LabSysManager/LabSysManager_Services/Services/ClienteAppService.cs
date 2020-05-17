using LabSysManager_Infra.Repositories;
using LabSysManager_Infra.UoW;
using LabSysManager_Services.Services.Interfaces;
using LabSysManager_Services.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using LabSysManager_Infra.Repositories.Interfaces;
using LabSysManager_Domain.Models;
using LabSysManager_Infra.UoW.Interfaces;
using AutoMapper;

namespace LabSysManager_Services.Services
{
    public class ClienteAppService : IClienteAppService
    {
        private IRepository<Cliente> clienteRepository;
        private IUnitOfWork unitOfWork;
        private IMapper Mapper;
        public ClienteAppService(DbContext dbContext, IMapper mapper)
        {
            clienteRepository = new ClienteRepository(dbContext);
            unitOfWork = new UnitOfWork(dbContext);
            Mapper = mapper;
        }

        public async Task<long> ObterPesoMedioPorIdade(long idade)
        {
            var clientes = (await clienteRepository.ReadAll()).Where(c => c.Idade == idade);
            long pesoTotal = 0;
            clientes.ToList().ForEach(c => { pesoTotal += c.Peso; });
            var pesoMedio = pesoTotal / clientes.Count();
            return pesoMedio;
        }

        public async Task<long> ObterPesoMedioPorEstado(string estado)
        {
            var clientes = (await clienteRepository.ReadAll()).Where(c => c.Estado == estado);
            long pesoTotal = 0;
            clientes.ToList().ForEach(c => { pesoTotal += c.Peso; });
            var pesoMedio = pesoTotal / clientes.Count();
            return pesoMedio;
        }

        public async Task<List<ClienteViewModel>> ObterTodosPorCidade(string cidade)
        {
            return Mapper.Map<List<ClienteViewModel>>((await clienteRepository.ReadAll()).Where(c => c.Cidade == cidade));
        }

        public async Task<List<ClienteViewModel>> ObterTodosPorEstado(string estado)
        {
            return Mapper.Map<List<ClienteViewModel>>((await clienteRepository.ReadAll()).Where(c => c.Estado == estado));
        }

        public async Task<List<ClienteViewModel>> ObterTodosPorIdade(long idade)
        {
            return Mapper.Map<List<ClienteViewModel>>((await clienteRepository.ReadAll()).Where(c => c.Idade == idade));
        }
    }
}
