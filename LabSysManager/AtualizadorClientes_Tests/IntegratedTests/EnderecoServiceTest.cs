using AtualizadorClientes.Services;
using System.ServiceModel;
using Xunit;
using Exception = System.Exception;
namespace AtualizadorClientes_Tests.IntegratedTests
{
    public class EnderecoServiceTest
    {
        [Fact]
        public async void ObterCidadePorCep_CepVazioOuNulo_ThrowsException()
        {
            var enderecoService = new EnderecoService();
            var ex = await Assert.ThrowsAsync<Exception>(async () => await enderecoService.ObterCidadePorCep(""));
            var ex2 = await Assert.ThrowsAsync<Exception>(async () => await enderecoService.ObterCidadePorCep(null));

            Assert.Equal("CEP não pode estar vazio ou nulo.", ex.Message);
            Assert.Equal("CEP não pode estar vazio ou nulo.", ex2.Message);
        }

        [Fact]
        public async void ObterCidadePorCep_CepInvalido_ThrowsFaultException()
        {
            var enderecoService = new EnderecoService();
            var ex = await Assert.ThrowsAsync<FaultException<string>>(async () => await enderecoService.ObterCidadePorCep("0"));
            Assert.Equal("CEP INVÁLIDO", ex.Message);
        }

        [Fact]
        public async void ObterEstadoPorCep_CepVazioOuNulo_ThrowsException()
        {
            var enderecoService = new EnderecoService();
            var ex = await Assert.ThrowsAsync<Exception>(async () => await enderecoService.ObterEstadoPorCep(""));
            var ex2 = await Assert.ThrowsAsync<Exception>(async () => await enderecoService.ObterEstadoPorCep(null));

            Assert.Equal("CEP não pode estar vazio ou nulo.", ex.Message);
            Assert.Equal("CEP não pode estar vazio ou nulo.", ex2.Message);
        }

        [Fact]
        public async void ObterEstadoPorCep_CepInvalido_ThrowsException()
        {
            var enderecoService = new EnderecoService();
            var ex = await Assert.ThrowsAsync<FaultException<string>>(async () => await enderecoService.ObterEstadoPorCep("0"));
            Assert.Equal("CEP INVÁLIDO", ex.Message);
        }
    }
}
