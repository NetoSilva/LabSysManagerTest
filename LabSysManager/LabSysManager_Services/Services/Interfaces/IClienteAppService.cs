using LabSysManager_Services.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LabSysManager_Services.Services.Interfaces
{
    interface IClienteAppService
    {
        Task<List<ClienteViewModel>> ObterTodosPorCidade(string cidade);
        Task<List<ClienteViewModel>> ObterTodosPorEstado(string estado);
        Task<List<ClienteViewModel>> ObterTodosPorIdade(long idade);
        Task<long> ObterPesoMedioPorIdade(long idade);
        Task<long> ObterPesoMedioPorEstado(string estado);
    }
}
