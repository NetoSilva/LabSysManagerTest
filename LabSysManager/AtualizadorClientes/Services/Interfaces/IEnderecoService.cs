using System.ServiceModel;
using System.Threading.Tasks;

namespace AtualizadorClientes.Services.Interfaces
{
    [ServiceContract]
    public interface IEnderecoService
    {
        [OperationContract]
        Task<string> ObterEstadoPorCep(string cep);

        [OperationContract]
        Task<string> ObterCidadePorCep(string cep);
    }
}
