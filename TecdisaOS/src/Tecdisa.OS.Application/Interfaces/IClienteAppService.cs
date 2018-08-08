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

        ClienteViewModel[] ObterTodosToArray();
        
        IEnumerable<ClienteViewModel> ObterAtivos();

        IEnumerable<ClienteViewModel> ObterPorNome(string nome);

        PagedViewModel<ClienteViewModel> ObterTodosPaginado(string nome, int s, int t);
        
        ClienteEnderecoViewModel ObterPorId(Guid id);

        ClienteViewModel ObterPorIdSemEndereco(Guid id);
        
        string ObterUsuario(Guid clienteId);

        void Remover(Guid id);
    }
}
