using AtualizadorClientes.DTOs;
using AtualizadorClientes.ExtensionMethods;
using AtualizadorClientes.Services.Interfaces;
using LabSysManager_Domain.Models;
using LabSysManager_Infra.Repositories;
using LabSysManager_Infra.Repositories.Interfaces;
using LabSysManager_Infra.UoW;
using LabSysManager_Infra.UoW.Interfaces;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AtualizadorClientes.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IRepository<Cliente> ClienteRepository;
        private readonly IUnitOfWork UnitOfWork;

        public ClienteService(IRepository<Cliente> clienteRepository, IUnitOfWork unitOfWork)
        {
            ClienteRepository = clienteRepository;
            UnitOfWork = unitOfWork;
        }

        public void AtualizarArquivoJsonClientes(List<ClienteDTO> clientes, string path)
        {
            using (StreamWriter w = new StreamWriter(path))
            {
                if (clientes.Any())
                {
                    var clientesSerialized = JsonConvert.SerializeObject(clientes);
                    w.Write(JValue.Parse(clientesSerialized).ToString(Formatting.Indented));
                }
            }
        }

        public List<ClienteDTO> ObterClientesArquivoJson(string path)
        {
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                return JsonConvert.DeserializeObject<List<ClienteDTO>>(json);
            }
        }

        public void AtualizarClientes(List<ClienteDTO> clientes)
        {
            Task t = Task.Run(async () =>
            {
                foreach (var cliente in clientes)
                {
                    Console.WriteLine($"Atualizando cliente: {cliente.Nome}");
                    cliente.Cidade = await new EnderecoService().ObterCidadePorCep(cliente.Cep);
                    cliente.Estado = await new EnderecoService().ObterEstadoPorCep(cliente.Cep);
                }
            });

            t.Wait();
        }

        public async Task<int> SalvarClientes(List<ClienteDTO> clientes)
        {
            var listaClientes = await ClienteRepository.ReadAll();
            foreach (var cliente in clientes)
            {
                if (!listaClientes.Any(c => c.Cpf == cliente.Cpf))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Salvando cliente: {cliente.Nome}");
                    await ClienteRepository.Create(new Cliente
                            (cliente.Nome,
                            cliente.Idade,
                            cliente.Cpf,
                            cliente.Rg,
                            Convert.ToDateTime(cliente.DataNasc),
                            cliente.Cidade,
                            cliente.Estado,
                            cliente.Signo,
                            cliente.Mae,
                            cliente.Pai,
                            cliente.Email,
                            cliente.Senha,
                            cliente.Cep,
                            cliente.Numero,
                            cliente.TelefoneFixo,
                            cliente.Celular,
                            cliente.Altura,
                            cliente.Peso,
                            cliente.TipoSanguineo.GetDescription(),
                            cliente.Cor.ToString()));
                }
            }
            return await UnitOfWork.Commit();
        }

        public void Dispose()
        {
            UnitOfWork.Dispose();
        }
    }
}
