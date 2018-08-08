using AutoMapper;
using System.Collections.Generic;
using Tecdisa.OS.Application.Interfaces;
using Tecdisa.OS.Application.ViewModel;
using Tecdisa.OS.Domain.Interfaces;
using Tecdisa.OS.Domain.Models;
using Tecdisa.OS.Infra.Data.UoW;

namespace Tecdisa.OS.Application.Services
{
    public class ModuloAppService : AppService, IModuloAppService
    {
        private readonly IModuloRepository _moduloRepository;

        public ModuloAppService(IModuloRepository modulo, IUnitOfWork uow) : base(uow)
        {
            _moduloRepository = modulo;
        }

        public IEnumerable<ModuloViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<ModuloViewModel>>(_moduloRepository.ObterTodos());
        }

        public IEnumerable<ModuloViewModel> ObterTodosComSistema()
        {
            return Mapper.Map<IEnumerable<ModuloViewModel>>(_moduloRepository.ObterTodosComSistema());

        }

        public IEnumerable<ModuloViewModel> ObterModulos(int sistemaId)
        {
            return Mapper.Map<IEnumerable<ModuloViewModel>>(_moduloRepository.ObterPorSistema(sistemaId));
        }

        public ModuloViewModel ObterPorId(int id)
        {
            return Mapper.Map<ModuloViewModel>(_moduloRepository.ObterPorId(id));
        }

        public ModuloViewModel Adicionar(ModuloViewModel entity)
        {
            var modulo = Mapper.Map<Modulo>(entity);
            modulo.Ativar();
            _moduloRepository.Adicionar(modulo);
            Commit();
            return entity;
        }

        public ModuloViewModel Atualizar(ModuloViewModel entity)
        {
            var modulo = Mapper.Map<Modulo>(entity);
            _moduloRepository.Atualizar(modulo);
            Commit();
            return entity;
        }

        public void Remover(int id)
        {
            _moduloRepository.Remover(id);
            Commit();
        }

        public void Dispose()
        {
            _moduloRepository.Dispose();
        }
    }
}
