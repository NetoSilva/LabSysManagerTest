using AtualizadorClientes.DTOs;
using AtualizadorClientes.ExtensionMethods;
using AtualizadorClientes.Services.Interfaces;
using LabSysManager_Domain.Models;
using LabSysManager_Infra.Repositories;
using LabSysManager_Infra.UoW;
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
        private ClienteRepository clienteRepository;
        private UnitOfWork unitOfWork;

        public ClienteService(DbContext dbContext)
        {
            clienteRepository = new ClienteRepository(dbContext);
            unitOfWork = new UnitOfWork(dbContext);
        }
        public void AtualizarArquivoJsonClientes(List<ClienteDTO> clientes, string path)
        {
            using (StreamWriter w = new StreamWriter(path))
            {
                var clientesSerialized = JsonConvert.SerializeObject(clientes);
                w.Write(JValue.Parse(clientesSerialized).ToString(Formatting.Indented));
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
                    cliente.Cidade = await new EnderecoService().ObterCidadePorCep(cliente.CEP);
                    cliente.Estado = await new EnderecoService().ObterEstadoPorCep(cliente.CEP);
                }
            });

            t.Wait();
        }

        public async Task<int> SalvarClientes(List<ClienteDTO> clientes)
        {
            var listaClientes = await clienteRepository.ReadAll();
            foreach (var cliente in clientes)
            {
                if (!listaClientes.Any(c => c.Cpf == cliente.CPF))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Salvando cliente: {cliente.Nome}");
                    await clienteRepository.Create(new Cliente
                            (cliente.Nome,
                            cliente.Idade,
                            cliente.CPF,
                            cliente.RG,
                            Convert.ToDateTime(cliente.DataNasc),
                            cliente.Cidade,
                            cliente.Estado,
                            cliente.Signo,
                            cliente.Mae,
                            cliente.Pai,
                            cliente.Email,
                            cliente.Senha,
                            cliente.CEP,
                            cliente.Numero,
                            cliente.TelefoneFixo,
                            cliente.Celular,
                            cliente.Altura,
                            cliente.Peso,
                            cliente.TipoSanguineo.GetDescription(),
                            cliente.Cor.ToString()));
                }
            }
            return await unitOfWork.Commit();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
