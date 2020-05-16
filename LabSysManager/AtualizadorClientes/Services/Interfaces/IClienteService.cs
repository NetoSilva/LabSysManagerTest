using AtualizadorClientes.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AtualizadorClientes.Services.Interfaces
{
    interface IClienteService : IDisposable
    {
        List<ClienteDTO> ObterClientesArquivoJson(string path);
        void AtualizarClientes(List<ClienteDTO> clientes);
        void AtualizarArquivoJsonClientes(List<ClienteDTO> clientes, string path);
    }
}
