using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using Tecdisa.OS.Application.Interfaces;
using Tecdisa.OS.Application.ViewModel;
using Tecdisa.OS.Domain.Interfaces;
using Tecdisa.OS.Domain.Models;
using Tecdisa.OS.Infra.Data.Repository;
using Tecdisa.OS.Infra.Data.UoW;

namespace Tecdisa.OS.Application.Services
{
    public class ClienteAppService : AppService, IClienteAppService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IEnderecoRepository _enderecoRepository;

        public ClienteAppService(IClienteRepository clienteRepository, IEnderecoRepository enderecoRepository, IUnitOfWork uow) : base(uow)
        {
            _clienteRepository = clienteRepository;
            _enderecoRepository = enderecoRepository;
        }

        public PagedViewModel<ClienteViewModel> ObterTodosPaginado(string nome, int s, int t)
        {
            return Mapper.Map<PagedViewModel<ClienteViewModel>>(_clienteRepository.ObterTodosPaginado(nome, s, t));
        }

        public IEnumerable<ClienteViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<ClienteViewModel>>(_clienteRepository.ObterTodos());
        }

        public IEnumerable<ClienteViewModel> ObterAtivos()
        {
            return Mapper.Map<IEnumerable<ClienteViewModel>>(_clienteRepository.ObterAtivos());
        }

        public IEnumerable<ClienteViewModel> ObterPorNome(string nome)
        {
            return Mapper.Map<IEnumerable<ClienteViewModel>>(_clienteRepository.ObterPorNome(nome));
        }

        public ClienteViewModel[] ObterTodosToArray()
        {
            return Mapper.Map<ClienteViewModel[]>(_clienteRepository.ObterTodos().ToArray());
        }

        public ClienteViewModel ObterPorIdSemEndereco(Guid id)
        {
            return Mapper.Map<ClienteViewModel>(_clienteRepository.ObterPorIdSemEndereco(id));
        }

        public ClienteEnderecoViewModel Adicionar(ClienteEnderecoViewModel clienteEnderecoViewModel)
        {
            var cliente = Mapper.Map<Cliente>(clienteEnderecoViewModel.Cliente);
            var endereco = Mapper.Map<Endereco>(clienteEnderecoViewModel.Endereco);

            cliente.AdicionarEndereco(endereco);

            cliente.Ativar();

            _clienteRepository.Adicionar(cliente);
            
            _uow.Commit();

            return clienteEnderecoViewModel;
        }

        public ClienteEnderecoViewModel Atualizar(ClienteEnderecoViewModel clienteEnderecoViewModel)
        {
            var cliente = Mapper.Map<Cliente>(clienteEnderecoViewModel.Cliente);
            var endereco = Mapper.Map<Endereco>(clienteEnderecoViewModel.Endereco);

            cliente.AdicionarEndereco(endereco);

            // IMPROVE LATER
            _clienteRepository.Atualizar(cliente);
            _enderecoRepository.Atualizar(endereco);

            _uow.Commit();

            return clienteEnderecoViewModel;
        }

        public ClienteEnderecoViewModel ObterPorId(Guid id)
        {
            var cliente = Mapper.Map<ClienteViewModel>(_clienteRepository.ObterPorId(id));

            var clienteEnderecoViewModel = new ClienteEnderecoViewModel();

            clienteEnderecoViewModel.Cliente = Mapper.Map<ClienteViewModel>(cliente);
            clienteEnderecoViewModel.Endereco = Mapper.Map<EnderecoViewModel>(cliente.Enderecos.FirstOrDefault());

            return clienteEnderecoViewModel;
        }

        public string ObterUsuario(Guid clienteId)
        {
            return _clienteRepository.ObterUsuario(clienteId);
        }

        public void Remover(Guid id)
        {
            _clienteRepository.Remover(id);
            Commit();
        }

        public void Dispose()
        {
            _clienteRepository.Dispose();
            _enderecoRepository.Dispose();
        }
    }
}
