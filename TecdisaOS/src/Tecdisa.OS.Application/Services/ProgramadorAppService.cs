using AutoMapper;
using System;
using System.Collections.Generic;
using Tecdisa.OS.Application.Interfaces;
using Tecdisa.OS.Application.ViewModel;
using Tecdisa.OS.Domain.Interfaces;
using Tecdisa.OS.Domain.Models;
using Tecdisa.OS.Infra.Data.UoW;

namespace Tecdisa.OS.Application.Services
{
    public class ProgramadorAppService : AppService, IProgramadorAppService
    {
        private readonly IProgramadorRepository _programadorRepository;

        public ProgramadorAppService(IProgramadorRepository repository, IUnitOfWork uow) : base(uow)
        {
            _programadorRepository = repository;
        }

        public PagedViewModel<ProgramadorViewModel> ObterTodosPaginado(int s, int t)
        {
            return Mapper.Map<PagedViewModel<ProgramadorViewModel>>(_programadorRepository.ObterTodosPaginado(s, t));
        }

        public IEnumerable<ProgramadorViewModel> ObterPorNome(string nome)
        {
            return Mapper.Map<IEnumerable<ProgramadorViewModel>>(_programadorRepository.ObterPorNome(nome));
        }

        public IEnumerable<ProgramadorViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<ProgramadorViewModel>>(_programadorRepository.ObterTodos());
        }

        public IEnumerable<ProgramadorViewModel> ObterProgramadoresDto()
        {
            return Mapper.Map<IEnumerable<ProgramadorViewModel>>(_programadorRepository.ObterProgramadoresDto());

        }

        public ProgramadorViewModel ObterPorId(int id)
        {
            return Mapper.Map<ProgramadorViewModel>(_programadorRepository.ObterPorId(id));
        }

        public ProgramadorViewModel Adicionar(ProgramadorViewModel programadorViewModel)
        {
            var programador = Mapper.Map<Programador>(programadorViewModel);
            _programadorRepository.Adicionar(programador);
            Commit();
            return programadorViewModel;
        }

        public ProgramadorViewModel Atualizar(ProgramadorViewModel programadorViewModel)
        {
            if (!programadorViewModel.Ativo)
            {
                var id = programadorViewModel.Id;
                Remover(id);
                return programadorViewModel;
            }

            var programador = Mapper.Map<Programador>(programadorViewModel);
            _programadorRepository.Atualizar(programador);
            Commit();
            return programadorViewModel;
        }

        public void Remover(int id)
        {
            _programadorRepository.Remover(id);
            Commit();
        }

        public void Dispose()
        {
            _programadorRepository.Dispose();
        }
    }
}
