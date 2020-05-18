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
        private readonly IRepository<Cliente> ClienteRepository;
        private readonly IMapper Mapper;
        public ClienteAppService(IRepository<Cliente> clienteRepository, IMapper mapper)
        {
            ClienteRepository = clienteRepository;
            Mapper = mapper;
        }

        public async Task<long> ObterPesoMedioPorIdade(long idade)
        {
            if (idade <= 0)
            {
                throw new System.Exception("Idade deve ser maior que 0.");
            }

            var clientes = (await ClienteRepository.ReadAll()).Where(c => c.Idade == idade);
            long pesoTotal = 0;
            clientes.ToList().ForEach(c => { pesoTotal += c.Peso; });
            var pesoMedio = pesoTotal / clientes.Count();
            return pesoMedio;
        }

        public async Task<long> ObterPesoMedioPorEstado(string estado)
        {
            if (string.IsNullOrEmpty(estado))
            {
                throw new System.Exception("Estado não pode estar vazio ou nulo.");
            }

            var clientes = (await ClienteRepository.ReadAll()).Where(c => c.Estado.ToLower() == estado.ToLower());
            long pesoTotal = 0;
            long pesoMedio = 0;
            clientes.ToList().ForEach(c => { pesoTotal += c.Peso; });
            if (pesoTotal > 0)
            {
                pesoMedio = pesoTotal / clientes.Count();
            }
            return pesoMedio;
        }

        public async Task<List<ClienteViewModel>> ObterTodosPorCidade(string cidade)
        {
            if (string.IsNullOrEmpty(cidade))
            {
                throw new System.Exception("Cidade não pode estar vazio ou nulo.");
            }

            return Mapper.Map<List<ClienteViewModel>>((await ClienteRepository.ReadAll()).Where(c => c.Cidade.ToLower() == cidade.ToLower()));
        }

        public async Task<List<ClienteViewModel>> ObterTodosPorEstado(string estado)
        {
            if (string.IsNullOrEmpty(estado))
            {
                throw new System.Exception("Estado não pode estar vazio ou nulo.");
            }

            return Mapper.Map<List<ClienteViewModel>>((await ClienteRepository.ReadAll()).Where(c => c.Estado.ToLower() == estado.ToLower()));
        }

        public async Task<List<ClienteViewModel>> ObterTodosPorIdade(long idade)
        {
            if (idade <= 0)
            {
                throw new System.Exception("Idade deve ser maior que 0.");
            }

            return Mapper.Map<List<ClienteViewModel>>((await ClienteRepository.ReadAll()).Where(c => c.Idade == idade));
        }
    }
}
