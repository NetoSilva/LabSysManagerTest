using AtualizadorClientes.Services;
using LabSysManager_Infra.Context;
using LabSysManager_Infra.Repositories;
using LabSysManager_Infra.UoW;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Threading.Tasks;

namespace AtualizadorClientes
{
    class Program
    {
        private static DbContext dbContext;
        private static IConfigurationRoot config;
        static void Main(string[] args)
        {
            Configure();
            var path = config.GetSection("ClientesJsonPath").GetSection("Path").Value;

            var clienteRepository = new ClienteRepository(dbContext);
            var unitOfWork = new UnitOfWork(dbContext);
            var clienteService = new ClienteService(dbContext);
            var clientes = clienteService.ObterClientesArquivoJson(path);
            clienteService.AtualizarClientes(clientes);

            Task t = Task.Run(async () =>
            {
                await clienteService.SalvarClientes(clientes);
            });

            t.Wait();

            clienteService.AtualizarArquivoJsonClientes(clientes, path);

            Console.WriteLine("Atualizado");
            Console.ReadKey();
        }

        private static void Configure()
        {
             config = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(AppContext.BaseDirectory))
            .AddJsonFile("appsettings.json")
            .Build();

            var services = new ServiceCollection();
            services.AddDbContext<LabSysManagerContext>(options => options.UseSqlServer(config.GetConnectionString("LabSysManager")));

            var serviceProvider = services.BuildServiceProvider();

            dbContext = serviceProvider.GetService<LabSysManagerContext>();
        }
    }
}
