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
    public class SistemaAppService : AppService, ISistemaAppService
    {
        private readonly ISistemaRepository _sistemaRepository;

        public SistemaAppService(ISistemaRepository repo, IUnitOfWork uow) : base(uow)
        {
            _sistemaRepository = repo;
        }

        public SistemaViewModel Adicionar(SistemaViewModel sistemaViewModel)
        {
            var sistema = Mapper.Map<Sistema>(sistemaViewModel);
            sistema.Ativar();
            _sistemaRepository.Adicionar(sistema);
            Commit();
            return sistemaViewModel;
        }

        public SistemaViewModel Atualizar(SistemaViewModel sistemaViewModel)
        {
            if(!sistemaViewModel.Ativo)
            {
                Remover(sistemaViewModel.Id);
                return sistemaViewModel;
            }

            var sistema = Mapper.Map<Sistema>(sistemaViewModel);
            _sistemaRepository.Atualizar(sistema);
            Commit();
            return sistemaViewModel;
        }

        public SistemaViewModel ObterPorId(int id)
        {
            return Mapper.Map<SistemaViewModel>(_sistemaRepository.ObterPorId(id));
        }

        public IEnumerable<SistemaViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<SistemaViewModel>>(_sistemaRepository.ObterTodos());
        }

        public void Remover(int id)
        {
            _sistemaRepository.Remover(id);
            Commit();
        }

        public void Dispose()
        {
            _sistemaRepository.Dispose();
        }
    }
}
