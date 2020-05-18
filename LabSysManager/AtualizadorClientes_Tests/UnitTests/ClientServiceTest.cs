using AtualizadorClientes.DTOs;
using AtualizadorClientes.Services;
using LabSysManager_Domain.Models;
using LabSysManager_Infra.Context;
using LabSysManager_Infra.Repositories.Interfaces;
using LabSysManager_Infra.UoW.Interfaces;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace AtualizadorClientes_Tests.UnitTests
{
    public class ClientServiceTest
    {
        public DbContextOptions<LabSysManagerContext> options;
        public ClientServiceTest()
        {
            options = new DbContextOptionsBuilder<LabSysManagerContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
        }

        [Fact]
        public void AtualizarArquivoJsonClientes_PathVazio_ThrowsArgumentException()
        {
            var clienteRepository = new Mock<IRepository<Cliente>>().Object;
            var unitOfWork = new Mock<IUnitOfWork>().Object;
           
            var clienteService = new ClienteService(clienteRepository, unitOfWork);
            var clientes = new List<ClienteDTO>
            {
                new ClienteDTO("Levi Juan Henrique da Rosa", 18, "837.218.376-73", "33.171.161-8","27/02/2001", "Araxá", "MG", "Peixes", "Giovanna Bianca Cristiane", "Hugo Antonio Roberto da Rosa", "levijuanhenriquedarosa_@cmfcequipamentos.com.br", "jqAYDrlOk5", "38183-044", 715, "(34) 3670-2306", "(34) 99963-1139", "1,73", 78, Cliente.ClienteTipoSanguineo.ANegativo, Cliente.ClienteCor.Vermelho)
            };

            var ex = Assert.Throws<ArgumentException>(() => clienteService.AtualizarArquivoJsonClientes(clientes, ""));
            Assert.Equal("Empty path name is not legal.", ex.Message);
        }

        [Fact]
        public void ObterClientesArquivoJson_PathVazio_ThrowsArgumentException()
        {
            var clienteRepository = new Mock<IRepository<Cliente>>().Object;
            var unitOfWork = new Mock<IUnitOfWork>().Object;
            var clienteService = new ClienteService(clienteRepository, unitOfWork);
  
            var ex = Assert.Throws<ArgumentException>(() => clienteService.ObterClientesArquivoJson(""));
            Assert.Equal("Empty path name is not legal.", ex.Message);
        }

        [Fact]
        public void ObterClientesArquivoJson_PathInvalido_ThrowsFileNotFoundException()
        {
            var clienteRepository = new Mock<IRepository<Cliente>>().Object;
            var unitOfWork = new Mock<IUnitOfWork>().Object;
            var clienteService = new ClienteService(clienteRepository, unitOfWork);
            var path = @"c:\puu";

            var ex = Assert.Throws<FileNotFoundException>(() => clienteService.ObterClientesArquivoJson(path));
            Assert.Equal("Could not find file '"+ path +"'.", ex.Message);
        }
    }
}
