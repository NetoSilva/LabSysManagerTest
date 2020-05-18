using AutoMapper;
using LabSysManager_Domain.Models;
using LabSysManager_Infra.Repositories.Interfaces;
using LabSysManager_Services.AutoMapper;
using LabSysManager_Services.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace LabSysManager_Services_Tests.UnitTests
{
    public class ClienteAppServiceTest
    {
        private readonly IMapper mapper;

        public ClienteAppServiceTest()
        {
            var DomainToViewModelMappingProfile = new DomainToViewModelMappingProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(DomainToViewModelMappingProfile));
            mapper = new Mapper(configuration);
        }

        [Fact]
        public async Task ObterTodosPorIdade_IdadeMenorIgualZero_ThrowsException()
        {
            var clienteRepository = new Mock<IRepository<Cliente>>();
            var clienteAppService = new ClienteAppService(clienteRepository.Object, mapper);

            var ex = await Assert.ThrowsAsync<Exception>(() => clienteAppService.ObterTodosPorIdade(0));
            var ex2 = await Assert.ThrowsAsync<Exception>(() => clienteAppService.ObterTodosPorIdade(-1));

            Assert.Equal("Idade deve ser maior que 0.", ex.Message);
            Assert.Equal("Idade deve ser maior que 0.", ex2.Message);
        }

        [Fact]
        public async Task ObterTodosPorIdade_IdadeValida_RetornaClientes()
        {
            var clienteRepository = new Mock<IRepository<Cliente>>();
            clienteRepository.Setup(c => c.ReadAll())
                .Returns(Task.FromResult((IEnumerable<Cliente>)new List<Cliente>
                {
                     new Cliente("Levi Juan Henrique da Rosa", 18, "837.218.376-73", "33.171.161-8", new DateTime(2001, 02, 27), "Araxá", "MG", "Peixes", "Giovanna Bianca Cristiane", "Hugo Antonio Roberto da Rosa","levijuanhenriquedarosa_@cmfcequipamentos.com.br", "jqAYDrlOk5", "38183-044", 715,"(34) 3670-2306", "(34) 99963-1139", "1,73", 78, "A-", "Vermelho"),
                     new Cliente("Renan Caio Victor Caldeira",51, "569.980.286-01", "32.273.285-2", new DateTime(1965, 08, 13), "Ituiutaba", "MG", "Leão", "Tereza Antônia", "Ruan Yuri Caldeira","renancaiovictorcaldeira-78@eldor.it","XAbUybYUDp", "38304-120", 684,"(34) 2528-6956", "(34) 99812-7018", "1,98", 91, "O+", "Vermelho"),
                     new Cliente("Sebastiana Maitê Ribeiro",51,"206.334.456-65", "20.840.528-8", new DateTime(1968, 12, 26), "Passos", "MG", "Capricórnio", "Joana Rebeca Isabelle", "Cláudio Henry Ribeiro","ssebastianamaiteribeiro@id.uff.br", "WDljFP7aqa", "37902-340", 728,"(35) 2615-6221", "(35) 99290-5767", "1,65", 71, "B-", "Verde")
                }));

            var clienteAppService = new ClienteAppService(clienteRepository.Object, mapper);

            var clientes = await clienteAppService.ObterTodosPorIdade(51);
            Assert.NotNull(clientes);
            Assert.Equal<int>(2, clientes.Count());
        }

        [Fact]
        public async Task ObterTodosPorEstado_EstadoVazioOuNulo_ThrowsException()
        {
            var clienteRepository = new Mock<IRepository<Cliente>>();
            var clienteAppService = new ClienteAppService(clienteRepository.Object, mapper);

            var ex = await Assert.ThrowsAsync<Exception>(() => clienteAppService.ObterTodosPorEstado(""));
            var ex2 = await Assert.ThrowsAsync<Exception>(() => clienteAppService.ObterTodosPorEstado(null));

            Assert.Equal("Estado não pode estar vazio ou nulo.", ex.Message);
            Assert.Equal("Estado não pode estar vazio ou nulo.", ex2.Message);
        }

        [Fact]
        public async Task ObterTodosPorEstado_EstadoInvalido_RetornaListaVazia()
        {
            var clienteRepository = new Mock<IRepository<Cliente>>();
            clienteRepository.Setup(c => c.ReadAll())
                .Returns(Task.FromResult((IEnumerable<Cliente>)new List<Cliente>
                {
                     new Cliente("Levi Juan Henrique da Rosa", 18, "837.218.376-73", "33.171.161-8", new DateTime(2001, 02, 27), "Araxá", "MG", "Peixes", "Giovanna Bianca Cristiane", "Hugo Antonio Roberto da Rosa","levijuanhenriquedarosa_@cmfcequipamentos.com.br", "jqAYDrlOk5", "38183-044", 715,"(34) 3670-2306", "(34) 99963-1139", "1,73", 78, "A-", "Vermelho"),
                     new Cliente("Renan Caio Victor Caldeira",51, "569.980.286-01", "32.273.285-2", new DateTime(1965, 08, 13), "Ituiutaba", "MG", "Leão", "Tereza Antônia", "Ruan Yuri Caldeira","renancaiovictorcaldeira-78@eldor.it","XAbUybYUDp", "38304-120", 684,"(34) 2528-6956", "(34) 99812-7018", "1,98", 91, "O+", "Vermelho"),
                     new Cliente("Sebastiana Maitê Ribeiro",51,"206.334.456-65", "20.840.528-8", new DateTime(1968, 12, 26), "Passos", "MG", "Capricórnio", "Joana Rebeca Isabelle", "Cláudio Henry Ribeiro","ssebastianamaiteribeiro@id.uff.br", "WDljFP7aqa", "37902-340", 728,"(35) 2615-6221", "(35) 99290-5767", "1,65", 71, "B-", "Verde")
                }));

            var clienteAppService = new ClienteAppService(clienteRepository.Object, mapper);

            var clientes = await clienteAppService.ObterTodosPorEstado("QW");

            Assert.Empty(clientes);
        }

        [Fact]
        public async Task ObterTodosPorCidade_CidadeVazioOuNulo_ThrowsException()
        {
            var clienteRepository = new Mock<IRepository<Cliente>>();
            var clienteAppService = new ClienteAppService(clienteRepository.Object, mapper);

            var ex = await Assert.ThrowsAsync<Exception>(() => clienteAppService.ObterTodosPorCidade(""));
            var ex2 = await Assert.ThrowsAsync<Exception>(() => clienteAppService.ObterTodosPorCidade(null));

            Assert.Equal("Cidade não pode estar vazio ou nulo.", ex.Message);
            Assert.Equal("Cidade não pode estar vazio ou nulo.", ex2.Message);
        }

        [Fact]
        public async Task ObterTodosPorCidade_CidadeInvalido_ListaClientesVazia()
        {
            var clienteRepository = new Mock<IRepository<Cliente>>();
            clienteRepository.Setup(c => c.ReadAll())
                .Returns(Task.FromResult((IEnumerable<Cliente>)new List<Cliente>
                {
                     new Cliente("Levi Juan Henrique da Rosa", 18, "837.218.376-73", "33.171.161-8", new DateTime(2001, 02, 27), "Araxá", "MG", "Peixes", "Giovanna Bianca Cristiane", "Hugo Antonio Roberto da Rosa","levijuanhenriquedarosa_@cmfcequipamentos.com.br", "jqAYDrlOk5", "38183-044", 715,"(34) 3670-2306", "(34) 99963-1139", "1,73", 78, "A-", "Vermelho"),
                     new Cliente("Renan Caio Victor Caldeira",51, "569.980.286-01", "32.273.285-2", new DateTime(1965, 08, 13), "Ituiutaba", "MG", "Leão", "Tereza Antônia", "Ruan Yuri Caldeira","renancaiovictorcaldeira-78@eldor.it","XAbUybYUDp", "38304-120", 684,"(34) 2528-6956", "(34) 99812-7018", "1,98", 91, "O+", "Vermelho"),
                     new Cliente("Sebastiana Maitê Ribeiro",51,"206.334.456-65", "20.840.528-8", new DateTime(1968, 12, 26), "Passos", "MG", "Capricórnio", "Joana Rebeca Isabelle", "Cláudio Henry Ribeiro","ssebastianamaiteribeiro@id.uff.br", "WDljFP7aqa", "37902-340", 728,"(35) 2615-6221", "(35) 99290-5767", "1,65", 71, "B-", "Verde")
                }));

            var clienteAppService = new ClienteAppService(clienteRepository.Object, mapper);

            var clientes = await clienteAppService.ObterTodosPorEstado("acaxantuba");

            Assert.Empty(clientes);
        }

        [Fact]
        public async Task ObterPesoMedioPorIdade_IdadeMenorIgualZero_ThrowsException()
        {
            var clienteRepository = new Mock<IRepository<Cliente>>();
            var clienteAppService = new ClienteAppService(clienteRepository.Object, mapper);

            var ex = await Assert.ThrowsAsync<Exception>(() => clienteAppService.ObterPesoMedioPorIdade(0));
            var ex2 = await Assert.ThrowsAsync<Exception>(() => clienteAppService.ObterPesoMedioPorIdade(-1));

            Assert.Equal("Idade deve ser maior que 0.", ex.Message);
            Assert.Equal("Idade deve ser maior que 0.", ex2.Message);
        }

        [Fact]
        public async Task ObterPesoMedioPorIdade_IdadeValida_RetornaPesoMedio()
        {
            var clienteRepository = new Mock<IRepository<Cliente>>();
            clienteRepository.Setup(c => c.ReadAll())
                .Returns(Task.FromResult((IEnumerable<Cliente>)new List<Cliente>
                {
                     new Cliente("Levi Juan Henrique da Rosa", 18, "837.218.376-73", "33.171.161-8", new DateTime(2001, 02, 27), "Araxá", "MG", "Peixes", "Giovanna Bianca Cristiane", "Hugo Antonio Roberto da Rosa","levijuanhenriquedarosa_@cmfcequipamentos.com.br", "jqAYDrlOk5", "38183-044", 715,"(34) 3670-2306", "(34) 99963-1139", "1,73", 78, "A-", "Vermelho"),
                     new Cliente("Renan Caio Victor Caldeira",51, "569.980.286-01", "32.273.285-2", new DateTime(1965, 08, 13), "Ituiutaba", "MG", "Leão", "Tereza Antônia", "Ruan Yuri Caldeira","renancaiovictorcaldeira-78@eldor.it","XAbUybYUDp", "38304-120", 684,"(34) 2528-6956", "(34) 99812-7018", "1,98", 91, "O+", "Vermelho"),
                     new Cliente("Sebastiana Maitê Ribeiro",51,"206.334.456-65", "20.840.528-8", new DateTime(1968, 12, 26), "Passos", "MG", "Capricórnio", "Joana Rebeca Isabelle", "Cláudio Henry Ribeiro","ssebastianamaiteribeiro@id.uff.br", "WDljFP7aqa", "37902-340", 728,"(35) 2615-6221", "(35) 99290-5767", "1,65", 71, "B-", "Verde")
                }));

            var clienteAppService = new ClienteAppService(clienteRepository.Object, mapper);

            var pesoMedio = await clienteAppService.ObterPesoMedioPorIdade(51);
            Assert.Equal<long>(81, pesoMedio);
        }

        [Fact]
        public async Task ObterPesoMedioPorEstado_EstadoVazioOuNulo_ThrowsException()
        {
            var clienteRepository = new Mock<IRepository<Cliente>>();
            var clienteAppService = new ClienteAppService(clienteRepository.Object, mapper);

            var ex = await Assert.ThrowsAsync<Exception>(() => clienteAppService.ObterPesoMedioPorEstado(""));
            var ex2 = await Assert.ThrowsAsync<Exception>(() => clienteAppService.ObterPesoMedioPorEstado(null));

            Assert.Equal("Estado não pode estar vazio ou nulo.", ex.Message);
            Assert.Equal("Estado não pode estar vazio ou nulo.", ex2.Message);
        }

        [Fact]
        public async Task ObterPesoMedioPorEstado_EstadoInvalido_RetornaZero()
        {
            var clienteRepository = new Mock<IRepository<Cliente>>();
            clienteRepository.Setup(c => c.ReadAll())
                .Returns(Task.FromResult((IEnumerable<Cliente>)new List<Cliente>
                {
                     new Cliente("Levi Juan Henrique da Rosa", 18, "837.218.376-73", "33.171.161-8", new DateTime(2001, 02, 27), "Araxá", "MG", "Peixes", "Giovanna Bianca Cristiane", "Hugo Antonio Roberto da Rosa","levijuanhenriquedarosa_@cmfcequipamentos.com.br", "jqAYDrlOk5", "38183-044", 715,"(34) 3670-2306", "(34) 99963-1139", "1,73", 78, "A-", "Vermelho"),
                     new Cliente("Renan Caio Victor Caldeira",51, "569.980.286-01", "32.273.285-2", new DateTime(1965, 08, 13), "Ituiutaba", "MG", "Leão", "Tereza Antônia", "Ruan Yuri Caldeira","renancaiovictorcaldeira-78@eldor.it","XAbUybYUDp", "38304-120", 684,"(34) 2528-6956", "(34) 99812-7018", "1,98", 91, "O+", "Vermelho"),
                     new Cliente("Sebastiana Maitê Ribeiro",51,"206.334.456-65", "20.840.528-8", new DateTime(1968, 12, 26), "Passos", "MG", "Capricórnio", "Joana Rebeca Isabelle", "Cláudio Henry Ribeiro","ssebastianamaiteribeiro@id.uff.br", "WDljFP7aqa", "37902-340", 728,"(35) 2615-6221", "(35) 99290-5767", "1,65", 71, "B-", "Verde")
                }));

            var clienteAppService = new ClienteAppService(clienteRepository.Object, mapper);

            var pesoMedio = await clienteAppService.ObterPesoMedioPorEstado("QW");

            Assert.Equal(0,pesoMedio);
        }

        [Fact]
        public async Task ObterPesoMedioPorEstado_Valido_RetornaPesoMedio()
        {
            var clienteRepository = new Mock<IRepository<Cliente>>();
            clienteRepository.Setup(c => c.ReadAll())
                .Returns(Task.FromResult((IEnumerable<Cliente>)new List<Cliente>
                {
                     new Cliente("Levi Juan Henrique da Rosa", 18, "837.218.376-73", "33.171.161-8", new DateTime(2001, 02, 27), "Araxá", "MG", "Peixes", "Giovanna Bianca Cristiane", "Hugo Antonio Roberto da Rosa","levijuanhenriquedarosa_@cmfcequipamentos.com.br", "jqAYDrlOk5", "38183-044", 715,"(34) 3670-2306", "(34) 99963-1139", "1,73", 78, "A-", "Vermelho"),
                     new Cliente("Renan Caio Victor Caldeira",51, "569.980.286-01", "32.273.285-2", new DateTime(1965, 08, 13), "Ituiutaba", "MG", "Leão", "Tereza Antônia", "Ruan Yuri Caldeira","renancaiovictorcaldeira-78@eldor.it","XAbUybYUDp", "38304-120", 684,"(34) 2528-6956", "(34) 99812-7018", "1,98", 91, "O+", "Vermelho"),
                     new Cliente("Sebastiana Maitê Ribeiro",51,"206.334.456-65", "20.840.528-8", new DateTime(1968, 12, 26), "Passos", "MG", "Capricórnio", "Joana Rebeca Isabelle", "Cláudio Henry Ribeiro","ssebastianamaiteribeiro@id.uff.br", "WDljFP7aqa", "37902-340", 728,"(35) 2615-6221", "(35) 99290-5767", "1,65", 71, "B-", "Verde")
                }));

            var clienteAppService = new ClienteAppService(clienteRepository.Object, mapper);

            var pesoMedio = await clienteAppService.ObterPesoMedioPorEstado("MG");

            Assert.Equal(80, pesoMedio);
        }
    }
}
