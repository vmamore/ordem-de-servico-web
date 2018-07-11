using System;
using System.Collections.Generic;
using Tecdisa.OS.Application.ViewModel;

namespace Tecdisa.OS.Application.Interfaces
{
    public interface IClienteAppService : IDisposable
    {
        ClienteEnderecoViewModel Adicionar(ClienteEnderecoViewModel clienteEnderecoViewModel);

        ClienteEnderecoViewModel Atualizar(ClienteEnderecoViewModel clienteEnderecoViewModel);

        IEnumerable<ClienteViewModel> ObterTodos();

        IEnumerable<ClienteViewModel> ObterAtivos();

        ClienteEnderecoViewModel ObterPorId(Guid id);

        void Remover(Guid id);
    }
}
