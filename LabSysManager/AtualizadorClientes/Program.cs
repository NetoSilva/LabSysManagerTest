using AtualizadorClientes.DTOs;
using AtualizadorClientes.Services;
using LabSysManager_Domain.Models;
using LabSysManager_Infra.Context;
using LabSysManager_Infra.Repositories;
using LabSysManager_Infra.UoW;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AtualizadorClientes
{
    class Program
    {
        private static DbContext dbContext;

        static void Main(string[] args)
        {
            Configure();
            var clientes = ObterClientesArquivoJson();
            AtualizarClientes(clientes);
            AtualizarArquivoJsonClientes(clientes);

            Console.WriteLine("Atualizado");
            Console.ReadKey();
        }

        private static void Configure()
        {
            var config = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(AppContext.BaseDirectory))
            .AddJsonFile("appsettings.json")
            .Build();

            var services = new ServiceCollection();
            services.AddDbContext<LabSysManagerContext>(options => options.UseSqlServer(config.GetConnectionString("LabSysManager")));

            var serviceProvider = services.BuildServiceProvider();

            dbContext = serviceProvider.GetService<LabSysManagerContext>();

        }

        private static void AtualizarArquivoJsonClientes(List<ClienteDTO> clientes)
        {
            using (StreamWriter w = new StreamWriter(@"c:\opt\integracao\lab\clientes.json"))
            {
                var clientesSerialized = JsonConvert.SerializeObject(clientes);
                w.Write(JValue.Parse(clientesSerialized).ToString(Formatting.Indented));
            }
        }

        private static void AtualizarClientes(List<ClienteDTO> clientes)
        {
            var clienteRepository = new ClienteRepository(dbContext);
            var unitOfWork = new UnitOfWork(dbContext);
            Task t = Task.Run(async () =>
            {
                var listaClientes = await clienteRepository.ReadAll();

                foreach (var cliente in clientes)
                {
                    if (!listaClientes.Any(c => c.Cpf == cliente.CPF))
                    {
                        Console.WriteLine($"Atualizando cliente: {cliente.Nome}");
                        cliente.Cidade = await new EnderecoService().ObterCidadePorCep(cliente.CEP);
                        cliente.Estado = await new EnderecoService().ObterEstadoPorCep(cliente.CEP);
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
                            cliente.TipoSanguineo,
                            cliente.Cor));

                        await unitOfWork.Commit();
                    }
                }
            });

            t.Wait();
        }

        private static List<ClienteDTO> ObterClientesArquivoJson()
        {
            using (StreamReader r = new StreamReader(@"c:\opt\integracao\lab\clientes.json"))
            {
                string json = r.ReadToEnd();
                return JsonConvert.DeserializeObject<List<ClienteDTO>>(json);
            }
        }
    }
}
