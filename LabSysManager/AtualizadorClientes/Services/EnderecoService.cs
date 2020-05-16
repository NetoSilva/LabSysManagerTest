using AtualizadorClientes.DTOs;
using AtualizadorClientes.Helpers;
using AtualizadorClientes.Services.Interfaces;
using CorreiosService;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace AtualizadorClientes.Services
{
    public class EnderecoService : IEnderecoService
    {
        private AtendeClienteClient AtendeClienteClient;
        public EnderecoService()
        {
            AtendeClienteClient = new AtendeClienteClient();
        }
        public async Task<string> ObterCidadePorCep(string cep)
        {
            consultaCEPResponse consultaCepResponse = await AtendeClienteClient.consultaCEPAsync(cep);
            var json = "";
            EnderecoDTO endereco = null;

            if (consultaCepResponse != null)
            {
                json = JsonConvert.SerializeObject(consultaCepResponse);
            }

            if (!string.IsNullOrEmpty(json))
            {
                json = JsonHelper.RemoveWcfReturnNode(json);
                endereco = JsonConvert.DeserializeObject<EnderecoDTO>(json);
            }

            return endereco.Cidade;
        }

        public async Task<string> ObterEstadoPorCep(string cep)
        {
            consultaCEPResponse consultaCepResponse = await AtendeClienteClient.consultaCEPAsync(cep);
            var json = "";
            EnderecoDTO endereco = null;

            if (consultaCepResponse != null)
            {
                json = JsonConvert.SerializeObject(consultaCepResponse);
            }

            if (!string.IsNullOrEmpty(json))
            {
                json = JsonHelper.RemoveWcfReturnNode(json);
                endereco = JsonConvert.DeserializeObject<EnderecoDTO>(json);
            }

            return endereco.Uf;
        }
    }
}
