using AutoMapper;
using System;
using System.Collections.Generic;
using Tecdisa.OS.Application.Interfaces;
using Tecdisa.OS.Application.ViewModel;
using Tecdisa.OS.Domain.Interfaces;
using Tecdisa.OS.Domain.Models;
using Tecdisa.OS.Domain.Services;
using Tecdisa.OS.Infra.Data.UoW;

namespace Tecdisa.OS.Application.Services
{
    public class OrdemDeServicoAppService : AppService, IOrdemDeServicoAppService
    {
        private readonly IOrdemDeServicoRepository _ordemRepository;
        private readonly IOrdemDeServicoService _ordemDeServicoService;

        public OrdemDeServicoAppService(IOrdemDeServicoRepository ordemRepository, IOrdemDeServicoService ordemDeServicoService, IUnitOfWork uow ) : base(uow)
        {
            _ordemRepository = ordemRepository;
            _ordemDeServicoService = ordemDeServicoService;
        }

        public PagedViewModel<OrdemDeServicoViewModel> ObterTodosPaginado(int s, int t)
        {
            return Mapper.Map<PagedViewModel<OrdemDeServicoViewModel>>(_ordemRepository.ObterTodosPaginado(s, t));
        }

        public IEnumerable<OrdemDeServicoViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<OrdemDeServicoViewModel>>(_ordemRepository.ObterTodos());
        }

        public OrdemDeServicoViewModel ObterPorId(int id)
        {
            return Mapper.Map<OrdemDeServicoViewModel>(_ordemRepository.ObterPorId(id));
        }

        public IEnumerable<OrdemDeServicoViewModel> ObterPorCliente(Guid idClient)
        {
            return Mapper.Map<IEnumerable<OrdemDeServicoViewModel>>(_ordemRepository.ObterTodosPorCliente(idClient));
        }

        public IEnumerable<OrdemDeServicoViewModel> ObterPorPeriodo(DateTime inicial, DateTime final)
        {
            return Mapper.Map<IEnumerable<OrdemDeServicoViewModel>>(_ordemRepository.ObterPorPeriodo(inicial, final));
        }

        public IEnumerable<OrdemDeServicoViewModel> ObterPorProgramador(string idProgramador)
        {
            return Mapper.Map<IEnumerable<OrdemDeServicoViewModel>>(_ordemRepository.ObterPorProgramador(idProgramador));
        }

        public IEnumerable<OrdemDeServicoViewModel> ObterPorTecnico(string idTecnico)
        {
            return Mapper.Map<IEnumerable<OrdemDeServicoViewModel>>(_ordemRepository.ObterTodosPorTecnico(idTecnico));
        }

        public OrdemDeServicoViewModel Adicionar(OrdemDeServicoViewModel os)
        {
            var osRetorno = Mapper.Map<OrdemDeServico>(os);

            var osViewModel = Mapper.Map<OrdemDeServicoViewModel>(_ordemRepository.Adicionar(osRetorno));
            
            return osViewModel;
        }

        public OrdemDeServicoViewModel Adicionar(OrdemDeServicoViewModel os, string userId)
        {
            os.TecnicoId = userId;

            var osRetorno = Mapper.Map<OrdemDeServico>(os);
            
            var osViewModel = Mapper.Map<OrdemDeServicoViewModel>(_ordemDeServicoService.Adicionar(osRetorno));

            _uow.Commit();

            return osViewModel;
        }

        public OrdemDeServicoViewModel Atualizar(OrdemDeServicoViewModel os)
        {
            var osRetorno = Mapper.Map<OrdemDeServico>(os);

            var osViewModel = Mapper.Map<OrdemDeServicoViewModel>(_ordemRepository.Atualizar(osRetorno));

            _uow.Commit();

            return osViewModel;
        }

        public void Remover(int id)
        {
            _ordemRepository.Remover(id);
            Commit();
        }

        public void Dispose()
        {
            _ordemRepository.Dispose();
        }
    }
}
